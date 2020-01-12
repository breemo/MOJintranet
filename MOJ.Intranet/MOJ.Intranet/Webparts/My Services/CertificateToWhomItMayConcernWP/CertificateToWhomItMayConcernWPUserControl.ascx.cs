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

namespace MOJ.Intranet.Webparts.My_Services.CertificateToWhomItMayConcernWP
{
    public partial class CertificateToWhomItMayConcernWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                GetDropDown();
            }
        }
        private void GetDropDown() { 
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            DataTable data1 = new CertificateToWhomItMayConcern().GetOrganizationType();
            DataTable data2 = new CertificateToWhomItMayConcern().GetRequestType();
            DataTable data3 = new CertificateToWhomItMayConcern().GetSpeechLanguage();
            DataTable data4 = new CertificateToWhomItMayConcern().GetSpeechType();
            DataTable data5 = new CertificateToWhomItMayConcern().GetTravelCountry();
          
            DropDownOrganizationType.DataSource = data1;
            DropDownRequestType.DataSource = data2;
            DropDownSpeechLanguage.DataSource = data3;
            DropDownSpeechType.DataSource = data4;
            DropDownTravelCountry.DataSource = data5;

            DropDownOrganizationType.DataValueField = "ID";
            DropDownRequestType.DataValueField = "ID";
            DropDownSpeechLanguage.DataValueField = "ID";
            DropDownSpeechType.DataValueField = "ID";
            DropDownTravelCountry.DataValueField = "ID";
            if (languageCode == "ar")
            {               
                DropDownOrganizationType.DataTextField = "Title";
                DropDownRequestType.DataTextField = "Title";
                DropDownSpeechLanguage.DataTextField = "Title";
                DropDownSpeechType.DataTextField = "Title";
                DropDownTravelCountry.DataTextField = "Title";
            }
            else
            {               
                DropDownOrganizationType.DataTextField = "TitleEN";
                DropDownRequestType.DataTextField = "TitleEN";
                DropDownSpeechLanguage.DataTextField = "TitleEN";
                DropDownSpeechType.DataTextField = "TitleEN";
                DropDownTravelCountry.DataTextField = "TitleEN";
            }         
            DropDownOrganizationType.DataBind();
            DropDownRequestType.DataBind();
            DropDownSpeechLanguage.DataBind();
            DropDownSpeechType.DataBind();
            DropDownTravelCountry.DataBind();

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
                RecordPrfix = "Certificate-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("CertificateToWhomItMayConcern");
                CertificateToWhomItMayConcernEntity itemSumbit = new CertificateToWhomItMayConcernEntity();
                itemSumbit.Title = RecordPrfix;
                itemSumbit.OrganizationType = DropDownOrganizationType.SelectedValue.ToString();
                itemSumbit.RequestType = DropDownRequestType.SelectedValue.ToString();
                itemSumbit.SpeechLanguage = DropDownSpeechLanguage.SelectedValue.ToString();
                itemSumbit.SpeechType = DropDownSpeechType.SelectedValue.ToString();
                itemSumbit.TravelCountry = DropDownTravelCountry.SelectedValue.ToString();
                itemSumbit.TheSpeechDirectedTo = TheSpeechDirectedTo.Value.ToString();
                             
                //PushFAHRLeaveApplicationRequestDataManager PushLeave = new PushFAHRLeaveApplicationRequestDataManager();
                //string fromdate = Convert.ToDateTime(from.Value).ToString("yyy-MM-dd");
                //string todate = Convert.ToDateTime(to.Value).ToString("yyy-MM-dd");

                bool isSavedwebserves = false;// = PushLeave.PushFAHRLeaveApplicationRequest(Enumber.Value, Notes.Value.ToString(), fromdate, todate);
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
                CertificateToWhomItMayConcern rb = new CertificateToWhomItMayConcern();
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
