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

namespace MOJ.Intranet.Webparts.KnowledgeGateway.ImplicitKnowledgeWP
{
    public partial class ImplicitKnowledgeWPUserControl : SiteUI
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                EmploymentHistoryData();
                GetCountrys();
                QualificationsData();
                LanguageSkillsData();
                TechnicalSkillsData();
                Getlevels();
            }
        }


          private void LanguageSkillsData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<LanguageSkillsEntity> QualificationsData = objIK.GeteLanguageSkills(currentUserlogin);
                int x = 0;
                foreach (LanguageSkillsEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID03.Value = item.ID.ToString();
                        RetrevehdnsuperDIV3.Value = item.ID.ToString() + "#";
                        Language0.Value = item.Language.ToString();
                        DropDownReadingLevel.SelectedValue = item.ReadinglevelID.ToString();
                        DropDownWritingLevel.SelectedValue = item.WritinglevelID.ToString();
                        DropDownConversationLevel.SelectedValue = item.ConversationlevelID.ToString();
                    }
                    else
                    {
                        hdnsuperDIV3.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV3.Value += item.ID.ToString() + "#";
                        CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                        DataTable dataC = new ImplicitKnowledge().Getlevels();
                        string options = "";
                        string selct = "";
                        string options2 = "";
                        string selct2 = "";
                        string options3 = "";
                        string selct3 = "";
                        foreach (DataRow dtRow in dataC.Rows)
                        {
                            if (dtRow["ID"].ToString()== item.ReadinglevelID.ToString())
                            {
                                selct= "selected='selected'";
                            }
                            else
                            {
                                selct = "";
                            }
                            if (dtRow["ID"].ToString() == item.WritinglevelID.ToString())
                            {
                                selct2 = "selected='selected'";
                            }
                            else
                            {
                                selct2 = "";
                            }
                            if (dtRow["ID"].ToString() == item.ConversationlevelID.ToString())
                            {
                                selct3 = "selected='selected'";
                            }
                            else
                            {
                                selct3= "";
                            }
                            if (languageCode == "ar")
                            {                                
                                options += "<option "+ selct + " value='" +dtRow["ID"].ToString()+"'>" + dtRow["Title"].ToString() + "</option>";
                                options2 += "<option "+ selct2 + " value='" +dtRow["ID"].ToString()+"'>" + dtRow["Title"].ToString() + "</option>";
                                options3 += "<option "+ selct3 + " value='" +dtRow["ID"].ToString()+"'>" + dtRow["Title"].ToString() + "</option>";
                            }
                            else
                            {
                                options += "<option " + selct + " value='" + dtRow["ID"].ToString() + "'>" + dtRow["TitleEN"].ToString() + "</option>";
                                options2 += "<option " + selct2 + " value='" + dtRow["ID"].ToString() + "'>" + dtRow["TitleEN"].ToString() + "</option>";
                                options3 += "<option " + selct3 + " value='" + dtRow["ID"].ToString() + "'>" + dtRow["TitleEN"].ToString() + "</option>";
                            }
                         }
                        var htmlrow1 = "<div class='rowI'> <hr><div class='row rt'>" +
            "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowLanguageSkills(this);'>" +
            "<span class='icon-remove'></span></span></div>" +
                    "<div class='row rt'>" +
                        "<div class='DivSID3' style=' display: none;'><input name='SID3' value='" + item.ID.ToString() + "' type='text' id='SID3" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivLanguage'><input name='Language' value='" + item.Language.ToString() + "' type='text' id='Language" + x + "' class='form-control' placeholder=''></div>" +
                       "<div class='col-md-3 DivReadingLevel '>" +
                        "<select name='DropDownReadingLevel' id='DropDownReadingLevel" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                        "<div class='col-md-3 DivWritingLevel '>" +
                        "<select name='DropDownWritingLevel' id='DropDownWritingLevel" + x + "' class='form-control'>" +
                          options2 +
                        "</select></div>" +
                        "<div class='col-md-3 DivConversationLevel '>" +
                        "<select name='DropDownConversationLevel' id='DropDownConversationLevel" + x + "' class='form-control'>" +
                          options3 +
                        "</select></div>" +
                    "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV3.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void TechnicalSkillsData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<TechnicalSkillsEntity> QualificationsData = objIK.GeteTechnicalSkills(currentUserlogin);
                int x = 0;
                foreach (TechnicalSkillsEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID04.Value = item.ID.ToString();
                        RetrevehdnsuperDIV4.Value = item.ID.ToString() + "#";
                        SkillType0.Value = item.SkillType.ToString();
                        DropDownSkillLevell.SelectedValue = item.SkilllevelID.ToString();
                        AreaOfApplication0.Value = item.AreaOfApplication.ToString();
                        Notes04.Value = item.Notes.ToString();
                    }
                    else
                    {
                        hdnsuperDIV4.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV4.Value += item.ID.ToString() + "#";
                        CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                        DataTable dataC = new ImplicitKnowledge().Getlevels();
                        string options = "";
                        string selct = "";
                                              
                        foreach (DataRow dtRow in dataC.Rows)
                        {
                            if (dtRow["ID"].ToString() == item.SkilllevelID.ToString())
                            {
                                selct = "selected='selected'";
                            }
                            else
                            {
                                selct = "";
                            }
                           
                            if (languageCode == "ar")
                            {
                                options += "<option " + selct + " value='" + dtRow["ID"].ToString() + "'>" + dtRow["Title"].ToString() + "</option>";
                           }
                            else
                            {
                                options += "<option " + selct + " value='" + dtRow["ID"].ToString() + "'>" + dtRow["TitleEN"].ToString() + "</option>";
                            }
                        }
                        var htmlrow1 = "<div class='rowI'> <hr><div class='row rt'>" +
            "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTechnicalSkills(this);'>" +
            "<span class='icon-remove'></span></span></div>" +
                    "<div class='row rt'>" +
                        "<div class='DivSID4' style=' display: none;'><input name='SID4' value='" + item.ID.ToString() + "' type='text' id='SID4" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivSkillType'><input name='SkillType' value='" + item.SkillType.ToString() + "' type='text' id='SkillType" + x + "' class='form-control' placeholder=''></div>" +
                       "<div class='col-md-3 DivSkillLevel '>" +
                        "<select name='DropDownSkillLevel' id='DropDownSkillLevel" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                          "<div class='col-md-3 DivAreaOfApplication'><input name='AreaOfApplication' value='" + item.AreaOfApplication.ToString() + "' type='text' id='AreaOfApplication" + x + "' class='form-control' placeholder=''></div>" +
                            "<div class='col-md-3 DivNotes4'><input name='Notes4' value='" + item.Notes.ToString() + "' type='text' id='Notes4" + x + "' class='form-control' placeholder=''></div>" +
                           "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV4.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }


        private void Getlevels() 
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            DataTable dataL = new ImplicitKnowledge().Getlevels();
            DropDownReadingLevel.DataSource = dataL;
            DropDownReadingLevel.DataValueField = "ID";
            DropDownWritingLevel.DataSource = dataL;
            DropDownWritingLevel.DataValueField = "ID";
            DropDownConversationLevel.DataSource = dataL;
            DropDownConversationLevel.DataValueField = "ID";
            DropDownSkillLevell.DataSource = dataL;
            DropDownSkillLevell.DataValueField = "ID";
            if (languageCode == "ar")
            {
                DropDownReadingLevel.DataTextField = "Title";
                DropDownWritingLevel.DataTextField = "Title";
                DropDownConversationLevel.DataTextField = "Title";
                DropDownSkillLevell.DataTextField = "Title";
            }
            else
            {
                DropDownReadingLevel.DataTextField = "TitleEN";
                DropDownWritingLevel.DataTextField = "TitleEN";
                DropDownConversationLevel.DataTextField = "TitleEN";
                DropDownSkillLevell.DataTextField = "TitleEN";
            }

            DropDownReadingLevel.DataBind();
            DropDownWritingLevel.DataBind();
            DropDownConversationLevel.DataBind();
            DropDownSkillLevell.DataBind();


        }

        private void QualificationsData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<QualificationsEntity> QualificationsData = objIK.GeteQualifications(currentUserlogin);
                int x = 0;
                foreach (QualificationsEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID02.Value = item.ID.ToString();
                        RetrevehdnsuperDIV2.Value = item.ID.ToString() + "#";
                        Qualification0.Value = item.Qualification.ToString();
                        Major0.Value = item.Major.ToString();
                        Institution0.Value = item.Institution.ToString();
                        DropDownCountry.SelectedValue = item.CountryID.ToString();
                        GraduationYear0.Value = item.GraduationYear.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        hdnsuperDIV2.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV2.Value += item.ID.ToString() + "#";                       CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                        DataTable dataC = new ImplicitKnowledge().GetCountrys();
                        string options = "";
                        string selct = "";
                        foreach (DataRow dtRow in dataC.Rows)
                        {
                            if (dtRow["ID"].ToString()== item.CountryID.ToString())
                            {
                                selct= "selected='selected'";
                            }
                            else
                            {
                                selct = "";
                            }
                            if (languageCode == "ar")
                            {
                                
                                options += "<option "+ selct + " value='" +dtRow["ID"].ToString()+"'>" + dtRow["Title"].ToString() + "</option>";
                            }
                            else
                            {
                                options += "<option " + selct + " value='" + dtRow["ID"].ToString() + "'>" + dtRow["TitleEN"].ToString() + "</option>";

                            }
                         }
                        var htmlrow1 = "<div class='rowI'> <hr><div class='row rt'>" +
            "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowQualifications(this);'>" +
            "<span class='icon-remove'></span></span></div>" +
                    "<div class='row rt'>" +
                        "<div class='DivSID2' style=' display: none;'><input name='SID2' value='" + item.ID.ToString() + "' type='text' id='SID2" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivQualification'><input name='Qualification' value='" + item.Qualification.ToString() + "' type='text' id='Qualification" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivMajor'><input name='Major' value='" + item.Major.ToString() + "' type='text' id='Major" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivInst itution'><input name='Institution' value='" + item.Institution.ToString() + "' type='text'' id='Institution" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivCountry '>" +
                        "<select name='DropDownCountry' id='DropDownCountry" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                        "	<div class='col-md-3 '>" +
                            "	<div class='input-group date DivGraduationYear' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.GraduationYear.ToString("MM/dd/yyyy") + "'  name='GraduationYear' type='text' id='GraduationYear1' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                    "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV2.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void GetCountrys()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            DataTable dataC = new ImplicitKnowledge().GetCountrys();
            DropDownCountry.DataSource = dataC;
            DropDownCountry.DataValueField = "ID";
            if (languageCode == "ar")
            {
                DropDownCountry.DataTextField = "Title";
            }
            else
            {
                DropDownCountry.DataTextField = "TitleEN";
            }

            DropDownCountry.DataBind();


        }
        private void EmploymentHistoryData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<EmploymentHistoryEntity> EmploymentHistory = objIK.GeteEmploymentHistory(currentUserlogin);
                int x = 0;
                foreach (EmploymentHistoryEntity item in EmploymentHistory)
                {
                    if (x == 0) {
                         SID0.Value = item.ID.ToString();
                        RetrevehdnsuperDIV1.Value=item.ID.ToString()+ "#" ;
                         Organizationalunit0.Value = item.OrganizationalUnit.ToString();
                         Designation0.Value = item.Designation.ToString();
                         Datefrom0.Value = item.DateFrom.ToString("MM/dd/yyyy");
                         Dateto0.Value = item.DateTo.ToString("MM/dd/yyyy");                        
                    }
                    else
                    {
                        hdnsuperDIV1.Value =Convert.ToString(x);
                        
                        RetrevehdnsuperDIV1.Value += item.ID.ToString() + "#";
                        var htmlrow1 = "<div class='rowI'> <hr><div class='row rt'>" +
                            "<span style='padding-right: 25px; margin-top: -15px; ' onclick='removerowEmploymenthistory(this); '>" +
                            "<span class='icon-remove'></span></span></div>" +
                    "<div class='row rt'>" +
                                   "<div class=' DivSID' style=' display: none;'>" +
                                     "<input name='SID' type='text' value='" + item.ID.ToString() + "' id='SID" + x + "' class='form-control' placeholder=''>" +
                                    "</div>" +
                            "<div class='col-md-3 DivDesignation'><input name='Designation' value='" + item.Designation.ToString() + "' type='text'' id='Designation" + x + "' class='form-control' placeholder=''>" +
                            "</div>" +
                                "<div class='col-md-3 DivOrganizationalunit'><input name='Organizationalunit' value='" + item.OrganizationalUnit.ToString() + "' type='text'' id='Organizationalunit" + x + "' class='form-control' placeholder=''>" +
                                "</div> " +
                                    "<div class='col-md-3 '>" +
                                    "	<div class='input-group date DivDatefrom' data-provide='datepicker'><input autocomplete='off' value='" + item.DateFrom.ToString("MM/dd/yyyy") + "' name='Datefrom' type='text' id='Datefrom" + x + "' class='form-control'>" +
                                    "<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                                     "</div>" +
                                    "<div class='col-md-3 '>" +
                                    "<div class='input-group date DivDateto' data-provide='datepicker'><input value='" + item.DateTo.ToString("MM/dd/yyyy") + "' autocomplete='off' name='Dateto' type='text' id='Dateto" + x + "' class='form-control'>" +
                                    "<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                         " </div></div></div>";

                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV1.Controls.Add(newDiv);

                    }
                    x++;
                }
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
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                ImplicitKnowledgeEntity Employment = objIK.GetImplicitKnowledge(currentUserlogin);
                if (Employment.ID > 0)
                {
                    TOPID.Value = Employment.ID.ToString();
                    Enumber.Value = Employment.EmployeeNumber.ToString();
                    EDateOfBirth.Value = Employment.DateOfBirth.ToString();
                    Ename.Value = Employment.Name.ToString();
                    ENationality.Value = Employment.Nationality.ToString();
                    EPosition.Value = Employment.Designation.ToString();
                    EMaritalStatus.Value = Employment.MaritalStatus.ToString();
                }
                else
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
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                try
                {
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                    //////////////////////////////////1///////////////////////
                    int PID = 0;
                    if (string.IsNullOrEmpty(TOPID.Value))
                    {
                        ImplicitKnowledgeEntity itemSumbit = new ImplicitKnowledgeEntity();
                        itemSumbit.UserName = currentUserlogin;
                        itemSumbit.Name = Ename.Value;
                        itemSumbit.DateOfBirth = EDateOfBirth.Value;
                        itemSumbit.Designation = EPosition.Value;
                        itemSumbit.EmployeeNumber = Enumber.Value;
                        itemSumbit.MaritalStatus = EMaritalStatus.Value;
                        itemSumbit.Nationality = ENationality.Value;
                        PID = objIK.SaveUpdate(itemSumbit);
                    }
                    else
                    {
                        PID = Convert.ToInt32(TOPID.Value);
                    }
                    //////////////////////////////////2///////////////////////
                    List<EmploymentHistoryEntity> list1 = new List<EmploymentHistoryEntity>();
                    EmploymentHistoryEntity Entit1 = new EmploymentHistoryEntity();
                    if (!string.IsNullOrEmpty(Designation0.Value))
                    {
                        DateTime Datefrom = new DateTime();
                        if (!string.IsNullOrEmpty(Datefrom0.Value))
                        {
                            DateTime sDate = DateTime.ParseExact(Datefrom0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Datefrom = sDate;
                        }
                        DateTime Dateto = new DateTime();
                        if (!string.IsNullOrEmpty(Dateto0.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(Dateto0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Dateto = sDate2;
                        }
                        Entit1.DateFrom = Datefrom;
                        Entit1.DateTo = Dateto;
                        Entit1.Designation = Designation0.Value;
                        Entit1.OrganizationalUnit = Organizationalunit0.Value;
                        Entit1.PID = PID;
                        if (!string.IsNullOrEmpty(SID0.Value))
                        {
                            Entit1.ID = Convert.ToInt32(SID0.Value);
                            RetrevehdnsuperDIV1.Value = RetrevehdnsuperDIV1.Value.Replace(Entit1.ID + "#", "");
                        }
                        Entit1.Title = currentUserlogin;
                        list1.Add(Entit1);
                    }
                    if (hdnsuperDIV1.Value != "")
                    {
                        string[] SID = Request.Form.GetValues("SID");
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
                                DateTime Datefroma = new DateTime();
                                if (!string.IsNullOrEmpty(Datefrom[x]))
                                {
                                    DateTime sDate = DateTime.ParseExact(Datefrom[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Datefroma = sDate;
                                }
                                DateTime Datetoa = new DateTime();
                                if (!string.IsNullOrEmpty(Dateto[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(Dateto[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Datetoa = sDate2;
                                }
                                ob.DateFrom = Datefroma;
                                ob.DateTo = Datetoa;
                                ob.Designation = Designation[x];
                                ob.OrganizationalUnit = Organizationalunit[x];
                                if (!string.IsNullOrEmpty(SID[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID[x]);
                                    RetrevehdnsuperDIV1.Value = RetrevehdnsuperDIV1.Value.Replace(ob.ID + "#", "");
                                 }
                                list1.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateEmploymentHistory(list1);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV1.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV1.Value.Split('#');
                        List<int> ListSID1 = new List<int>();
                        foreach (string sid in SIDES)
                        {
                            if(Int32.TryParse(sid, out int numValue)){
                                ListSID1.Add(Int32.Parse(sid));
                            }                    
                        }
                        if (ListSID1.Count > 0)
                        {
                            objIK.DeleteitemsFromSublist("EmploymentHistory", ListSID1);
                        }
                    }

                    //////////////////////////////////3///////////////////////
                    List<QualificationsEntity> list2 = new List<QualificationsEntity>();
                    QualificationsEntity Entit2 = new QualificationsEntity();
                    if (!string.IsNullOrEmpty(Qualification0.Value))
                    {                       
                        DateTime Date = new DateTime();
                        if (!string.IsNullOrEmpty(GraduationYear0.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(GraduationYear0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date = sDate2;
                        }
                        Entit2.GraduationYear = Date;
                        Entit2.Qualification = Qualification0.Value;
                        Entit2.Major = Major0.Value;
                        Entit2.Institution = Institution0.Value;
                        Entit2.CountryID = DropDownCountry.SelectedValue.ToString();                        
                        Entit2.PID = PID;
                        if (!string.IsNullOrEmpty(SID02.Value))
                        {
                            Entit2.ID = Convert.ToInt32(SID02.Value);
                            RetrevehdnsuperDIV2.Value = RetrevehdnsuperDIV2.Value.Replace(Entit2.ID + "#", "");
                        }
                        Entit2.Title = currentUserlogin;
                        list2.Add(Entit2);
                    }
                    if (hdnsuperDIV2.Value != "")
                    {
                        string[] SID2 = Request.Form.GetValues("SID2");
                        string[] Qualification = Request.Form.GetValues("Qualification");
                        string[] Major = Request.Form.GetValues("Major");
                        string[] Institution = Request.Form.GetValues("Institution");
                        string[] GraduationYear = Request.Form.GetValues("GraduationYear");
                        string[] DropDownCountry = Request.Form.GetValues("DropDownCountry");
                        for (int x = 0; x < Convert.ToInt32(Qualification.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Qualification[x]))
                            {
                                QualificationsEntity ob = new QualificationsEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;                                
                                DateTime Date = new DateTime();
                                if (!string.IsNullOrEmpty(GraduationYear[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(GraduationYear[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date = sDate2;
                                }
                                ob.GraduationYear = Date;

                               
                                ob.Qualification = Qualification[x];
                                ob.Major = Major[x];
                                ob.Institution = Institution[x];
                                ob.CountryID = DropDownCountry[x];
                                if (!string.IsNullOrEmpty(SID2[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID2[x]);
                                    RetrevehdnsuperDIV2.Value = RetrevehdnsuperDIV2.Value.Replace(ob.ID + "#", "");
                                }
                                list2.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateQualifications(list2);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV2.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV2.Value.Split('#');
                        List<int> ListSID1 = new List<int>();
                        foreach (string sid in SIDES)
                        {
                            if (Int32.TryParse(sid, out int numValue))
                            {
                                ListSID1.Add(Int32.Parse(sid));
                            }
                        }
                        if (ListSID1.Count > 0)
                        {
                            objIK.DeleteitemsFromSublist("Qualifications", ListSID1);
                        }
                    }
                    //////////////////////////////////4///////////////////////

                    List<LanguageSkillsEntity> list3 = new List<LanguageSkillsEntity>();
                    LanguageSkillsEntity Entit3 = new LanguageSkillsEntity();
                    if (!string.IsNullOrEmpty(Language0.Value))
                    {
                        Entit3.Language = Language0.Value;
                        Entit3.ReadinglevelID = DropDownReadingLevel.SelectedValue.ToString(); ;
                        Entit3.WritinglevelID = DropDownWritingLevel.SelectedValue.ToString(); ;
                        Entit3.ConversationlevelID = DropDownConversationLevel.SelectedValue.ToString();
                        Entit3.PID = PID;
                        if (!string.IsNullOrEmpty(SID03.Value))
                        {
                            Entit3.ID = Convert.ToInt32(SID03.Value);
                            RetrevehdnsuperDIV3.Value = RetrevehdnsuperDIV2.Value.Replace(Entit3.ID + "#", "");
                        }
                        Entit3.Title = currentUserlogin;
                        list3.Add(Entit3);
                    }
                    if (hdnsuperDIV3.Value != "")
                    {
                        string[] SID3 = Request.Form.GetValues("SID3");
                        string[] Language = Request.Form.GetValues("Language");
                        string[] DropDownReadingLevel = Request.Form.GetValues("DropDownReadingLevel");
                        string[] DropDownWritingLevel = Request.Form.GetValues("DropDownWritingLevel");
                        string[] DropDownConversationLevel = Request.Form.GetValues("DropDownConversationLevel");
                        for (int x = 0; x < Convert.ToInt32(Language.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Language[x]))
                            {
                                LanguageSkillsEntity ob = new LanguageSkillsEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                               
                                ob.Language = Language[x];
                                ob.ReadinglevelID = DropDownReadingLevel[x];
                                ob.WritinglevelID = DropDownWritingLevel[x];
                                ob.ConversationlevelID = DropDownConversationLevel[x];
                                if (!string.IsNullOrEmpty(SID3[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID3[x]);
                                    RetrevehdnsuperDIV3.Value = RetrevehdnsuperDIV3.Value.Replace(ob.ID + "#", "");
                                }
                                list3.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateLanguageSkills(list3);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV3.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV3.Value.Split('#');
                        List<int> ListSID1 = new List<int>();
                        foreach (string sid in SIDES)
                        {
                            if (Int32.TryParse(sid, out int numValue))
                            {
                                ListSID1.Add(Int32.Parse(sid));
                            }
                        }
                        if (ListSID1.Count > 0)
                        {
                            objIK.DeleteitemsFromSublist("LanguageSkills", ListSID1);
                        }
                    }
                    //////////////////////////////////5///////////////////////


                    List<TechnicalSkillsEntity> list4 = new List<TechnicalSkillsEntity>();
                    TechnicalSkillsEntity Entit4 = new TechnicalSkillsEntity();
                    if (!string.IsNullOrEmpty(SkillType0.Value))
                    {
                        Entit4.SkillType = SkillType0.Value;
                        Entit4.SkilllevelID = DropDownSkillLevell.SelectedValue.ToString(); ;
                        Entit4.AreaOfApplication = AreaOfApplication0.Value.ToString(); ;
                        Entit4.Notes = Notes04.Value.ToString();
                        Entit4.PID = PID;
                        if (!string.IsNullOrEmpty(SID04.Value))
                        {
                            Entit4.ID = Convert.ToInt32(SID04.Value);
                            RetrevehdnsuperDIV4.Value = RetrevehdnsuperDIV2.Value.Replace(Entit4.ID + "#", "");
                        }
                        Entit4.Title = currentUserlogin;
                        list4.Add(Entit4);
                    }
                    if (hdnsuperDIV4.Value != "")
                    {
                        string[] SID4 = Request.Form.GetValues("SID4");
                        string[] SkillType = Request.Form.GetValues("SkillType");
                        string[] DropDownSkillLevell = Request.Form.GetValues("DropDownSkillLevell");
                        string[] AreaOfApplication = Request.Form.GetValues("AreaOfApplication");
                        string[] Notes4 = Request.Form.GetValues("Notes4");
                        for (int x = 0; x < Convert.ToInt32(SkillType.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(SkillType[x]))
                            {
                                TechnicalSkillsEntity ob = new TechnicalSkillsEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                ob.SkillType = SkillType[x];
                                ob.SkilllevelID = DropDownSkillLevell[x];
                                ob.AreaOfApplication = AreaOfApplication[x];
                                ob.Notes = Notes4[x];
                                if (!string.IsNullOrEmpty(SID4[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID4[x]);
                                    RetrevehdnsuperDIV4.Value = RetrevehdnsuperDIV4.Value.Replace(ob.ID + "#", "");
                                }
                                list4.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateTechnicalSkills(list4);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV4.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV4.Value.Split('#');
                        List<int> ListSID1 = new List<int>();
                        foreach (string sid in SIDES)
                        {
                            if (Int32.TryParse(sid, out int numValue))
                            {
                                ListSID1.Add(Int32.Parse(sid));
                            }
                        }
                        if (ListSID1.Count > 0)
                        {
                            objIK.DeleteitemsFromSublist("TechnicalSkills", ListSID1);
                        }
                    }
                    //////////////////////////////////6///////////////////////






                    if (PID>0)
                    {
                        lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />";
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
