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

namespace MOJ.Intranet.Webparts.My_Services.PeriodicalFormForGovernmentHousingWP
{
    public partial class PeriodicalFormForGovernmentHousingWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                GetChoices();

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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.HusbandORWifeUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice Choice0 = (SPFieldChoice)lst.Fields["HusbandORWife"];
                                    for (int i = 0; i < Choice0.Choices.Count; i++)
                                    {
                                        RBHusbandORWife.Items.Add(Choice0.Choices[i].ToString());
                                    }
                                    SPFieldChoice Choice1 = (SPFieldChoice)lst.Fields["workSector"];
                                    for (int i = 0; i < Choice1.Choices.Count; i++)
                                    {
                                        WorkSector0.Items.Add(Choice1.Choices[i].ToString());
                                    }
                                }

                                SPList lstSons = oWeb.GetListFromUrl(oSite.Url + SharedConstants.SonsUrl);
                                if (lstSons != null)
                                {
                                    SPFieldChoice Choice = (SPFieldChoice)lstSons.Fields["Gender"];
                                    for (int i = 0; i < Choice.Choices.Count; i++)
                                    {
                                        Gender0.Items.Add(Choice.Choices[i].ToString());
                                    }

                                    SPFieldChoice Choice2 = (SPFieldChoice)lstSons.Fields["Career"];
                                    for (int i = 0; i < Choice2.Choices.Count; i++)
                                    {
                                        Career0.Items.Add(Choice2.Choices[i].ToString());
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
                    EFinancialNumber.Value = "";
                    EWorkLocation.Value = "";
                    ECategory.Value = "";
                    EBasicSalary.Value = "";// item.positionNameField_AR.ToString();
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
                    RecordPrfix = "Periodical-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("PeriodicalFormForGovernmentHousing");
                    PeriodicalFormForGovernmentHousingEntity itemSumbit = new PeriodicalFormForGovernmentHousingEntity();

                    itemSumbit.HusbandORWife = RBHusbandORWife.SelectedValue;
                    itemSumbit.ContractNumber = ContractNumber.Value;
                    itemSumbit.ApartmentNumber = ApartmentNumber.Value;
                    itemSumbit.Owner = Owner.Value;
                    itemSumbit.NumberOfRooms = NumberOfRooms.Value;
                    itemSumbit.ACtype = ACtype.Value;
                    itemSumbit.LeasingContractEndDate = LeasingContractEndDate.Value;
                    itemSumbit.Mobile = Mobile.Value;
                    itemSumbit.HomePhone = HomePhone.Value;
                    itemSumbit.WorkPhone = WorkPhone.Value;
                    itemSumbit.RequestNumber = RecordPrfix;

                    PeriodicalFormForGovernmentHousing Ass = new PeriodicalFormForGovernmentHousing();
                    bool isSaved = Ass.SaveUpdate(itemSumbit);
                    List<SonsEntity> listChildren = new List<SonsEntity>();
                    SonsEntity sons = new SonsEntity();
                    if (!string.IsNullOrEmpty(ChildrenName0.Value))
                    {
                        sons.RequestNumber = RecordPrfix;
                        sons.age = Age0.Value;
                        sons.Name = ChildrenName0.Value;
                        sons.Gender = Gender0.SelectedValue;
                        sons.Career = Career0.SelectedValue;
                        sons.BasicSalary = SBasicSalary0.Value;
                        sons.LastEntryDate = SLastEntryDate0.Value;
                        sons.LastExitDate = SLastExitDate0.Value;
                        sons.HousingAllowance = HousingAllowance0.Checked;
                        listChildren.Add(sons);
                    }
                    if (hdnChildren.Value != "")
                    {
                        string[] ChildrenName = Request.Form.GetValues("ChildrenName");
                        string[] age = Request.Form.GetValues("Age");
                        string[] GenderR = Request.Form.GetValues("Gender");
                        string[] Career = Request.Form.GetValues("Career");
                        string[] SBasicSalary = Request.Form.GetValues("SBasicSalary");
                        string[] SLastEntryDate = Request.Form.GetValues("SLastEntryDate");
                        string[] SLastExitDate = Request.Form.GetValues("SLastExitDate");

                        for (int x = 0; x < Convert.ToInt32(ChildrenName.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(ChildrenName[x]))
                            {
                                SonsEntity sonsob = new SonsEntity();
                                sonsob.RequestNumber = RecordPrfix;
                                sonsob.age = age[x];
                                sonsob.Name = ChildrenName[x];
                                sonsob.Gender = GenderR[x];
                                sonsob.BasicSalary = SBasicSalary[x];
                                sonsob.LastEntryDate = SLastEntryDate[x];
                                sonsob.LastExitDate = SLastExitDate[x];
                                if (Request.Form["HousingAllowance" + x] != null && Request.Form["HousingAllowance" + x] == "on")
                                {
                                    sonsob.HousingAllowance = true;
                                }
                                else
                                {
                                    sonsob.HousingAllowance = false;
                                }
                                listChildren.Add(sonsob);
                            }
                        }
                    }
                    Ass.SaveUpdateChildren(listChildren);
                    /////////////////////////////////////////////////////////////////////
                    List<HusbandORWifeEntity> listHusbandORWife = new List<HusbandORWifeEntity>();
                    if (!string.IsNullOrEmpty(Name0.Value))
                    {
                        HusbandORWifeEntity HusbandORWife = new HusbandORWifeEntity();
                        HusbandORWife.RequestNumber = RecordPrfix;
                        HusbandORWife.workSector = WorkSector0.SelectedValue;
                        HusbandORWife.Name = Name0.Value;
                        HusbandORWife.HusbandORWife = RBHusbandORWife.SelectedValue;
                        HusbandORWife.HiringDate = HiringDate0.Value;
                        HusbandORWife.BasicSalary = BasicSalary0.Value;
                        HusbandORWife.LastEntryDate = LastEntryDate0.Value;
                        HusbandORWife.LastExitDate = LastExitDate0.Value;
                        HusbandORWife.HasGovernmentHousingPercentageAllowance = HasGovernmentHousingPercentageAllowance0.Checked;
                        listHusbandORWife.Add(HusbandORWife);
                    }
                    if (hdnHusbandORWife.Value != "")
                    {
                        string[] Name = Request.Form.GetValues("Name");
                        string[] HiringDate = Request.Form.GetValues("HiringDate");
                        string[] WorkSector = Request.Form.GetValues("WorkSector");
                        string[] BasicSalary = Request.Form.GetValues("BasicSalary");
                        string[] LastEntryDate = Request.Form.GetValues("LastEntryDate");
                        string[] LastExitDate = Request.Form.GetValues("LastExitDate");
                        for (int x = 0; x < Convert.ToInt32(Name.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Name[x]))
                            {
                                HusbandORWifeEntity HusbandORWifeitems = new HusbandORWifeEntity();
                                HusbandORWifeitems.RequestNumber = RecordPrfix;
                                HusbandORWifeitems.workSector = WorkSector[x];
                                HusbandORWifeitems.Name = Name[x];
                                HusbandORWifeitems.HusbandORWife = RBHusbandORWife.SelectedValue;
                                HusbandORWifeitems.BasicSalary = BasicSalary[x];
                                HusbandORWifeitems.HiringDate = HiringDate[x];
                                HusbandORWifeitems.LastEntryDate = LastEntryDate[x];
                                HusbandORWifeitems.LastExitDate = LastExitDate[x];
                                if (Request.Form["HasGovernmentHousingPercentageAllowance" + x] != null && Request.Form["HasGovernmentHousingPercentageAllowance" + x] == "on")
                                {
                                    HusbandORWifeitems.HasGovernmentHousingPercentageAllowance = true;
                                }
                                else
                                {
                                    HusbandORWifeitems.HasGovernmentHousingPercentageAllowance = false;

                                }
                                listHusbandORWife.Add(HusbandORWifeitems);
                            }
                        }
                    }
                    Ass.SaveUpdateHusbandORWife(listHusbandORWife);
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
