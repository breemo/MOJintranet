using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.AllPolls
{
    public partial class AllPollsUserControl : UserControl
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
                    }
                }
                catch (Exception ex)
                {

                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }
        #endregion

        #region Methods
        private void BindData()
        {
            try
            {
                using (SPSite sites = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb web = sites.OpenWeb(SPUtility.GetLocalizedString("$Resources: SiteURL", "Resource", SPContext.Current.Web.Language)))
                    {
                        SPWebCollection collWebsite = sites.AllWebs;
                        SPListCollection collList = web.Lists;
                        int count = 0;
                        foreach (SPList oList in collList)
                        {
                            if (oList.BaseType == SPBaseType.Survey)
                            {
                                count++;
                                    lblDrawItems.Text +=
                                       string.Format(@"
                                         <div class='itemboxc'>
                                                <div class='boxcic'>
                                                    <span>" + count + @"
                                                    </span>
                                                </div>
                                                <div class='ques'>
                                                    <h5>{0}
                                                    </h5>
                                                    <span><a href='{1}'>{2}</a></span>
                                                </div>
                                            </div>    
                                        ", oList.Title, oList.DefaultNewFormUrl, SPUtility.GetLocalizedString("$Resources: Participate", "Resource", SPContext.Current.Web.Language));
                            }
                        }
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
