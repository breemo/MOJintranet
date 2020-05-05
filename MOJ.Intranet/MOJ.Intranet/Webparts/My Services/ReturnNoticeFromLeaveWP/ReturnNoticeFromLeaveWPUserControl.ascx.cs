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

namespace MOJ.Intranet.Webparts.My_Services.ReturnNoticeFromLeaveWP
{
    public partial class ReturnNoticeFromLeaveWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                GetDropDown();
            }
        }
       
            private void GetDropDown()
        {
            
            List<LeavesListObject> data1 = new LeaveBalanceDataManager().RETURN_FROM_LEAVE_LIST(Enumber.Value);


            DropDownApprovedVacation.DataSource = data1;

               
        DropDownApprovedVacation.DataValueField = "absenceID";
         
           
                DropDownApprovedVacation.DataTextField = "description";
               
            
            
            DropDownApprovedVacation.DataBind();
           

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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                string RecordPrfix = "";
                RecordPrfix = "ReturnFromLeave-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("ReturnFromLeave");
                ReturnFromLeaveEntity itemSumbit = new ReturnFromLeaveEntity();
                itemSumbit.Title = RecordPrfix;
                itemSumbit.AbsenceID = DropDownApprovedVacation.SelectedValue.ToString();
                itemSumbit.Description = DropDownApprovedVacation.SelectedItem.Text;
                
                if (!string.IsNullOrEmpty(ReturnDateFromVacation.Value))
                {
                    DateTime sDate = DateTime.ParseExact(ReturnDateFromVacation.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    itemSumbit.ReturnDateFromVacation = sDate;
                }
               
                itemSumbit.RreasonForTheDelay = RreasonForTheDelay.Value.ToString();


                PushFAHRLeaveApplicationRequestDataManager PushFAHRL = new PushFAHRLeaveApplicationRequestDataManager();

                string isSavedwebserves = PushFAHRL.PushReturnFromLeaveRequest(Enumber.Value, itemSumbit.AbsenceID, itemSumbit.ReturnDateFromVacation.ToString("dd/MM/yyyy"), itemSumbit.RreasonForTheDelay);
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
                ReturnFromLeave rb = new ReturnFromLeave();
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
