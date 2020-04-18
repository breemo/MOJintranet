using CommonLibrary;
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
using System.Data;
namespace MOJ.Intranet.Webparts.KnowledgeGateway.AskAnExpertQuestionWP
{
    public partial class AskAnExpertQuestionWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetDepartment();
                GetExpertName();
            }
        }

        private void GetExpertName()
        {
            try
            {
                DropDownExpertName.Items.Clear();
                AskAnExpert Esxpert = new AskAnExpert();
               List<ExpertsEntity> objExpert = Esxpert.GetExpertsFromTo(DropDownDepartment.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd"));
                    List<ListItem> items = new List<ListItem>();              
                items.Add(new ListItem("", ""));
                foreach (ExpertsEntity Expert in objExpert)
                {
                    items.Add(new ListItem(Expert.ExpertName, Convert.ToString(Expert.ID)));
                }
                DropDownExpertName.Items.AddRange(items.ToArray());              
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void GetDepartment()
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
                                SPList lst2 = oWeb.GetListFromUrl(oSite.Url + SharedConstants.DepartmentsUrl);
                                if (lst2 != null)
                                {
                                    List<ListItem> items = new List<ListItem>();
                                    items.Add(new ListItem("", ""));
                                    SPQuery qry1 = new SPQuery();
                                    string camlquery1 = "<Where></Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                    qry1.Query = camlquery1;
                                    SPListItemCollection listItemsCollection1 = lst2.GetItems(qry1);
                                    foreach (SPListItem Item in listItemsCollection1)
                                    {
                                        items.Add(new ListItem(Convert.ToString(Item["Title"]), Convert.ToString(Item["Title"])));
                                    }
                                    DropDownDepartment.Items.AddRange(items.ToArray());
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

        protected void myListDropDown_Change(object sender, EventArgs e)
        {
            GetExpertName();
        }  protected void ExpertName_Change(object sender, EventArgs e)
        {
            try
            {
                Topics.Value = "";
                if (!string.IsNullOrEmpty(DropDownExpertName.SelectedValue))
                {
                   
                    AskAnExpert Esxpert = new AskAnExpert();
                    ExpertsEntity objExpert = Esxpert.GetExpertsByID(Convert.ToInt32(DropDownExpertName.SelectedValue));
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                   
                    if (languageCode == "ar")
                    {
                        Topics.Value = objExpert.TopicsAR;
                    }
                    else
                    {
                        Topics.Value = objExpert.Topics;

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

                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                try
                {
                    string RecordPrfix = "";

                    AskAnExpertEntity AskAnExpert = new AskAnExpertEntity();
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().GetCurrentEmployeeMasterDataByEmployeeNumber();
                    foreach (EmployeeMasterDataEntity item in EmployeeValues)
                    {
                        if (languageCode == "ar")
                        {
                            AskAnExpert.EmployeeName = item.employeeNameArabicField.ToString();
                            AskAnExpert.EmployeePosition = item.positionNameField_AR.ToString();
                        }
                        else
                        {
                            AskAnExpert.EmployeeName = item.employeeNameEnglishField.ToString();
                            AskAnExpert.EmployeePosition = item.positionNameField_US.ToString();
                        }
                    }
                    AskAnExpert.Department = DropDownDepartment.SelectedValue;
                    //AskAnExpert.EmployeeLoginName = ;
                    AskAnExpert.ExpertID = DropDownExpertName.SelectedValue;
                    AskAnExpert.loginName = currentUserlogin;
                    AskAnExpert.QuestionDetails = QuestionDetails.Value;
                    AskAnExpert.StartWF = "1";
                    RecordPrfix = "AskAnExpert-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("AskAnExpert");

                    AskAnExpert.Title = RecordPrfix;
                    AskAnExpert.QuestionTitle = QuestionTitle.Value;

                    bool resalt = new AskAnExpert().AddOrUpdate(AskAnExpert);

                    if (resalt)
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
