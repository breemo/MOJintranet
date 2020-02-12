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

namespace MOJ.Intranet.Webparts.CarOrderServiceWP
{
    public partial class CarOrderServiceWPUserControl : SiteUI
    {
        private static int _CarNumber = 000001;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                TravelNeeds();
               

            }
        }



        private void TravelNeeds()
        {
            try
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();

                var word1 = "WithDriver";
                var placetext = SPUtility.GetLocalizedString("$Resources: "+ word1, "Resource", SPContext.Current.Web.Language);
                placetext = "<span class='radio-button-circle'></span>" + placetext;
                cbTravelNeedsR.Items.Add(new ListItem(placetext, word1));
                var word2 = "WithoutDriver";
                 placetext = SPUtility.GetLocalizedString("$Resources: " + word2, "Resource", SPContext.Current.Web.Language);
                placetext = "<span class='radio-button-circle'></span>" + placetext;
                cbTravelNeedsR.Items.Add(new ListItem(placetext, word2));
                var word3 = "insideAbuDhabi";
                 placetext = SPUtility.GetLocalizedString("$Resources: " + word3, "Resource", SPContext.Current.Web.Language);
                placetext = "<span class='radio-button-circle'></span>" + placetext;
                cbTravelNeedsR.Items.Add(new ListItem(placetext, word3));
                var word4 = "outsideAbuDhabi";
                 placetext = SPUtility.GetLocalizedString("$Resources: " + word4, "Resource", SPContext.Current.Web.Language);
                placetext = "<span class='radio-button-circle'></span>" + placetext;
                cbTravelNeedsR.Items.Add(new ListItem(placetext, word4));



            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
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

        public static string GetNextCarRequestNumber()
        {
            _CarNumber++;
            return _CarNumber.ToString();
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

                            string RecordPrfix = "";
                            RecordPrfix = "Car-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("CarOrderService");
                            string TravelNeedsValues = string.Empty;
                            string tPassengerNames = string.Empty;
                            //foreach (ListItem item in this.cbTravelNeedsR.Items)
                            //    if (item.Selected)
                            //        TravelNeedsValues += item + ",";
                            TravelNeedsValues = cbTravelNeedsR.SelectedValue;
                            DateTime TravelDate = new DateTime(); ;

                            if (!string.IsNullOrEmpty(txtTravelDate.Value))
                            {
                                DateTime sDate = DateTime.ParseExact(txtTravelDate.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                string[] pmSdate = txtBookingTimeFrom.Value.Split(' ');
                                TimeSpan tsSdate = TimeSpan.Parse(pmSdate[0]);
                                sDate = (pmSdate[1] == "PM") ? (sDate.Date + tsSdate).AddHours(12) : sDate.Date + tsSdate;

                                TravelDate = sDate;
                            }

                            if (hdnPassenger.Value != "")
                                tPassengerNames += String.Format("{0}", Request.Form["Passenger"] + ",");

                            tPassengerNames += txtPassengerName0.Value;

                            bool AddCarRequest = new CarOrderServiceBL().AddCarOrderServic(currentUser, RecordPrfix, TravelNeedsValues, txtTravelTo.Value,
                                tPassengerNames, txtTravelReson.Value, txtCarPlace.Value, TravelDate, txtduration.Value);

                            if (AddCarRequest == true)
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
