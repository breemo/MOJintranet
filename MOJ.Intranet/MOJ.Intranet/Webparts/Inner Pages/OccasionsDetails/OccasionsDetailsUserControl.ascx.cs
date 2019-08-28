using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.OccasionsDetails
{
    public partial class OccasionsDetailsUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["OccasionId"] != null)
                    FillDetails();
                else
                    Response.Redirect(SPContext.Current.RootFolderUrl);
            }
        }
        public void FillDetails()
        {
            try
            {
                string OccasionIdID = Request.QueryString["OccasionId"].ToString();
                OccasionsEntity occasionItem = new Occasions().GetOccasionById(Convert.ToInt32(OccasionIdID));

                lblTitle.Text = occasionItem.Title;
                lblBody.Text = occasionItem.Description;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
            }
        }
    }
}
