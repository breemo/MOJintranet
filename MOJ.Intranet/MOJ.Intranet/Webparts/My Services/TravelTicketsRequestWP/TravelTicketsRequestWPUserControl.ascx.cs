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

namespace MOJ.Intranet.Webparts.My_Services.TravelTicketsRequestWP
{
    public partial class TravelTicketsRequestWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                txtDate.Value = DateTime.Now.ToString("yyyy, MMM dd");
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
                            RecordPrfix = "TravelTicketsRequest-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("TravelTicketsRequest");

                            try
                            {
                                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                                {
                                    using (SPWeb oWeb = oSite.RootWeb)
                                    {
                                        if (oWeb != null)
                                        {
                                            SPList oList = oWeb.Lists[SharedConstants.TravelTicketsRequest];
                                            if (oList != null)
                                            {
                                                oWeb.AllowUnsafeUpdates = true;
                                                SPListItem oSPListItem = oList.Items.Add();
                                                oSPListItem["Title"] = Convert.ToString(RecordPrfix);
                                                oSPListItem["Description"] = txtDescription.Value;

                                                oSPListItem["OrderType"] = rbType.SelectedValue;
                                                oSPListItem["TravelFrom"] = txtTravelFrom.Value;
                                                oSPListItem["TravelTo"] = txtTravelTo.Value;
                                                oSPListItem["ReturnTo"] = txtReturnTo.Value;

                                                oSPListItem["TicketFor"] = rblTicketFor.SelectedValue;
                                                oSPListItem["wife"] = txtwifefld.Value;
                                                oSPListItem["son1"] = txtSon1.Value;
                                                oSPListItem["son2"] = Son2.Value;
                                                oSPListItem["son3"] = Son3.Value;

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
                        EPosition.Value = item.positionNameField_AR.ToString();
                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();
                        EDepartment.Value = item.departmentNameField_US.ToString();
                        EPosition.Value = item.positionNameField_US.ToString();
                    }
                    mangerName = item.ManagerName_DirectManager.ToString();
                    mangerID = item.ManagerID_DirectManager.ToString();
                    mangerEmail = item.ManagerEmail_DirectManager;
                    employeeName = item.departmentNameField_AR.ToString() + "," + item.employeeNameEnglishField.ToString();
                    employeeID = item.employeeNumberField.ToString();
                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        protected void rbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbType.SelectedValue == "TicketsAllowance")
                dvTicketFor.Visible = true;
            else
            {
                dvTicketFor.Visible = false;

                dvwifefld.Visible = false;
                dvson1.Visible = false;
                dvson2.Visible = false;
                dvson3.Visible = false;
            }
        }

        protected void rblTicketFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTicketFor.SelectedValue.ToLower().Contains("family"))
            {
                dvwifefld.Visible = true;
                dvson1.Visible = true;
                dvson2.Visible = true;
                dvson3.Visible = true;
            }
            else
            {
                dvwifefld.Visible = false;
                dvson1.Visible = false;
                dvson2.Visible = false;
                dvson3.Visible = false;
            }
        }
    }
}
