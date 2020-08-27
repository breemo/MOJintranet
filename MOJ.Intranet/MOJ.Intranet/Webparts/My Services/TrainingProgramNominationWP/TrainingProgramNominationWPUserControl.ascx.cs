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

namespace MOJ.Intranet.Webparts.My_Services.TrainingProgramNominationWP
{
    public partial class TrainingProgramNominationWPUserControl : SiteUI
    {
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
        public string employeeName
        {
            get
            {
                if (ViewState["employeeName"] != null)
                {
                    return Convert.ToString(ViewState["employeeName"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["employeeName"] = value; }
        }
        public string employeeID
        {
            get
            {
                if (ViewState["employeeID"] != null)
                {
                    return Convert.ToString(ViewState["employeeID"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["employeeID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
            }
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
                    EHiringDate.Value = item.employementDateField.ToString();
                    EEmail.Value = item.employeeEmailField.ToString();
                    if (languageCode == "ar")
                    {
                        Ename.Value = item.employeeNameArabicField.ToString();
                        Edepartment.Value = item.departmentNameField_AR.ToString();
                        ENationality.Value = item.nationality_ARField.ToString();
                        EPosition.Value = item.positionNameField_AR.ToString();
                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();
                        Edepartment.Value = item.departmentNameField_US.ToString();
                        ENationality.Value = item.nationality_USField.ToString();
                        EPosition.Value = item.positionNameField_US.ToString();
                    }
                    mangerName = item.ManagerName_DirectManager.ToString();
                    mangerID = item.ManagerID_DirectManager.ToString();
                    mangerEmail = item.ManagerEmail_DirectManager;
                    txtMobileNumber.Value = item.contactNumberField.ToString();

                    employeeName = item.departmentNameField_AR.ToString() + "," + item.employeeNameEnglishField.ToString();
                    employeeID = item.employeeNumberField.ToString();
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                try
                {
                    //savecurrentUserData();
                    using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb myweb = mySitesCollection.OpenWeb())
                        {
                            SPUser currentUser = myweb.CurrentUser;
                            bool isInserted = false;

                            string RecordPrfix = "";
                            RecordPrfix = "TrainingProgramNomination -" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("TrainingProgramNomination");

                            try
                            {
                                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                                {
                                    using (SPWeb oWeb = oSite.RootWeb)
                                    {
                                        if (oWeb != null)
                                        {
                                            SPList oList = oWeb.Lists[SharedConstants.TrainingProgramNomination];
                                            if (oList != null)
                                            {
                                                oWeb.AllowUnsafeUpdates = true;
                                                SPListItem oSPListItem = oList.Items.Add();
                                                oSPListItem["Title"] = Convert.ToString(RecordPrfix);
                                                oSPListItem["Created By"] = currentUser;
                                                oSPListItem["CourseTitle"] = txtProgramName.Value;
                                                oSPListItem["Location"] = txtProgramLocation.Value;

                                                DateTime CourseDateFrom = new DateTime(); ;

                                                if (!string.IsNullOrEmpty(ProgramDateFrom.Value))
                                                {
                                                    DateTime sDate = DateTime.ParseExact(ProgramDateFrom.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                                    string[] pmSdate = txtProgramTimeFrom.Value.Split(' ');
                                                    TimeSpan tsSdate = TimeSpan.Parse(pmSdate[0]);
                                                    sDate = (pmSdate[1] == "PM") ? (sDate.Date + tsSdate).AddHours(12) : sDate.Date + tsSdate;

                                                    CourseDateFrom = sDate;
                                                }

                                                DateTime CourseDateTo = new DateTime(); ;

                                                if (!string.IsNullOrEmpty(ProgramDateTo.Value))
                                                {
                                                    DateTime sDate2 = DateTime.ParseExact(ProgramDateTo.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                                    string[] pmSdate2 = txtProgramTimeTo.Value.Split(' ');
                                                    TimeSpan tsSdate2 = TimeSpan.Parse(pmSdate2[0]);
                                                    sDate2 = (pmSdate2[1] == "PM") ? (sDate2.Date + tsSdate2).AddHours(12) : sDate2.Date + tsSdate2;

                                                    CourseDateTo = sDate2;
                                                }

                                                oSPListItem["CourseDateFrom"] = Convert.ToDateTime(CourseDateFrom);
                                                oSPListItem["CourseDateTo"] = Convert.ToDateTime(CourseDateTo);
                                                oSPListItem["EmployeeName"] = employeeName;
                                                oSPListItem["EmployeeID"] = employeeID;

                                                oSPListItem["Qualification"] = txtQualification.Value;
                                                oSPListItem["ExtNo"] = txtExtNo.Value;

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
    }
}
