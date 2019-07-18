using CommonLibrary;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.MinistryFilesWebPart
{
    public partial class MinistryFilesWebPartUserControl : UserControl
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
                List<MinistryFilesEntity> Books = new MinistryFiles().GetMinistryFilesData();

                grdBookslsts.DataSource = Books;
                grdBookslsts.DataBind();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
