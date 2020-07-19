using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.DeclarationWifeNotWorkWP
{
    public partial class DeclarationWifeNotWorkWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                try
                {
                    savecurrentUserData();
                    using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb myweb = mySitesCollection.OpenWeb())
                        {
                            SPUser currentUser = myweb.CurrentUser;
                            bool isInserted = false;

                            string RecordPrfix = "";
                            RecordPrfix = "DeclarationWifeNotWork-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("DeclarationWifeNotWork");

                            try
                            {
                                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                                {
                                    using (SPWeb oWeb = oSite.RootWeb)
                                    {
                                        if (oWeb != null)
                                        {
                                            SPList oList = oWeb.Lists[SharedConstants.DeclarationWifeNotWork];
                                            if (oList != null)
                                            {
                                                oWeb.AllowUnsafeUpdates = true;
                                                SPListItem oSPListItem = oList.Items.Add();
                                                oSPListItem["Title"] = Convert.ToString(RecordPrfix);
                                                oSPListItem["WifeName"] = txtMyWifeName.Value;
                                                oSPListItem["Created By"] = currentUser;
                                                oSPListItem.Update();
                                                isInserted = true;
                                                oWeb.AllowUnsafeUpdates = false;
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LoggingService.LogError("WebParts", ex.Message);
                            }
                            if (isInserted == true)
                            {
                                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                                posts.Style.Add("display", "none");
                                SuccessMsgDiv.Style.Add("display", "block");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }

        public string mangerName
        {
            get
            {
                if (ViewState["mangerName"] != null)
                {
                    return Convert.ToString(ViewState["mangerName"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["mangerName"] = value; }
        }
        public string mangerID
        {
            get
            {
                if (ViewState["mangerID"] != null)
                {
                    return Convert.ToString(ViewState["mangerID"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["mangerID"] = value; }
        }
        public string mangerEmail
        {
            get
            {
                if (ViewState["mangerEmail"] != null)
                {
                    return Convert.ToString(ViewState["mangerEmail"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["mangerEmail"] = value; }
        }
        private void currentUserData()
        {
            try
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().GetCurrentEmployeeMasterDataByEmployeeNumber();
                foreach (EmployeeMasterDataEntity item in EmployeeValues)
                {
                    Enumber.Value = item.employeeNumberField.ToString();

                    if (languageCode == "ar")
                    {
                        Ename.Value = item.employeeNameArabicField.ToString();
                        EDepartment.Value = item.departmentNameField_AR.ToString();
                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();
                        EDepartment.Value = item.departmentNameField_US.ToString();
                    }
                    mangerName = item.ManagerName_DirectManager.ToString();
                    mangerID = item.ManagerID_DirectManager.ToString();
                    mangerEmail = item.ManagerEmail_DirectManager;

                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void savecurrentUserData()
        {
            try
            {
                EmployeeEntity EmployeeValues = new EmployeeEntity();
                EmployeeValues.mangerName = mangerName;

                EmployeeValues.mangerID = mangerID;
                EmployeeValues.mangerEmail = mangerEmail;
                EmployeeValues.AccountName = SPContext.Current.Web.CurrentUser.LoginName;
                if (mangerName != null && mangerName != "")
                {
                    bool Emp = new Employee().SaveUpdate(EmployeeValues);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
