using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.PlannedCouncilsWP
{
    public partial class PlannedCouncilsWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        public int PageNumber2
        {
            get
            {
                if (ViewState["PageNumber2"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber2"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber2"] = value; }
        }
        protected void rpt2Paging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber2 = Convert.ToInt32(e.CommandArgument) - 1;
            BindData();


        }
        public void HeaderRowG()
        {
            string CouncilNo = SPUtility.GetLocalizedString("$Resources: CouncilNo", "Resource", SPContext.Current.Web.Language);
            string Department = SPUtility.GetLocalizedString("$Resources: Department", "Resource", SPContext.Current.Web.Language);
            string CouncilTopic = SPUtility.GetLocalizedString("$Resources: CouncilTopic", "Resource", SPContext.Current.Web.Language);
            string CouncilDate = SPUtility.GetLocalizedString("$Resources: CouncilDate", "Resource", SPContext.Current.Web.Language); ;
            string Lecturer = SPUtility.GetLocalizedString("$Resources: Lecturer", "Resource", SPContext.Current.Web.Language);
            string JoiningConditions = SPUtility.GetLocalizedString("$Resources: JoiningConditions", "Resource", SPContext.Current.Web.Language);
            string Details = SPUtility.GetLocalizedString("$Resources: Participate", "Resource", SPContext.Current.Web.Language);
            GridViewRow row2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.Text = CouncilNo;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Department;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = CouncilTopic;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = CouncilDate;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Lecturer;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = JoiningConditions;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Details;
            row2.Controls.Add(cell2);
            row2.CssClass = "firstrow";
            grdHeldCouncil.HeaderRow.Parent.Controls.AddAt(0, row2);
        }
        private void BindData()
        {
            if (!_isRefresh)
            {         
                try
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;                   
                    DateTime dateTime = DateTime.UtcNow.Date;
                    List<knowledgeCouncilEntity> Requestsollection = new knowledgeCouncil().GetPlannedCouncils(currentUserlogin, languageCode, dateTime.ToString("yyyy-MM-dd"));
                    PagedDataSource pgitems = new PagedDataSource();
                    pgitems.AllowPaging = true;
                    //Control page size from here 
                    pgitems.PageSize = 10;
                    pgitems.DataSource = Requestsollection;
                    hdnPage.Value = Convert.ToString(PageNumber2 + 1);
                    pgitems.CurrentPageIndex = PageNumber2;

                    if (pgitems.PageCount > 1)
                    {
                        pgng2.Visible = true;
                        rpt2Paging.Visible = true;
                        ArrayList pages = new ArrayList();
                        for (int i = 0; i <= pgitems.PageCount - 1; i++)
                        {
                            pages.Add((i + 1).ToString());
                        }
                        rpt2Paging.DataSource = pages;
                        rpt2Paging.DataBind();
                    }
                    else
                    {
                        pgng2.Visible = false;
                        rpt2Paging.Visible = false;
                    }
                    grdHeldCouncil.DataSource = pgitems;
                    grdHeldCouncil.DataBind();
                    if (Requestsollection.Count > 0)
                    {
                        HeaderRowG();
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }








    }
}
