using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Drawing;
using System.Threading;

namespace MOJ.Intranet.Webparts.My_Services.myTasks
{
    public partial class myTasksUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataCompleted();
                BindDataNOTCompleted();

            }
        }
        public void HeaderRowG()
        {
            string RequestNumber = SPUtility.GetLocalizedString("$Resources: RequestNumber", "Resource", SPContext.Current.Web.Language);
            string ServiceType = SPUtility.GetLocalizedString("$Resources: ServiceType", "Resource", SPContext.Current.Web.Language);
            string AssignTo = SPUtility.GetLocalizedString("$Resources: AssignTo", "Resource", SPContext.Current.Web.Language);
            string Result = SPUtility.GetLocalizedString("$Resources: Result", "Resource", SPContext.Current.Web.Language); ;
            string TaskDate = SPUtility.GetLocalizedString("$Resources: TaskDate", "Resource", SPContext.Current.Web.Language);
            string Edit = SPUtility.GetLocalizedString("$Resources: Edit", "Resource", SPContext.Current.Web.Language);
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = RequestNumber;
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = ServiceType;
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = AssignTo;
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = TaskDate;
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = Edit;
            row.Controls.Add(cell);
            row.BackColor = ColorTranslator.FromHtml("#bd995d");
            grdMyTasks.HeaderRow.Parent.Controls.AddAt(0, row);

        }

        public void HeaderRowGAccomplished()
        {
            string RequestNumber = SPUtility.GetLocalizedString("$Resources: RequestNumber", "Resource", SPContext.Current.Web.Language);
            string ServiceType = SPUtility.GetLocalizedString("$Resources: ServiceType", "Resource", SPContext.Current.Web.Language);
            string AssignTo = SPUtility.GetLocalizedString("$Resources: AssignTo", "Resource", SPContext.Current.Web.Language);
            string Result = SPUtility.GetLocalizedString("$Resources: Result", "Resource", SPContext.Current.Web.Language); ;
            string TaskDate = SPUtility.GetLocalizedString("$Resources: TaskDate", "Resource", SPContext.Current.Web.Language);
            string Edit = SPUtility.GetLocalizedString("$Resources: Edit", "Resource", SPContext.Current.Web.Language);


            GridViewRow row2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.Text = RequestNumber;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = ServiceType;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = AssignTo;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Result;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = TaskDate;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Edit;
            row2.Controls.Add(cell2);
            row2.BackColor = ColorTranslator.FromHtml("#bd995d");
            grdMyAccomplishedTasks.HeaderRow.Parent.Controls.AddAt(0, row2);
        }

        protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            BindDataCompleted();
            BindDataNOTCompleted();

        }
        protected void rpt2Paging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber2 = Convert.ToInt32(e.CommandArgument) - 1;
            BindDataCompleted();
            BindDataNOTCompleted();

        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            if (PageNumber != 0)
            {
                PageNumber -= 1;
                BindDataCompleted();
                BindDataNOTCompleted();
            }
            else
            {
                BindDataCompleted();
                BindDataNOTCompleted();
            }
        }
        protected void lbFirst_Click(object sender, EventArgs e)
        {
            PageNumber = 0;
            BindDataCompleted();
            BindDataNOTCompleted();
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            PageNumber = Convert.ToInt32(ViewState["TotalTaskPages"]) - 1;
            BindDataCompleted();
            BindDataNOTCompleted();
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            if (PageNumber < rptPaging.Items.Count - 1)
            {
                PageNumber += 1;
                BindDataCompleted();
                BindDataNOTCompleted();
            }
            else
            {
                BindDataCompleted();
                BindDataNOTCompleted();
            }

        }



        protected void lbPrevious2_Click(object sender, EventArgs e)
        {
            if (PageNumber2 != 0)
            {
                PageNumber2 -= 1;
                BindDataCompleted();
                BindDataNOTCompleted();
            }
            else
            {
                BindDataCompleted();
                BindDataNOTCompleted();
            }
        }
        protected void lbFirst2_Click(object sender, EventArgs e)
        {
            PageNumber2 = 0;
            BindDataCompleted();
            BindDataNOTCompleted();
        }
        protected void lbLast2_Click(object sender, EventArgs e)
        {
            PageNumber2 = Convert.ToInt32(ViewState["TotalTaskPages2"]) - 1;
            BindDataCompleted();
            BindDataNOTCompleted();
        }
        protected void lbNext2_Click(object sender, EventArgs e)
        {
            if (PageNumber2 < rpt2Paging.Items.Count - 1)
            {
                PageNumber2 += 1;
                BindDataCompleted();
                BindDataNOTCompleted();
            }
            else
            {
                BindDataCompleted();
                BindDataNOTCompleted();
            }

        }

        private void HandlePaging()
        {
            ArrayList pages = new ArrayList();


            _firstIndex = PageNumber - 5;
            if (PageNumber > 5)
                _lastIndex = PageNumber + 5;
            else
                _lastIndex = 10;

            if (_lastIndex > Convert.ToInt32(ViewState["TotalTaskPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalTaskPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                pages.Add((i + 1).ToString());
            }

            rptPaging.DataSource = pages;
            rptPaging.DataBind();
        }
        private void HandlePaging2()
        {
            ArrayList pages2 = new ArrayList();


            _firstIndex2 = PageNumber2 - 5;
            if (PageNumber2 > 5)
                _lastIndex2 = PageNumber2 + 5;
            else
                _lastIndex2 = 10;

            if (_lastIndex2 > Convert.ToInt32(ViewState["TotalTaskPages2"]))
            {
                _lastIndex2 = Convert.ToInt32(ViewState["TotalTaskPages2"]);
                _firstIndex2 = _lastIndex2 - 10;
            }

            if (_firstIndex2 < 0)
                _firstIndex2 = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex2; i < _lastIndex2; i++)
            {
                pages2.Add((i + 1).ToString());
            }

            rpt2Paging.DataSource = pages2;
            rpt2Paging.DataBind();
        }


        int _firstIndex, _lastIndex, _firstIndex2, _lastIndex2;
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber"] = value; }
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




        private void BindDataNOTCompleted()
        {
            try
            {
                CultureInfo currentCulture2 = Thread.CurrentThread.CurrentUICulture;
                string languageCode2 = currentCulture2.TwoLetterISOLanguageName.ToLowerInvariant();

                List<TaskEntity> taskollectionC = new Task().GetMyTasks("NOCompleted", languageCode2);
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = taskollectionC;
                pgitems.AllowPaging = true;
                //Control page size from here 
                pgitems.PageSize = 8;
                hdnPage.Value = Convert.ToString(PageNumber + 1);
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount > 1)
                {
                    rptPaging.Visible = true;
                    ArrayList pages = new ArrayList();
                    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                    {
                        pages.Add((i + 1).ToString());
                    }
                    ViewState["TotalTaskPages"] = pgitems.PageCount;
                    rptPaging.DataSource = pages;
                    rptPaging.DataBind();
                }
                else
                {
                    pgng.Visible = false;
                    rptPaging.Visible = false;
                }
                grdMyTasks.DataSource = pgitems;
                grdMyTasks.DataBind();

                if (taskollectionC.Count > 0)
                {
                    HeaderRowG();
                }
                HandlePaging();

            }

            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void BindDataCompleted()
        {
            try
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();

                List<TaskEntity> taskollectionC = new Task().GetMyTasks("Completed", languageCode);
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = taskollectionC;
                pgitems.AllowPaging = true;
                //Control page size from here 
                pgitems.PageSize = 8;
                hdnPage2.Value = Convert.ToString(PageNumber2 + 1);
                pgitems.CurrentPageIndex = PageNumber2;
                if (pgitems.PageCount > 1)
                {
                    rpt2Paging.Visible = true;
                    ArrayList pages = new ArrayList();
                    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                    {
                        pages.Add((i + 1).ToString());
                    }
                    ViewState["TotalTaskPages2"] = pgitems.PageCount;
                    rpt2Paging.DataSource = pages;
                    rpt2Paging.DataBind();
                }
                else
                {
                    pgng2.Visible = false;
                    rpt2Paging.Visible = false;
                }
                grdMyAccomplishedTasks.DataSource = pgitems;
                grdMyAccomplishedTasks.DataBind();
                if (taskollectionC.Count > 0)
                {
                    HeaderRowGAccomplished();
                }
                HandlePaging2();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

    }
}
