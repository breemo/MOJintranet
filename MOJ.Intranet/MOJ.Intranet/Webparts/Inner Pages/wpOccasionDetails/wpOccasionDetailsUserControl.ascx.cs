using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web;
using MOJ.Intranet.Classes.Common;

namespace MOJ.Intranet.Webparts.Inner_Pages.wpOccasionDetails
{
    public partial class wpOccasionDetailsUserControl : SiteUI
    {
        //#region RefreshChecking

        //public bool _refreshState;
        //public bool _isRefresh;
        //public bool IsRefresh
        //{
        //    get { return _isRefresh; }
        //}
        //protected override void LoadViewState(object savedState)
        //{
        //    object[] allStates = (object[])savedState;
        //    base.LoadViewState(allStates[0]);
        //    _refreshState = (bool)allStates[1];
        //    //if (HttpContext.Current.Session["__ISREFRESH"] != null)
        //    //    _isRefresh = _refreshState == (bool)HttpContext.Current.Session["__ISREFRESH"];
        //    //else
        //    //    _isRefresh = _refreshState;

        //    if (HttpContext.Current.Session["__ISREFRESH"] != null)
        //        _isRefresh = _refreshState == (bool)HttpContext.Current.Session["__ISREFRESH"];
        //    else
        //        _isRefresh = _refreshState;
        //}
        //protected override object SaveViewState()
        //{
        //    HttpContext.Current.Session["__ISREFRESH"] = _refreshState;
        //    object[] allStates = new object[2];
        //    allStates[0] = base.SaveViewState();
        //    allStates[1] = !_refreshState;
        //    return allStates;
        //}
        //#endregion RefreshChecking
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
            if (!_isRefresh)
            {
                OccasionCommentsEntity itemSumbit = new OccasionCommentsEntity();
                itemSumbit.OccasionID = int.Parse(Request.QueryString["OccasionId"]);

                TextBox strComment = ((TextBox)rptrComments.Controls[rptrComments.Controls.Count - 1].Controls[0].FindControl("txtComments"));
                itemSumbit.Description = strComment.Text;
                strComment.Text = "";

                OccasionComments comments = new OccasionComments();
                bool isSaved = comments.SaveUpdate(itemSumbit);

                BindComments(itemSumbit.OccasionID.ToString());

                //if (isSaved == true)
                //{
                //    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                //    posts.Style.Add("display", "none");
                //    SuccessMsgDiv.Style.Add("display", "block");
                //}
            }
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
                BindComments(OccasionID);

            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
            }
        }

        private void BindComments(string OccasionID)
        {
            List<OccasionCommentsEntity> occasionCommentsItem = new OccasionComments().GetCommentsByOccasionId(Convert.ToInt32(OccasionID));
            rptrComments.DataSource = occasionCommentsItem;
            rptrComments.DataBind();
        }
    }
}
