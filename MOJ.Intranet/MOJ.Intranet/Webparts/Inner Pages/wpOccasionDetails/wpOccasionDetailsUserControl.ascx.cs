using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.wpOccasionDetails
{
    public partial class wpOccasionDetailsUserControl : UserControl
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
                string OccasionID = Request.QueryString["OccasionId"].ToString();
                OccasionsEntity occasionItem = new Occasions().GetOccasionById(Convert.ToInt32(OccasionID));

                lblOccasionTitle.Text = occasionItem.Title;
                lblOccasionBody.Text = occasionItem.Description;
                lblPublishDate.Text = Convert.ToDateTime(occasionItem.Created).ToString("dd yyyy MMM"); // "10 ديسمبر 2012";
                lblPublishedBy.Text = occasionItem.CreatedBy;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
            }
        }
    }
}
