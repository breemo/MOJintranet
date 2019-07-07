using CommonLibrary;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.AllNews
{
    public partial class AllNewsUserControl : UserControl
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
                List<NewsEntity> NewsLst = new News().GetAllNews();

                grdNewsLst.DataSource = NewsLst;
                grdNewsLst.DataBind();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void FillData(string srchString)
        {
            List<NewsEntity> NewsLst = new News().GetNews(srchString);

            grdNewsLst.DataSource = NewsLst;
            grdNewsLst.DataBind();
        }

        protected void grdNewsLst_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNewsLst.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void grdNewsLst_RowDataBound(object sender, GridViewRowEventArgs e) { }

        protected void btnSrch_Click(object sender, EventArgs e)
        {
            FillData(txtSrch.Text);
        }

    }
}
