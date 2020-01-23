using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.DataManager;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.ReturnToDutyNoticeMembersOfTheTudiciaryWP
{
    public partial class ReturnToDutyNoticeMembersOfTheTudiciaryWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                GetDays();
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

                    if (languageCode == "ar")
                    {
                        Ename.Value = item.employeeNameArabicField.ToString();

                        Edepartment.Value = item.departmentNameField_AR.ToString();

                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();

                        Edepartment.Value = item.employeeNameEnglishField.ToString();

                    }
                     


                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void GetDays()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            DataTable dataC = new ReturnToDutyNoticeMembersOfTheJudiciary().GetDays();
            DropDownDay.DataSource = dataC;
            DropDownDay.DataValueField = "ID";
            if (languageCode == "ar")
            {
                DropDownDay.DataTextField = "TitleAr";
            }
            else
            {
                DropDownDay.DataTextField = "Title";
            }

            DropDownDay.DataBind();


        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                string RecordPrfix = "";
                RecordPrfix = "ReturnNotice-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("ReturnToDutyNoticeMembersOfTheJudiciary");
                ReturnToDutyNoticeMembersOfTheJudiciaryEntity itemSumbit = new ReturnToDutyNoticeMembersOfTheJudiciaryEntity();
                itemSumbit.RequestNumber = RecordPrfix;
                itemSumbit.DayID = DropDownDay.SelectedValue.ToString();
                DateTime Date2 = new DateTime();
                if (!string.IsNullOrEmpty(Date.Value))
                {
                    DateTime sDate = DateTime.ParseExact(Date.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    Date2 = sDate;
                    itemSumbit.date = sDate;
                }
                string ResumeDate = Date2.ToString("yyy-MM-dd");
                ReturnFromLeaveServiceDataManager RLeave = new ReturnFromLeaveServiceDataManager();
                string isSavedwebserves = RLeave.ReturnFromLeaveService(Enumber.Value, "", ResumeDate);
                if (isSavedwebserves == "SUCCESS")
                {
                    itemSumbit.ResponseMsg = "Success";
                itemSumbit.ResponseMsgAR = "نجح الارسال";
                }
                else
                {
                    itemSumbit.ResponseMsg = isSavedwebserves;
                    itemSumbit.ResponseMsgAR = "فشل الارسال";

                }
               ReturnToDutyNoticeMembersOfTheJudiciary rb = new ReturnToDutyNoticeMembersOfTheJudiciary();
                bool isSaved = rb.SaveUpdate(itemSumbit);
                if (isSaved == true)
                {

                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                    posts.Style.Add("display", "none");
                    SuccessMsgDiv.Style.Add("display", "block");
                }
            }
        }
    }
}
