using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OccasionCommentsEntity itemSumbit = new OccasionCommentsEntity();
            itemSumbit.OccasionID = int.Parse(Request.QueryString["OccasionId"]);
            itemSumbit.Description = txtComments.Value;

            OccasionComments comments = new OccasionComments();
            bool isSaved = comments.SaveUpdate(itemSumbit);

            //if (isSaved == true)
            //{
            //    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
            //    posts.Style.Add("display", "none");
            //    SuccessMsgDiv.Style.Add("display", "block");
            //}
        }
        public void FillDetails()
        {
            try
            {
                string OccasionID = Request.QueryString["OccasionId"].ToString();
                OccasionsEntity occasionItem = new Occasions().GetOccasionById(Convert.ToInt32(OccasionID));

                lblOccasionBody.Text = occasionItem.Description;
                lblPublishDate.Text = Convert.ToDateTime(occasionItem.Created).ToString("dd MMM yyyy"); // "10 ديسمبر 2012";
                lblPublishedBy.Text = occasionItem.CreatedBy;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
            }
        }
    }
}
