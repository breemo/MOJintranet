using MOJ.Business;
using MOJ.Entities;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.AllMemos
{
    public partial class AllMemosUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }

        private void BindData()
        {
            try
            {
                List<MemosEntity> NewsLst = new Memos().GetMemos();

                grdMemosLst.DataSource = NewsLst;
                grdMemosLst.DataBind();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void FillData(string srchString, string number)
        {
            List<MemosEntity> NewsLst = new Memos().GetMemos(srchString, number);

            grdMemosLst.DataSource = NewsLst;
            grdMemosLst.DataBind();
        }

        protected void grdMemosLst_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMemosLst.PageIndex = e.NewPageIndex;
            if (!string.IsNullOrEmpty(txtSrch.Value))
                BindData();
            else
                FillData(txtSrch.Value,txtNumber.Value);
        }

        protected void grdMemosLst_RowDataBound(object sender, GridViewRowEventArgs e) { }

        protected void btnSrch_Click(object sender, EventArgs e)
        {
            FillData(txtSrch.Value, txtNumber.Value);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Value = "";
            txtSrch.Value = "";
        }
    }
}
