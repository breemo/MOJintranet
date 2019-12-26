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

namespace MOJ.Intranet.Webparts.KnowledgeGateway.knowledgeCouncilWP
{
    public partial class knowledgeCouncilWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetCouncilType();
                currentUserData();
                

            }

        }
        private void GetCouncilType()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            DataTable dataC = new knowledgeCouncil().GetCouncilType();
            DropDownCouncilType.DataSource = dataC;
            DropDownCouncilType.DataValueField = "ID";
            if (languageCode == "ar")
            {
                DropDownCouncilType.DataTextField = "Title";
            }
            else
            {
                DropDownCouncilType.DataTextField = "TitleEN";
            }

            DropDownCouncilType.DataBind();


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
                    EDirectManager.Value = item.ManagerName_DirectManager.ToString();
                    if (languageCode == "ar")
                    {
                        Ename.Value = item.employeeNameArabicField.ToString();
                        EDepartment.Value = item.departmentNameField_AR.ToString();
                        EPosition.Value = item.positionNameField_US.ToString();
                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();
                        EDepartment.Value = item.departmentNameField_AR.ToString();
                        EPosition.Value = item.positionNameField_US.ToString();
                       
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
                    string RecordPrfix = "";
                   RecordPrfix = "knowledgeCouncil-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("knowledgeCouncil");
                    knowledgeCouncilEntity itemSumbit = new knowledgeCouncilEntity();
                    DateTime CouncilDate1 = new DateTime();
                    if (!string.IsNullOrEmpty(CouncilDate.Value))
                    {
                        DateTime sDate = DateTime.ParseExact(CouncilDate.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        CouncilDate1 = sDate;
                    }
                    itemSumbit.CouncilDate = CouncilDate1;
                    itemSumbit.CouncilTarget = CouncilTarget.Value;
                    itemSumbit.CouncilTopic = CouncilTopic.Value;
                    itemSumbit.CouncilType = DropDownCouncilType.SelectedValue;
                    itemSumbit.Department = EDepartment.Value;
                    itemSumbit.DirectManager = EDirectManager.Value;
                    itemSumbit.EmployeeName = Ename.Value;
                    itemSumbit.EmployeeNumber = Enumber.Value;
                    itemSumbit.JoiningConditions = JoiningConditions.Value;
                    itemSumbit.Title = RecordPrfix;
                    itemSumbit.Designation = EPosition.Value;
                    knowledgeCouncil Ass = new knowledgeCouncil();
                    bool isSaved = Ass.SaveUpdate(itemSumbit);  
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
