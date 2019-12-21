﻿using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MOJ.DataManager;
using MOJ.Business;
using Microsoft.SharePoint.Utilities;
using System.Collections.Generic;
using System.Threading;
using MOJ.Intranet.Classes.Common;
using MOJ.Entities.ImplicitKnowledge;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.ImplicitKnowledgeWP
{
    public partial class ImplicitKnowledgeWPUserControl : SiteUI
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
                    EDateOfBirth.Value = item.dateOfBirthField.ToString();
                   
                    if (languageCode == "ar")
                    {
                        Ename.Value = item.employeeNameArabicField.ToString();
                        ENationality.Value = item.nationality_ARField.ToString();
                        EPosition.Value = item.positionNameField_AR.ToString();
                        EMaritalStatus.Value = item.maritalStatus_ARField.ToString();
                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();
                        ENationality.Value = item.nationality_USField.ToString();
                        EPosition.Value = item.positionNameField_US.ToString();
                        EMaritalStatus.Value = item.maritalStatus_USField.ToString();
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
                try
                {         
                 string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;           
                    ImplicitKnowledgeEntity itemSumbit = new ImplicitKnowledgeEntity();
                    itemSumbit.UserName = currentUserlogin;
                    itemSumbit.Name =Ename.Value ;
                    itemSumbit.DateOfBirth =EDateOfBirth.Value ;
                    itemSumbit.Designation = EPosition.Value ;
                    itemSumbit.EmployeeNumber = Enumber.Value ;
                    itemSumbit.MaritalStatus =EMaritalStatus.Value ;
                    itemSumbit.Nationality =ENationality.Value ;
                    ImplicitKnowledge objIK = new ImplicitKnowledge();
                    int PID = objIK.SaveUpdate(itemSumbit);
                    List<EmploymentHistoryEntity> list1 = new List<EmploymentHistoryEntity>();
                    EmploymentHistoryEntity Entit1 = new EmploymentHistoryEntity();
                    if (!string.IsNullOrEmpty(Designation0.Value))
                    {
                        Entit1.DateFrom = Convert.ToDateTime(Datefrom0.Value);
                        Entit1.DateTo = Convert.ToDateTime(Dateto0.Value);
                        Entit1.Designation = Designation0.Value;
                        Entit1.OrganizationalUnit = Organizationalunit0.Value;
                        Entit1.PID = PID;
                        Entit1.Title = currentUserlogin;
                        list1.Add(Entit1);
                    }
                    if (hdnChildren.Value != "")
                    {
                        string[] Designation = Request.Form.GetValues("Designation");
                        string[] Organizationalunit = Request.Form.GetValues("Organizationalunit");
                        string[] Datefrom = Request.Form.GetValues("Datefrom");
                        string[] Dateto = Request.Form.GetValues("Dateto");
                        for (int x = 0; x < Convert.ToInt32(Designation.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Designation[x]))
                            {
                                EmploymentHistoryEntity ob = new EmploymentHistoryEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                ob.DateFrom = Convert.ToDateTime(Datefrom[x]);
                                ob.DateTo = Convert.ToDateTime(Dateto[x]);
                                ob.Designation = Designation[x];
                                ob.OrganizationalUnit = Organizationalunit[x];
                                list1.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateEmploymentHistory(list1);
                    if (PID>0)
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
