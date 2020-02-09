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
using System.IO;

namespace MOJ.Intranet.Webparts.My_Services.AffirmationSocialSituation
{
    public partial class AffirmationSocialSituationUserControl : SiteUI
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
                    EHiringDate.Value = item.employementDateField.ToString();
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
                    EDegree.Value = "";// item.employementDateField.ToString(); 

                    EBasicSalary.Value = "";// item.positionNameField_AR.ToString();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.HusbandORWifeUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice Choice0 = (SPFieldChoice)lst.Fields["HusbandORWife"];
                                    for (int i = 0; i < Choice0.Choices.Count; i++)
                                    {
                                        string text = Choice0.Choices[i].ToString();
                                        string Choicetrim = text.Replace(" ", "");
                                        var placetext = SPUtility.GetLocalizedString("$Resources: " + Choicetrim, "Resource", SPContext.Current.Web.Language);
                                        placetext = "<span class='radio-button-circle'></span>" + placetext;
                                        RBHusbandORWife.Items.Add(new ListItem(placetext, Choice0.Choices[i].ToString()));

                                       
                                    }
                                    SPFieldChoice Choice1 = (SPFieldChoice)lst.Fields["workSector"];
                                    for (int i = 0; i < Choice1.Choices.Count; i++)
                                    {
                                        string text = Choice1.Choices[i].ToString();
                                        string Choicetrim = text.Replace(" ", "");
                                        var placetext = SPUtility.GetLocalizedString("$Resources: " + Choicetrim, "Resource", SPContext.Current.Web.Language);
                                        placetext = "<span class='radio-button-circle'></span>" + placetext;
                                        WorkSector0.Items.Add(new ListItem(placetext, Choice1.Choices[i].ToString()));

                                       
                                    }
                                }

                                SPList lstSons = oWeb.GetListFromUrl(oSite.Url + SharedConstants.SonsUrl);
                                if (lstSons != null)
                                {
                                    SPFieldChoice Choice = (SPFieldChoice)lstSons.Fields["Gender"];
                                    for (int i = 0; i < Choice.Choices.Count; i++)
                                    {
                                        string text = Choice.Choices[i].ToString();
                                        string Choicetrim = text.Replace(" ", "");
                                        var placetext = SPUtility.GetLocalizedString("$Resources: " + Choicetrim, "Resource", SPContext.Current.Web.Language);
                                        placetext = "<span class='radio-button-circle'></span>" + placetext;
                                        Gender0.Items.Add(new ListItem(placetext, Choice.Choices[i].ToString()));

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
                    RecordPrfix = "Social-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("AffirmationSocialSituation");
                    AffirmationSocialSituationEntity itemSumbit = new AffirmationSocialSituationEntity();

                    itemSumbit.ChangeDate = ChangeDate.Value;
                    itemSumbit.ChangeReason = ChangeReason.Value;
                    itemSumbit.HusbandORWife = RBHusbandORWife.SelectedValue;
                    itemSumbit.Name = txtName.Value;
                    itemSumbit.RelationshipType = RelationshipType.Value;
                    itemSumbit.RequestNumber = RecordPrfix;

                    string fileName = "";
                    string fileType = "";
                    byte[] fileContents = null;
                  
                    if (FileUploadControl.HasFile)
                    {
                        Stream fs = FileUploadControl.PostedFile.InputStream;
                        fileContents = new byte[fs.Length];
                        fs.Read(fileContents, 0, (int)fs.Length);
                        fs.Close();
                        fileName = "File_" + Path.GetFileName(FileUploadControl.PostedFile.FileName);
                        string fileType1 = Path.GetFileName(FileUploadControl.FileName);
                        string[] fileTypearr = fileType1.Split('.');
                        fileType = fileTypearr[1];
                        itemSumbit.fileName = fileName;
                        itemSumbit.fileContents = fileContents;
                    }

                    AffirmationSocialSituationB Ass = new AffirmationSocialSituationB();
                    bool isSaved = Ass.SaveUpdate(itemSumbit);
                    List<SonsEntity> listChildren = new List<SonsEntity>();
                    SonsEntity sons = new SonsEntity();
                    if (!string.IsNullOrEmpty(ChildrenName0.Value))
                    {
                        sons.RequestNumber = RecordPrfix;
                        sons.age = Age0.Value;
                        sons.Name = ChildrenName0.Value;
                        sons.Gender = Gender0.SelectedValue;
                        sons.HousingAllowance = false;

                        listChildren.Add(sons);
                    }
                    if (hdnChildren.Value != "")
                    {
                        string[] ChildrenName = Request.Form.GetValues("ChildrenName");
                        string[] age = Request.Form.GetValues("Age");
                        string[] GenderR = Request.Form.GetValues("Gender");
                        for (int x = 0; x < Convert.ToInt32(ChildrenName.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(ChildrenName[x]))
                            {
                                SonsEntity sonsob = new SonsEntity();
                                sonsob.RequestNumber = RecordPrfix;
                                sonsob.age = age[x];
                                sonsob.Name = ChildrenName[x];
                                sonsob.Gender = GenderR[x];
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
                        HusbandORWife.Employer = Employer0.Value;
                        HusbandORWife.HiringDate = HiringDate0.Value;
                        HusbandORWife.DateOfMarriage = DateMarriage0.Value;
                        HusbandORWife.HasGovernmentHousingAllowance = HasGovernmentHousingAllowance0.Checked;
                        HusbandORWife.HasGovernmentHousingPercentageAllowance = HasGovernmentHousingPercentageAllowance0.Checked;


                        listHusbandORWife.Add(HusbandORWife);
                    }
                    if (hdnHusbandORWife.Value != "")
                    {
                        string[] Name = Request.Form.GetValues("Name");
                        string[] DateMarriage = Request.Form.GetValues("DateMarriage");
                        string[] Employer = Request.Form.GetValues("Employer");
                        string[] WorkSector = Request.Form.GetValues("WorkSector");
                        string[] HiringDate = Request.Form.GetValues("HiringDate");
                        for (int x = 0; x < Convert.ToInt32(Name.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Name[x]))
                            {
                                HusbandORWifeEntity HusbandORWifeitems = new HusbandORWifeEntity();
                                HusbandORWifeitems.RequestNumber = RecordPrfix;
                                HusbandORWifeitems.workSector = WorkSector[x];
                                HusbandORWifeitems.Name = Name[x];
                                HusbandORWifeitems.HusbandORWife = RBHusbandORWife.SelectedValue;
                                HusbandORWifeitems.Employer = Employer[x];
                                HusbandORWifeitems.HiringDate = HiringDate[x];
                                HusbandORWifeitems.DateOfMarriage = DateMarriage[x];
                                if (Request.Form["HasGovernmentHousingAllowance" + x] != null && Request.Form["HasGovernmentHousingAllowance" + x] == "on")
                                {
                                    HusbandORWifeitems.HasGovernmentHousingAllowance = true;
                                }
                                else
                                {
                                    HusbandORWifeitems.HasGovernmentHousingAllowance = false;
                                }
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
