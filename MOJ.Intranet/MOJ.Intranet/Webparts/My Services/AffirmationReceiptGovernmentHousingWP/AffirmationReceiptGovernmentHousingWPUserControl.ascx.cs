using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.AffirmationReceiptGovernmentHousingWP
{
    public partial class AffirmationReceiptGovernmentHousingWPUserControl : UserControl
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
                    EHiringDate.Value = item.employementDateField.ToString();
                    EEmail.Value = item.employeeEmailField.ToString();
                    if (languageCode == "ar")
                    {
                        Ename.Value = item.employeeNameArabicField.ToString();
                        Edepartment.Value = item.departmentNameField_AR.ToString();
                        ENationality.Value = item.nationality_ARField.ToString();
                        EMaritalStatus.Value = item.maritalStatus_ARField.ToString();
                      }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();
                        Edepartment.Value = item.departmentNameField_US.ToString();
                        ENationality.Value = item.nationality_USField.ToString();
                        EMaritalStatus.Value = item.maritalStatus_USField.ToString();
                    }
                    EFinancialNumber.Value = "";/////////
                    Ecategory.Value = "";/////
                    EWorklocation.Value = "";////
                    EBWorkPhoneEx.Value = "";/////
                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string RecordPrfix = "";
                RecordPrfix = "ReceiptGHousing -" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("AffirmationReceiptGovernmentHousing");
                AffirmationReceiptGovernmentHousingEntity itemSumbit = new AffirmationReceiptGovernmentHousingEntity();

                itemSumbit.MobileNumber = MobileNumber.Value;
                if (!string.IsNullOrEmpty(ApportionmentDate.Value))
                {
                    DateTime sDate = DateTime.ParseExact(ApportionmentDate.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                  
                    itemSumbit.ApportionmentDate = sDate;
                }

                
                itemSumbit.HomeAddress = HomeAddress.Value;
                itemSumbit.VilaApartmentNumber = VilaApartmentNumber.Value;
                itemSumbit.NumberOfRooms = NumberOfRooms.Value;
                itemSumbit.Owner = Owner.Value;
                itemSumbit.agent = agent.Value;
                itemSumbit.RequestNumber = RecordPrfix;

                AffirmationReceiptGovernmentHousing ARGH = new AffirmationReceiptGovernmentHousing();
                bool isSaved = ARGH.SaveUpdate(itemSumbit);
                
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
