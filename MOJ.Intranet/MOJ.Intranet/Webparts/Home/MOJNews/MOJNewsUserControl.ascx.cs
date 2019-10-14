using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Threading;
using System.Globalization;

namespace MOJ.Intranet.Webparts.Home.MOJNews
{
    public partial class MOJNewsUserControl : UserControl
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
                        //lnkDetails.HRef = "/" + Convert.ToString(GetGlobalResourceObject("MOJ", "Simpol")) + "/Pages/NewsDetails.aspx";
                        BindData();
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
                List<NewsEntity> NewsLst = new News().GetLast4News();

                lblDrawItems.Text = "";

                foreach (NewsEntity item in NewsLst)
                {
                    //string title =SP.Common.LimitCharacters.Limit(item.Title, 35);
                    string des = LimitCharacters.Limit(item.Body, 60);
                    string siteURL = SPContext.Current.RootFolderUrl;

                    lblDrawItems.Text +=
                    string.Format(@"
                    <div class='newsitem'>
                        <div class='newsbox'>
                            <p class='date'>
                                {0}
                            </p>
                            <div class='imgdi'>
                                <img src='{1}' class='img-fluid' style='height: 110px!important;'/>
                                                </div>
                            <div class='descipt'>
                                {2}
                            </div>
                            <div class='morebtn'>
                                <a href='{5}/Details.aspx?id={4}&type=news' class='slide newmorebuttoncss arrow'>{3}
                                  </a>
                            </div>
                        </div>
                    </div>", Convert.ToDateTime(item.Created).ToString("MMM dd"), item.Picture, des, SPUtility.GetLocalizedString("$Resources: more", "Resource", SPContext.Current.Web.Language), item.ID,siteURL);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        //private string currentUserDepartment()
        //{
        //    string userDept = "";
        //    try
        //    {
        //        List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().GetCurrentEmployeeMasterDataByEmployeeNumber();
        //        foreach (EmployeeMasterDataEntity item in EmployeeValues)
        //        {
        //            userDept = item.departmentNameField_AR.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LoggingService.LogError("WebParts", ex.Message);
        //    }

        //    return userDept;
        //}
        #endregion Methods
    }
}
