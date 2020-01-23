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
using System.IO;
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
                DateTime Date = new DateTime();
                if (!string.IsNullOrEmpty(from.Value))
                {
                    DateTime sDate = DateTime.ParseExact(from.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    Date = sDate;
                    itemSumbit.FromDate = Date;
                }
                DateTime Date2 = new DateTime();
                if (!string.IsNullOrEmpty(to.Value))
                {
                    DateTime sDate2 = DateTime.ParseExact(to.Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    Date2 = sDate2;
                    itemSumbit.ToDate = Date2;
                }
                PushFAHRLeaveApplicationRequestDataManager PushLeave = new PushFAHRLeaveApplicationRequestDataManager();
                string fromdate = Date.ToString("yyy-MM-dd");
                string todate = Date2.ToString("yyy-MM-dd");
                string Vacation = "";
                string fileType = "";
                string fileName = "";
                byte[] fileContents=null;
                RequestAVacation Vacationobj = new RequestAVacation();
                if (FileUploadControl.HasFile)
                {
                    Stream fs = FileUploadControl.PostedFile.InputStream;
                    fileContents = new byte[fs.Length];
                    fs.Read(fileContents, 0, (int)fs.Length);
                    fs.Close();
                     fileName = "File_" + Path.GetFileName(FileUploadControl.PostedFile.FileName);
                    string  fileType1 =  Path.GetFileName(FileUploadControl.FileName);
                    string[] fileTypearr = fileType1.Split('.');
                    fileType = fileTypearr[1];
                    itemSumbit.fileName = fileName;
                    itemSumbit.fileContents = fileContents;                    
                }

                if (!string.IsNullOrEmpty(DropDownVacationsTypes.SelectedValue.ToString()))
                {
                    Vacation = Vacationobj.GetVacationsTypesCode(Convert.ToInt32(DropDownVacationsTypes.SelectedValue));
                }
                string isSavedwebserves = PushLeave.PushFAHRLeaveApplicationRequest(
                    Enumber.Value, Notes.Value.ToString(), fromdate, todate, Vacation, fileName, fileType, fileContents);
                bool isSaved = false;
                if (isSavedwebserves == "SUCCESS")
                {
                    itemSumbit.ResponseMsg = "Success";
                    itemSumbit.ResponseMsgAR = "نجح الارسال";
                    RequestAVacation rb = new RequestAVacation();

                     isSaved = rb.SaveUpdate(itemSumbit);
                }
                else
                {
                    itemSumbit.ResponseMsg = isSavedwebserves;
                    itemSumbit.ResponseMsgAR = "فشل الارسال";
                    if (isSavedwebserves=="HR absence cannot be zero")
                    {
                        MSG.InnerText = "** " + isSavedwebserves  + " : holiday " + " **";
                    }
                    else
                    {
                        MSG.InnerText = "** " + isSavedwebserves + " **";
                    }                 

                }                
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
