﻿using Microsoft.SharePoint;
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
            cell.Text = AssignTo;
            row.Controls.Add(cell);
            cell.Text = TaskDate;
            row.Controls.Add(cell);
            cell.Text = Edit;
            row.Controls.Add(cell);
            row.BackColor = ColorTranslator.FromHtml("#bd995d");
            grdMyTasks.HeaderRow.Parent.Controls.AddAt(0, row);

            GridViewRow row2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.Text = RequestNumber;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = ServiceType;
            row2.Controls.Add(cell2);
            cell2.Text = AssignTo;
            row2.Controls.Add(cell2);
            cell2.Text = Result;
            row2.Controls.Add(cell2);
            cell2.Text = TaskDate;
            row2.Controls.Add(cell2);
            cell2.Text = Edit;
            row2.Controls.Add(cell2);
            row2.BackColor = ColorTranslator.FromHtml("#bd995d");
            grdMyTasks.HeaderRow.Parent.Controls.AddAt(0, row2);
        }
        
        protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            BindDataCompleted();
        }
        protected void rpt2Paging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber2 = Convert.ToInt32(e.CommandArgument) - 1;
            BindDataNOTCompleted();
        }
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
                List<TaskEntity> taskollectionC = new Task().GetMyTasks("NOCompleted");
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = taskollectionC;
                pgitems.AllowPaging = true;
                //Control page size from here 
                pgitems.PageSize = 8;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount > 1)
                {
                    rptPaging.Visible = true;
                    ArrayList pages = new ArrayList();
                    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                    {
                        pages.Add((i + 1).ToString());
                    }
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
                List<TaskEntity> taskollectionC = new Task().GetMyTasks("Completed");
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = taskollectionC;
                pgitems.AllowPaging = true;
                //Control page size from here 
                pgitems.PageSize = 8;
                pgitems.CurrentPageIndex = PageNumber2;
                if (pgitems.PageCount > 1)
                {
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
                grdMyAccomplishedTasks.DataSource = pgitems;
                grdMyAccomplishedTasks.DataBind();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

    }
}
