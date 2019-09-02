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

namespace MOJ.Intranet.Webparts.My_Services.FazaaCardRequestWP
{
    public partial class FazaaCardRequestWPUserControl :SiteUI
    {
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
                    EFullNameArabic.Value = item.employeeNameArabicField.ToString();
                    EFullNameEnglish.Value = item.employeeNameEnglishField.ToString();
                    if (languageCode == "ar")
                    {
                        EDepartment.Value = item.departmentNameField_AR.ToString();

                    }
                    else
                    {
                        EDepartment.Value = item.departmentNameField_US.ToString();

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
            if (!_isRefresh) { 
            try
            {
                string RecordPrfix = "";
                RecordPrfix = "Fazaa-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("FazaaCardRequest");
                FazaaCardRequestEntity itemSumbit = new FazaaCardRequestEntity();
                itemSumbit.Comment = Comment.Value;
                itemSumbit.RequestNumber = RecordPrfix;

                FazaaCardRequest FazaaCardRequesttem = new FazaaCardRequest();


                bool isSaved = FazaaCardRequesttem.SaveUpdate(itemSumbit);
                if (isSaved == true)
                {
                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                    posts.Style.Add("display", "none");
                    SuccessMsgDiv.Style.Add("display", "block");
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
