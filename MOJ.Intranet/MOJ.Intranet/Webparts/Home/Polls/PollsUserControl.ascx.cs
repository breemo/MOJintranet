using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.Polls
{
    public partial class PollsUserControl : UserControl
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
                                if (count <= 2)
                                {

                                    SPQuery q = new SPQuery();
                                    var userId = SPContext.Current.Web.CurrentUser.ID;
                                    q.Query = string.Format("<Where><And><Eq><FieldRef Name=\"Completed\" /><Value Type=\"Boolean\">1</Value></Eq><Eq><FieldRef Name=\"Author\" LookupId=\"True\"/><Value Type=\"User\">{0}</Value></Eq></And></Where>", userId);
                                    SPListItemCollection items = oList.GetItems(q);

                                    if (items.Count > 0)
                                    {
                                        lblDrawItems.Text +=
                                        string.Format(@"
                                        <div style='display:none'></div>
                                         <div class='itemboxc'>
                                                <div class='boxcic'>
                                                    <span>" + count + @"
                                                    </span>
                                                </div>
                                                <div class='ques'>
                                                    <h5>{0}
                                                    </h5>
                                                    <span>{1}</span>
                                                </div>
                                            </div>    
                                        ", oList.Title,SPUtility.GetLocalizedString("$Resources: Shared", "Resource", SPContext.Current.Web.Language), SPContext.Current.Web.Language);
                                    }
                                    else
                                    {

                                        lblDrawItems.Text +=
                                           string.Format(@"
                                        <div style='display:none'></div>
                                         <div class='itemboxc'>
                                                <div class='boxcic'>
                                                    <span>" + count + @"
                                                    </span>
                                                </div>
                                                <div class='ques'>
                                                    <h5>{0}
                                                    </h5>
                                                    <span><a href='javascript:Poll(""{2}"")'>{1}</a></span>
                                                </div>
                                            </div>    
                                        ", oList.Title, SPUtility.GetLocalizedString("$Resources: Participate", "Resource", SPContext.Current.Web.Language), oList.DefaultNewFormUrl);
                                    }
                                }
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