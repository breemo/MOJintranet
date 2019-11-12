using MOJ.Business;
using MOJ.Entities;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

namespace MOJ.Intranet.Webparts.Inner_Pages.AllMemos
{
    public partial class AllMemosUserControl : UserControl
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            if (PageNumber != 0)
            {
                PageNumber -= 1;
                BindData();
            }
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            if (PageNumber < rptPaging.Items.Count - 1)
            {
                PageNumber += 1;
                BindData();
            }
        }
        private void BindData()
        {
            lblHead.Visible = true;

            try
            {
                List<MemosEntity> NewsLst = new Memos().GetMemos();

                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = NewsLst;
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
                    rptPaging.DataSource = pages;
                    rptPaging.DataBind();
                }
                else
                {
                    pgng.Visible = false;
                    rptPaging.Visible = false;
                    lblHead.Visible = false;
                }

                grdMemosLst.DataSource = pgitems;
                grdMemosLst.DataBind();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void FillData(string srchString, string number)
        {
            lblHead.Visible = true;
            List<MemosEntity> NewsLst = new Memos().GetMemos(srchString, number);

            if (NewsLst.Count > 0)
            {
                pgng.Visible = true;

                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = NewsLst;
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
                    rptPaging.Visible = false;
                }

                grdMemosLst.DataSource = pgitems;
                grdMemosLst.DataBind();
            }
            else
            {
                pgng.Visible = false;
                grdMemosLst.DataSource = NewsLst;
                grdMemosLst.DataBind();

                lblHead.Visible = false;
            }
        }

        protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;

            if (string.IsNullOrEmpty(txtSrch.Value))
                BindData();
            else
                FillData(txtSrch.Value, txtNumber.Value);
        }

        protected void btnSrch_Click(object sender, EventArgs e)
        {
            PageNumber = 0;
            FillData(txtSrch.Value, txtNumber.Value);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Value = "";
            txtSrch.Value = "";

            //PageNumber = 0;
            //BindData();
        }
    }
}
