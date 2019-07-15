using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.InnerNavigation
{
    public partial class InnerNavigationUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        BindData();
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }

        #region Methods
        private void BindData()
        {
            try
            {
                SPWeb web = SPContext.Current.Web;
                PublishingWeb publishingWeb = PublishingWeb.GetPublishingWeb(web);
                PublishingPageCollection pages = publishingWeb.GetPublishingPages();
                foreach (var page in pages)
                {
                    if (page.Name != "default.aspx")
                    {
                        lblDrawItems.Text +=
                             string.Format(@"
                                    <li class='uk-active'><a href='{0}' >{1}</a></li>
                                    ", page.Uri, page.Title);
                    }

                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        #endregion
    }
}
