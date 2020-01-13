﻿using CommonLibrary;
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

namespace MOJ.Intranet.Webparts.My_Services.RequestAVacationWP
{
    public partial class RequestAVacationWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                GetDropDownVacationsTypes();
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

        private void GetDropDownVacationsTypes()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            DataTable dataC = new RequestAVacation().GetVacationsTypes();
            DropDownVacationsTypes.DataSource = dataC;
            DropDownVacationsTypes.DataValueField = "ID";
            if (languageCode == "ar")
            {
                DropDownVacationsTypes.DataTextField = "Title";
            }
            else
            {
                DropDownVacationsTypes.DataTextField = "TitleEN";
            }

            DropDownVacationsTypes.DataBind();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                string RecordPrfix = "";
                RecordPrfix = "RequestAVacation-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("RequestAVacation");
                RequestAVacationEntity itemSumbit = new RequestAVacationEntity();
                itemSumbit.Title = RecordPrfix;
                itemSumbit.VacationType = DropDownVacationsTypes.SelectedValue.ToString();
                itemSumbit.SubstituteEmployee = AlternateEmployee.Value.ToString();
                itemSumbit.Comments = Notes.Value.ToString();
                if (!string.IsNullOrEmpty(from.Value))
                {
                    DateTime sDate = DateTime.ParseExact(from.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    itemSumbit.FromDate = sDate;
                }
                if (!string.IsNullOrEmpty(to.Value))
                {
                    DateTime sDate2 = DateTime.ParseExact(to.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    itemSumbit.ToDate = sDate2;
                }
                PushFAHRLeaveApplicationRequestDataManager PushLeave = new PushFAHRLeaveApplicationRequestDataManager();
                string fromdate = Convert.ToDateTime(from.Value).ToString("yyy-MM-dd");
                string todate = Convert.ToDateTime(to.Value).ToString("yyy-MM-dd");
               
                bool isSavedwebserves = PushLeave.PushFAHRLeaveApplicationRequest(Enumber.Value, Notes.Value.ToString(), fromdate, todate);
                if (isSavedwebserves == true)
                {
                    itemSumbit.ResponseMsg = "Success";
                    itemSumbit.ResponseMsgAR = "نجح الارسال";
                }
                else
                {
                    itemSumbit.ResponseMsg = "Error";
                    itemSumbit.ResponseMsgAR = "فشل الارسال";

                }
                RequestAVacation rb = new RequestAVacation();
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