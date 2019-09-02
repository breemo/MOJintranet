﻿using CommonLibrary;
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

namespace MOJ.Intranet.Webparts.My_Services.ContactWithHRWP
{
    public partial class ContactWithHRWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                currentUserData();
                GetChoices();

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

                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();

                    }

                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void GetChoices()
        {
           
                try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ContactWithHRUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice Choice0 = (SPFieldChoice)lst.Fields["ContactReason"];
                                    for (int i = 0; i < Choice0.Choices.Count; i++)
                                    {
                                        RBContactReason.Items.Add(Choice0.Choices[i].ToString());
                                    }

                                }

                            }
                        }
                    }
                });
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
                    string RecordPrfix = "";
                    RecordPrfix = "ContactHR-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("ContactWithHR");
                    ContactWithHREntity itemSumbit = new ContactWithHREntity();
                    itemSumbit.Message = Message.Value;
                    itemSumbit.ContactReason = RBContactReason.SelectedValue;
                    itemSumbit.RequestNumber = RecordPrfix;
                    ContactWithHR obitem = new ContactWithHR();
                    bool isSaved = obitem.SaveUpdate(itemSumbit);
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
