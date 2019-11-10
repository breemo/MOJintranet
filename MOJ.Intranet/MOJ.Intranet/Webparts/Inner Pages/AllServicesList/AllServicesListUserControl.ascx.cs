using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.AllServicesList
{
    public partial class AllServicesListUserControl : UserControl
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        BindData();
                        BindCoartServices();
                        BindEmployeesServices();
                        BindEServices();
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }
        #endregion Events

        #region Methods
        private void BindData()
        {
            try
            {
                List<ServicesListEntity> ServicesLst = new Services().GetAllActiveServices();

                lblDrawItems.Text = "";

                foreach (ServicesListEntity item in ServicesLst) //check all items
                {
                    //string title =SP.Common.LimitCharacters.Limit(item.Title, 35);
                    string des = LimitCharacters.Limit(item.Description, 120);
                    string siteURL = SPContext.Current.RootFolderUrl;

                    lblDrawItems.Text +=
                    string.Format(@"<div class='col-sm-3'>
                                        <div class='orderbox'>
                                            <div class='topnot'>
                                                <p>
                                                    <img src='{0}' />
                                                </p>
                                            </div>
                                            <div class='botonot'>
                                                <a href='{1}/{2}.aspx' class=''>{3}
                                                </a>
                                            </div>
                                        </div>
                                    </div>", item.Picture, siteURL,item.PageName,item.Title);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void BindCoartServices()
        {
            try
            {
                List<ExternalLinkEntity> ExternalLinksLst = new ExternalLink().GetAllActiveExternalLinks("خدمات المحاكم");

                lblDrawCoartServices.Text = "";

                foreach (ExternalLinkEntity item in ExternalLinksLst) //check all items
                {
                    lblDrawCoartServices.Text +=
                    string.Format(@"<div class='col-sm-3'>
                                        <div class='orderbox'>
                                            <div class='topnot'>
                                                <p>
                                                    <img src='{0}' />
                                                </p>
                                            </div>
                                            <div class='botonot'>
                                                <a href='{1}' class=''>{2}
                                                </a>
                                            </div>
                                        </div>
                                    </div>", item.Picture, item.URL, item.Title);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void BindEmployeesServices()
        {
            try
            {
                List<ExternalLinkEntity> ExternalLinksLst = new ExternalLink().GetAllActiveExternalLinks("خدمات الموظفين");

                lblDrawEmployeesServices.Text = "";

                foreach (ExternalLinkEntity item in ExternalLinksLst) //check all items
                {
                    lblDrawEmployeesServices.Text +=
                    string.Format(@"<div class='col-sm-3'>
                                        <div class='orderbox'>
                                            <div class='topnot'>
                                                <p>
                                                    <img src='{0}' />
                                                </p>
                                            </div>
                                            <div class='botonot'>
                                                <a href='{1}' class=''>{2}
                                                </a>
                                            </div>
                                        </div>
                                    </div>", item.Picture, item.URL, item.Title);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void BindEServices()
        {
            try
            {
                List<ExternalLinkEntity> ExternalLinksLst = new ExternalLink().GetAllActiveExternalLinks("خدمات الكترونية");

                lblDrawEServices.Text = "";

                foreach (ExternalLinkEntity item in ExternalLinksLst) //check all items
                {
                    lblDrawEServices.Text +=
                    string.Format(@"<div class='col-sm-3'>
                                        <div class='orderbox'>
                                            <div class='topnot'>
                                                <p>
                                                    <img src='{0}' />
                                                </p>
                                            </div>
                                            <div class='botonot'>
                                                <a href='{1}' class=''>{2}
                                                </a>
                                            </div>
                                        </div>
                                    </div>", item.Picture, item.URL, item.Title);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        #endregion Methods
    }
}
