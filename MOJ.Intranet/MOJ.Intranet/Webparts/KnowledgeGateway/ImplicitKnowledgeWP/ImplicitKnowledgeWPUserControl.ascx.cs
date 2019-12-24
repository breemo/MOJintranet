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
                GetCountrys();
                Getlevels();
                WithinThePlan();
                currentUserData();
                EmploymentHistoryData();                
                QualificationsData();
                TrainingCoursesData();
                LanguageSkillsData();
                TechnicalSkillsData();
                OtherSkillsData();                
                ExpertiseData();
                PublicationsData();
                TravelInformationsData();
                ParticipationsData();
                MembershipData();
            }
        }
        private void ParticipationsData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<ParticipationsEntity> QualificationsData = objIK.GetParticipations(currentUserlogin);
                int x = 0;
                foreach (ParticipationsEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID010.Value = item.ID.ToString();
                        RetrevehdnsuperDIV10.Value = item.ID.ToString() + "#";
                        DropDownCountry10.SelectedValue = item.CountryID.ToString();
                        ActivityName0.Value = item.ActivityName.ToString();
                        Sponsor0.Value = item.Sponsor.ToString();
                        NatureOfTheParticipation0.Value = item.NatureOfTheParticipation.ToString();
                    }
                    else
                    {
                        hdnsuperDIV10.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV10.Value += item.ID.ToString() + "#"; CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                        DataTable dataC = new ImplicitKnowledge().GetCountrys();
                        string options = "";
                        string selct = "";
                        foreach (DataRow dtRow in dataC.Rows)
                        {
                            if (dtRow["ID"].ToString() == item.CountryID.ToString())
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
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID10' style=' display: none;'><input name='SID10' value='" + item.ID.ToString() + "' type='text' id='SID10" + x + "' class='form-control' placeholder=''></div> " +
                          "<div class='col-md-3 DivActivityName'><input name='ActivityName' value='" + item.ActivityName.ToString() + "' type='text' id='ActivityName" + x + "' class='form-control' placeholder=''></div>" +
                            "<div class='col-md-3 DivSponsor'><input name='Sponsor' value='" + item.Sponsor.ToString() + "' type='text' id='Sponsor" + x + "' class='form-control' placeholder=''></div>" +

                        "<div class='col-md-2 DivCountry '>" +
                        "<select name='DropDownCountry10' id='DropDownCountry10" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                        "<div class='col-md-3 DivNatureOfTheParticipation'><input name='NatureOfTheParticipation' value='" + item.NatureOfTheParticipation.ToString() + "' type='text' id='NatureOfTheParticipation" + x + "' class='form-control' placeholder=''></div>" +
                             "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowParticipations(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
                            "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV10.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void MembershipData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<MembershipEntity> QualificationsData = objIK.GetMembership(currentUserlogin);
                int x = 0;
                foreach (MembershipEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID011.Value = item.ID.ToString();
                        RetrevehdnsuperDIV11.Value = item.ID.ToString() + "#";
                        Membership0.Value = item.Membership.ToString();
                        Location0.Value = item.Location.ToString();
                        Field011.Value = item.Field.ToString();
                        FromDate011.Value = item.FromDate.ToString("MM/dd/yyyy");
                        ToDate011.Value = item.ToDate.ToString("MM/dd/yyyy");
                        Notes011.Value = item.Notes.ToString();
                    }
                    else
                    {
                        hdnsuperDIV11.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV11.Value += item.ID.ToString() + "#"; 
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID11' style=' display: none;'><input name='SID11' value='" + item.ID.ToString() + "' type='text' id='SID11" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivMembership'><input name='Membership' value='" + item.Membership.ToString() + "' type='text' id='Membership" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivLocation'><input name='Location' value='" + item.Location.ToString() + "' type='text' id='Location" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivField'><input name='Field11' value='" + item.Field.ToString() + "' type='text' id='Field11" + x + "' class='form-control' placeholder=''></div>" +
                        "	<div class='col-md-1 '>" +
                            "	<div class='input-group date DivFromDate' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.FromDate.ToString("MM/dd/yyyy") + "'  name='FromDate11' type='text' id='FromDate11" + x + "' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                            "	<div class='col-md-1 '>" +
                            "	<div class='input-group date DivToDate' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.ToDate.ToString("MM/dd/yyyy") + "'  name='ToDate11' type='text' id='ToDate11" + x + "' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                        "<div class='col-md-2 DivNotes'><input name='Notes11' value='" + item.Notes.ToString() + "' type='text' id='Notes11" + x + "' class='form-control' placeholder=''></div>" +
                             "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowMembership(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
                            "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV11.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void TravelInformationsData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<TravelInformationsEntity> QualificationsData = objIK.GetTravelInformations(currentUserlogin);
                int x = 0;
                foreach (TravelInformationsEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID09.Value = item.ID.ToString();
                        RetrevehdnsuperDIV9.Value = item.ID.ToString() + "#";
                        DropDownCountryResidentForMoreThan3Months.SelectedValue = item.CountryResidentForMoreThan3Month.ToString();
                        TimePeriodFrom0.Value = item.TimePeriodFrom.ToString("MM/dd/yyyy");
                        TimeperiodTo0.Value = item.TimeperiodTo.ToString("MM/dd/yyyy");
                        VisitReasons0.Value = item.VisitReasons.ToString();
                    }
                    else
                    {
                        hdnsuperDIV9.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV9.Value += item.ID.ToString() + "#"; CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                        DataTable dataC = new ImplicitKnowledge().GetCountrys();
                        string options = "";
                        string selct = "";
                        foreach (DataRow dtRow in dataC.Rows)
                        {
                            if (dtRow["ID"].ToString() == item.CountryResidentForMoreThan3Month.ToString())
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
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID9' style=' display: none;'><input name='SID9' value='" + item.ID.ToString() + "' type='text' id='SID9" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivCountryResidentForMoreThan3Months '>" +
                        "<select name='DropDownCountryResidentForMoreThan3Months' id='DropDownCountryResidentForMoreThan3Months" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                        "	<div class='col-md-2 '>" +
                            "	<div class='input-group date DivTimePeriodFrom' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.TimePeriodFrom.ToString("MM/dd/yyyy") + "'  name='TimePeriodFrom' type='text' id='TimePeriodFrom" + x + "' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                            "	<div class='col-md-2 '>" +
                            "	<div class='input-group date DivTimeperiodTo' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.TimeperiodTo.ToString("MM/dd/yyyy") + "'  name='TimeperiodTo' type='text' id='TimeperiodTo" + x + "' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +

                        "<div class='col-md-3 DivVisitReasons'><input name='VisitReasons' value='" + item.VisitReasons.ToString() + "' type='text' id='VisitReasons" + x + "' class='form-control' placeholder=''></div>" +
                        
                        
                             "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTravelInformations(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
                            "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV9.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void PublicationsData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<PublicationsEntity> QualificationsData = objIK.GetPublications(currentUserlogin);
                int x = 0;
                foreach (PublicationsEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID08.Value = item.ID.ToString();
                        RetrevehdnsuperDIV8.Value = item.ID.ToString() + "#";
                        BookPublicationTitle0.Value = item.BookPublicationTitle.ToString();
                        Topic0.Value = item.Topic.ToString();
                        PublishDate0.Value = item.PublishDate.ToString("MM/dd/yyyy");
                        Notes08.Value = item.Notes.ToString();
                    }
                    else
                    {
                        hdnsuperDIV8.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV8.Value += item.ID.ToString() + "#";
                       
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID8' style=' display: none;'><input name='SID8' value='" + item.ID.ToString() + "' type='text' id='SID8" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivBookPublicationTitle'><input name='BookPublicationTitle' value='" + item.BookPublicationTitle.ToString() + "' type='text' id='BookPublicationTitle" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-3 DivTopic'><input name='Topic' value='" + item.Topic.ToString() + "' type='text' id='Topic" + x + "' class='form-control' placeholder=''></div>" +
                       "	<div class='col-md-2 '>" +
                            "	<div class='input-group date DivPublishDate' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.PublishDate.ToString("MM/dd/yyyy") + "'  name='PublishDate' type='text' id='PublishDate" + x + "' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                        "<div class='col-md-3 DivNotes'><input name='Notes8' value='" + item.Notes.ToString() + "' type='text'' id='Notes8" + x + "' class='form-control' placeholder=''></div>" +                        
                        
                             "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowPublications(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
                            "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV8.Controls.Add(newDiv);
                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void ExpertiseData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<ExpertiseEntity> QualificationsData = objIK.GeteExpertise(currentUserlogin);
                int x = 0;
                foreach (ExpertiseEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID07.Value = item.ID.ToString();
                        RetrevehdnsuperDIV7.Value = item.ID.ToString() + "#";
                        Notes07.Value = item.Notes.ToString();
                        NatureOfTheJob0.Value = item.NatureOfTheJob.ToString();
                        OrganizationName0.Value = item.OrganizationName.ToString();
                        YearsOfExperience0.Value = item.YearsOfExperience.ToString();
                        DropDownCountry7.SelectedValue = item.CountryID.ToString();
                        
                    }
                    else
                    {
                        hdnsuperDIV7.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV7.Value += item.ID.ToString() + "#";
                        CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                        DataTable dataC = new ImplicitKnowledge().GetCountrys();
                        string options = "";
                        string selct = "";
                        foreach (DataRow dtRow in dataC.Rows)
                        {
                            if (dtRow["ID"].ToString() == item.CountryID.ToString())
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
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID7' style=' display: none;'><input name='SID7' value='" + item.ID.ToString() + "' type='text' id='SID7" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivOrganizationName'><input name='OrganizationName' value='" + item.OrganizationName.ToString() + "' type='text' id='OrganizationName" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivNatureOfTheJob'><input name='NatureOfTheJob' value='" + item.NatureOfTheJob.ToString() + "' type='text' id='NatureOfTheJob" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivCountry '>" +
                        "<select name='DropDownCountry7' id='DropDownCountry7" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                        "<div class='col-md-2 DivYearsOfExperience'><input name='YearsOfExperience' value='" + item.YearsOfExperience.ToString() + "' type='text'' id='YearsOfExperience" + x + "' class='form-control' placeholder=''></div>" +
                            "<div class='col-md-2 DivNotes'><input name='Notes7' value='" + item.Notes.ToString() + "' type='text'' id='Notes7" + x + "' class='form-control' placeholder=''></div>" +

                             "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowQualifications(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
                            "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV7.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void TrainingCoursesData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<TrainingCoursesEntity> QualificationsData = objIK.GetTrainingCourses(currentUserlogin);
                int x = 0;
                foreach (TrainingCoursesEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID06.Value = item.ID.ToString();
                        RetrevehdnsuperDIV6.Value = item.ID.ToString() + "#";

                        CourseName0.Value = item.CourseName.ToString();                        
                        WithinThePlan0.Items.FindByValue(item.WithinThePlan.ToString()).Selected = true;                       
                        TrainingHours0.Value = item.TrainingHours.ToString();
                        Datefrom06.Value = item.FromDate.ToString("MM/dd/yyyy");
                        Dateto06.Value = item.ToDate.ToString("MM/dd/yyyy");
                        CourseLocation0.Value = item.CourseLocation.ToString();
                    }
                    else
                    {
                        hdnsuperDIV6.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV6.Value += item.ID.ToString() + "#";
                        var textYes = SPUtility.GetLocalizedString("$Resources: Yes", "Resource", SPContext.Current.Web.Language);
                        var textNo = SPUtility.GetLocalizedString("$Resources: No", "Resource", SPContext.Current.Web.Language);
                        var checkedYes = "";
                        var checkedNo = "";
                        if (item.WithinThePlan.ToString() == "Yes")
                        {
                            checkedYes = "checked ='checked'";                            
                        }
                        else
                        {
                            checkedNo = "checked ='checked'";
                        }
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID6' style=' display: none;'><input name='SID6' value='" + item.ID.ToString() + "' type='text' id='SID6" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-2 DivCourseName'><input name='CourseName' value='" + item.CourseName.ToString() + "' type='text' id='CourseName" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivWithinThePlan RadiB'>" +
                                    "<input name='WithinThePlan' value='" + item.WithinThePlan.ToString() + "' type='text' id='WithinThePlanvalue" + x + "' style='display:none' placeholder=''>" +
                                   " <table id='WithinThePlan" + x + "' class='checkbox-click-target' style='width:100%;'>" +
                                            "<tbody><tr>" +
                                                "<td><input "+checkedYes+" class='radio-button' onchange=\"handleChange('WithinThePlanvalue" + x + "','Yes');\" id='WithinThePlan" + x + "_0' type='radio' name='WithinThePlanR" + x + "' value='Yes'>" +
                                                "<label for='WithinThePlan" + x + "_0' class='radio-button-click-target'> <span class='radio-button-circle'></span>"+ textYes + "</label>" +
                                                "</td>" +
                                                "<td><input " + checkedNo + " class='radio-button' onchange=\"handleChange('WithinThePlanvalue" + x + "','No');\" id='WithinThePlan" + x + "_1' type='radio' name='WithinThePlanR" + x + "' value='No'>" +
                                                "<label for='WithinThePlan" + x + "_1' class='radio-button-click-target'> <span class='radio-button-circle'></span>"+ textNo + "</label>" +
                                                "</td>	" +
                                            "</tr></tbody>" +
                                    "</table>" +
                            "</div>" +
                        "<div class='col-md-2 DiTrainingHours'><input name='TrainingHours' value='" + item.TrainingHours.ToString() + "' type='text' id='TrainingHours" + x + "' class='form-control' placeholder=''></div>" +                       
                            "	<div class='col-md-2 '>" +
                            "	<div class='input-group date DivDatefrom6' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.FromDate.ToString("MM/dd/yyyy") + "'  name='Datefrom6' type='text' id='Datefrom6' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                            "	<div class='col-md-2 '>" +
                            "	<div class='input-group date DivDateto6' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.ToDate.ToString("MM/dd/yyyy") + "'  name='Dateto6' type='text' id='Dateto6' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                             "<div class='col-md-1 DivCourseLocation'><input name='CourseLocation' value='" + item.CourseLocation.ToString() + "' type='text'' id='CourseLocation" + x + "' class='form-control' placeholder=''></div>" +

                             "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTrainingCourses(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
                            "</div>" +
                "</div>";

                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV6.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void WithinThePlan()
        {
            var placetext = SPUtility.GetLocalizedString("$Resources: Yes", "Resource", SPContext.Current.Web.Language);
            placetext = "<span class='radio-button-circle'></span>" + placetext;
            WithinThePlan0.Items.Add(new ListItem(placetext, "Yes"));

            var placetext2 = SPUtility.GetLocalizedString("$Resources: No", "Resource", SPContext.Current.Web.Language);
            placetext2 = "<span class='radio-button-circle'></span>" + placetext2;
            WithinThePlan0.Items.Add(new ListItem(placetext2, "No"));
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
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID3' style=' display: none;'><input name='SID3' value='" + item.ID.ToString() + "' type='text' id='SID3" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-2 DivLanguage'><input name='Language' value='" + item.Language.ToString() + "' type='text' id='Language" + x + "' class='form-control' placeholder=''></div>" +
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
                        "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowLanguageSkills(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
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
        private void OtherSkillsData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<OtherSkillsEntity> QualificationsData = objIK.GeteOtherSkills(currentUserlogin);
                int x = 0;
                foreach (OtherSkillsEntity item in QualificationsData)
                {
                    if (x == 0)
                    {
                        SID05.Value = item.ID.ToString();
                        RetrevehdnsuperDIV5.Value = item.ID.ToString() + "#";
                        SkillTheEmployeeHave0.Value = item.SkillTheEmployeeHave.ToString();
                        Notes05.Value = item.Notes.ToString();
                    }
                    else
                    {
                        hdnsuperDIV5.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV5.Value += item.ID.ToString() + "#";
                       
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID5' style=' display: none;'><input name='SID5' value='" + item.ID.ToString() + "' type='text' id='SID5" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-5 DivSkillTheEmployeeHave'><input name='SkillTheEmployeeHave' value='" + item.SkillTheEmployeeHave.ToString() + "' type='text' id='SkillTheEmployeeHave" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-5 DivNotes5'><input name='Notes5' value='" + item.Notes.ToString() + "' type='text' id='Notes5" + x + "' class='form-control' placeholder=''></div>" +
                         "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowOtherSkills(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
                        "</div>" +
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV5.Controls.Add(newDiv);

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
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID4' style=' display: none;'><input name='SID4' value='" + item.ID.ToString() + "' type='text' id='SID4" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-2 DivSkillType'><input name='SkillType' value='" + item.SkillType.ToString() + "' type='text' id='SkillType" + x + "' class='form-control' placeholder=''></div>" +
                       "<div class='col-md-3 DivSkillLevel '>" +
                        "<select name='DropDownSkillLevel' id='DropDownSkillLevel" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                          "<div class='col-md-3 DivAreaOfApplication'><input name='AreaOfApplication' value='" + item.AreaOfApplication.ToString() + "' type='text' id='AreaOfApplication" + x + "' class='form-control' placeholder=''></div>" +
                            "<div class='col-md-3 DivNotes4'><input name='Notes4' value='" + item.Notes.ToString() + "' type='text' id='Notes4" + x + "' class='form-control' placeholder=''></div>" +
                          "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTechnicalSkills(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
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
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                        "<div class='DivSID2' style=' display: none;'><input name='SID2' value='" + item.ID.ToString() + "' type='text' id='SID2" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-3 DivQualification'><input name='Qualification' value='" + item.Qualification.ToString() + "' type='text' id='Qualification" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivMajor'><input name='Major' value='" + item.Major.ToString() + "' type='text' id='Major" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivInstitution'><input name='Institution' value='" + item.Institution.ToString() + "' type='text'' id='Institution" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivCountry '>" +
                        "<select name='DropDownCountry' id='DropDownCountry" + x + "' class='form-control'>" +
                          options +
                        "</select></div>" +
                        "	<div class='col-md-2 '>" +
                            "	<div class='input-group date DivGraduationYear' data-provide='datepicker'>" +
                            "	<input autocomplete='off' value='" + item.GraduationYear.ToString("MM/dd/yyyy") + "'  name='GraduationYear' type='text' id='GraduationYear" + x + "' class='form-control'>" +
                            "	<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                            "</div>	" +
                             "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowQualifications(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  "</div>" +
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
            DropDownCountry7.DataSource = dataC;
            DropDownCountry7.DataValueField = "ID";
            DropDownCountryResidentForMoreThan3Months.DataSource = dataC;
            DropDownCountryResidentForMoreThan3Months.DataValueField = "ID";

            DropDownCountry10.DataSource = dataC;
            DropDownCountry10.DataValueField = "ID";
            if (languageCode == "ar")
            {
                DropDownCountry.DataTextField = "Title";
                DropDownCountry7.DataTextField = "Title";
                DropDownCountryResidentForMoreThan3Months.DataTextField = "Title";
                DropDownCountry10.DataTextField = "Title";
            }
            else
            {
                DropDownCountry.DataTextField = "TitleEN";
                DropDownCountry7.DataTextField = "TitleEN";
                DropDownCountryResidentForMoreThan3Months.DataTextField = "TitleEN";
                DropDownCountry10.DataTextField = "TitleEN";
            }

            DropDownCountry.DataBind();
            DropDownCountry7.DataBind();
            DropDownCountryResidentForMoreThan3Months.DataBind();
            DropDownCountry10.DataBind();


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
                        var htmlrow1 = "<div class='rowI cnrtnheadbox2'> " +
                    "<div class='row rt'>" +
                                   "<div class=' DivSID' style=' display: none;'>" +
                                     "<input name='SID' type='text' value='" + item.ID.ToString() + "' id='SID" + x + "' class='form-control' placeholder=''>" +
                                    "</div>" +
                            "<div class='col-md-4 DivDesignation'><input name='Designation' value='" + item.Designation.ToString() + "' type='text'' id='Designation" + x + "' class='form-control' placeholder=''>" +
                            "</div>" +
                                "<div class='col-md-3 DivOrganizationalunit'><input name='Organizationalunit' value='" + item.OrganizationalUnit.ToString() + "' type='text'' id='Organizationalunit" + x + "' class='form-control' placeholder=''>" +
                                "</div> " +
                                    "<div class='col-md-2 '>" +
                                    "	<div class='input-group date DivDatefrom' data-provide='datepicker'><input autocomplete='off' value='" + item.DateFrom.ToString("MM/dd/yyyy") + "' name='Datefrom' type='text' id='Datefrom" + x + "' class='form-control'>" +
                                    "<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                                     "</div>" +
                                    "<div class='col-md-2'>" +
                                    "<div class='input-group date DivDateto' data-provide='datepicker'><input value='" + item.DateTo.ToString("MM/dd/yyyy") + "' autocomplete='off' name='Dateto' type='text' id='Dateto" + x + "' class='form-control'>" +
                                    "<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div> </div>" +
                                     "<div class='col-md-1'>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowEmploymenthistory(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>"+
                                  "</div>" +

                         " </div></div>";

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
                    if (hdnsuperDIV1.Value != "" && hdnsuperDIV1.Value != "0")
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
                    if (hdnsuperDIV2.Value != ""&& hdnsuperDIV2.Value != "0")
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
                            RetrevehdnsuperDIV3.Value = RetrevehdnsuperDIV3.Value.Replace(Entit3.ID + "#", "");
                        }
                        Entit3.Title = currentUserlogin;
                        list3.Add(Entit3);
                    }
                    if (hdnsuperDIV3.Value != ""&& hdnsuperDIV3.Value != "0")
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
                            RetrevehdnsuperDIV4.Value = RetrevehdnsuperDIV4.Value.Replace(Entit4.ID + "#", "");
                        }
                        Entit4.Title = currentUserlogin;
                        list4.Add(Entit4);
                    }
                    if (hdnsuperDIV4.Value != ""&& hdnsuperDIV4.Value != "0")
                    {
                        string[] SID4 = Request.Form.GetValues("SID4");
                        string[] SkillType = Request.Form.GetValues("SkillType");
                        string[] DropDownSkillLevell = Request.Form.GetValues("DropDownSkillLevel");
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

                    List<OtherSkillsEntity> list5 = new List<OtherSkillsEntity>();
                    OtherSkillsEntity Entit5 = new OtherSkillsEntity();
                    if (!string.IsNullOrEmpty(SkillTheEmployeeHave0.Value))
                    {
                        Entit5.SkillTheEmployeeHave = SkillTheEmployeeHave0.Value;
                        Entit5.Notes = Notes05.Value.ToString();
                        Entit5.PID = PID;
                        if (!string.IsNullOrEmpty(SID05.Value))
                        {
                            Entit5.ID = Convert.ToInt32(SID05.Value);
                            RetrevehdnsuperDIV5.Value = RetrevehdnsuperDIV5.Value.Replace(Entit5.ID + "#", "");
                        }
                        Entit5.Title = currentUserlogin;
                        list5.Add(Entit5);
                    }
                    if (hdnsuperDIV5.Value != "" && hdnsuperDIV5.Value != "0")
                    {
                        string[] SID5 = Request.Form.GetValues("SID5");
                        string[] SkillTheEmployeeHave = Request.Form.GetValues("SkillTheEmployeeHave");
                        string[] Notes5 = Request.Form.GetValues("Notes5");
                        for (int x = 0; x < Convert.ToInt32(SkillTheEmployeeHave.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(SkillTheEmployeeHave[x]))
                            {
                                OtherSkillsEntity ob = new OtherSkillsEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                ob.SkillTheEmployeeHave = SkillTheEmployeeHave[x];
                                ob.Notes = Notes5[x];
                                if (!string.IsNullOrEmpty(SID5[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID5[x]);
                                    RetrevehdnsuperDIV5.Value = RetrevehdnsuperDIV5.Value.Replace(ob.ID + "#", "");
                                }
                                list5.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateOtherSkills(list5);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV5.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV5.Value.Split('#');
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
                            objIK.DeleteitemsFromSublist("OtherSkills", ListSID1);
                        }
                    }
                    ////////////////////////////////// 7 ///////////////////////
                   
                    List<TrainingCoursesEntity> list6 = new List<TrainingCoursesEntity>();
                    TrainingCoursesEntity Entit6 = new TrainingCoursesEntity();
                    if (!string.IsNullOrEmpty(CourseName0.Value))
                    {
                        DateTime Date = new DateTime();
                        if (!string.IsNullOrEmpty(Datefrom06.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(Datefrom06.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date = sDate2;
                        }
                        DateTime Date2 = new DateTime();
                        if (!string.IsNullOrEmpty(Dateto06.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(Dateto06.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date2 = sDate2;
                        }
                        Entit6.FromDate = Date;
                        Entit6.ToDate = Date2;
                        Entit6.CourseLocation = CourseLocation0.Value;
                        Entit6.CourseName = CourseName0.Value;
                        Entit6.TrainingHours = TrainingHours0.Value;
                        Entit6.WithinThePlan = WithinThePlan0.SelectedValue.ToString();
                        Entit6.PID = PID;
                        if (!string.IsNullOrEmpty(SID06.Value))
                        {
                            Entit6.ID = Convert.ToInt32(SID06.Value);
                            RetrevehdnsuperDIV6.Value = RetrevehdnsuperDIV6.Value.Replace(Entit6.ID + "#", "");
                        }
                        Entit6.Title = currentUserlogin;
                        list6.Add(Entit6);
                    }
                    if (hdnsuperDIV6.Value != "" && hdnsuperDIV6.Value != "0")
                    {
                        string[] SID6 = Request.Form.GetValues("SID6");
                        string[] FromDate = Request.Form.GetValues("Datefrom6");
                        string[] ToDate = Request.Form.GetValues("Dateto6");
                        string[] CourseLocation = Request.Form.GetValues("CourseLocation");
                        string[] CourseName = Request.Form.GetValues("CourseName");
                        string[] TrainingHours = Request.Form.GetValues("TrainingHours");
                        string[] WithinThePlan = Request.Form.GetValues("WithinThePlan");
                        for (int x = 0; x < Convert.ToInt32(CourseName.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(CourseName[x]))
                            {
                                TrainingCoursesEntity ob = new TrainingCoursesEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                DateTime Date = new DateTime();
                                if (!string.IsNullOrEmpty(FromDate[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(FromDate[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date = sDate2;
                                }
                                DateTime Date2 = new DateTime();
                                if (!string.IsNullOrEmpty(ToDate[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(ToDate[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date2 = sDate2;
                                }
                                ob.FromDate = Date;
                                ob.ToDate = Date2;
                                ob.CourseLocation = CourseLocation[x];
                                ob.CourseName = CourseName[x];
                                ob.TrainingHours = TrainingHours[x];
                                ob.WithinThePlan = WithinThePlan[x];
                                if (!string.IsNullOrEmpty(SID6[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID6[x]);
                                    RetrevehdnsuperDIV6.Value = RetrevehdnsuperDIV6.Value.Replace(ob.ID + "#", "");
                                }
                                list6.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateTrainingCourses(list6);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV6.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV6.Value.Split('#');
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
                            objIK.DeleteitemsFromSublist("TrainingCourses", ListSID1);
                        }
                    }
                    //////////////////////////////////8///////////////////////
                    List<ExpertiseEntity> list7 = new List<ExpertiseEntity>();
                    ExpertiseEntity Entit7 = new ExpertiseEntity();
                    if (!string.IsNullOrEmpty(OrganizationName0.Value))
                    {
                        Entit7.OrganizationName = OrganizationName0.Value;
                        Entit7.NatureOfTheJob = NatureOfTheJob0.Value;
                        Entit7.YearsOfExperience = YearsOfExperience0.Value;
                        Entit7.Notes = Notes07.Value;
                        Entit7.CountryID = DropDownCountry7.SelectedValue.ToString();
                        Entit7.PID = PID;
                        if (!string.IsNullOrEmpty(SID07.Value))
                        {
                            Entit7.ID = Convert.ToInt32(SID07.Value);
                            RetrevehdnsuperDIV7.Value = RetrevehdnsuperDIV7.Value.Replace(Entit7.ID + "#", "");
                        }
                        Entit7.Title = currentUserlogin;
                        list7.Add(Entit7);
                    }
                    if (hdnsuperDIV7.Value != "" && hdnsuperDIV7.Value != "0")
                    {
                        string[] SID7 = Request.Form.GetValues("SID7");
                        string[] OrganizationName = Request.Form.GetValues("OrganizationName");
                        string[] NatureOfTheJob = Request.Form.GetValues("NatureOfTheJob");
                        string[] YearsOfExperience = Request.Form.GetValues("YearsOfExperience");
                        string[] Notes7 = Request.Form.GetValues("Notes7");
                        string[] DropDownCountry7 = Request.Form.GetValues("DropDownCountry7");
                        for (int x = 0; x < Convert.ToInt32(OrganizationName.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(OrganizationName[x]))
                            {
                                ExpertiseEntity ob = new ExpertiseEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;   

                                ob.OrganizationName = OrganizationName[x];
                                ob.NatureOfTheJob = NatureOfTheJob[x];
                                ob.YearsOfExperience = YearsOfExperience[x];
                                ob.Notes = Notes7[x];
                                ob.CountryID = DropDownCountry7[x];

                                if (!string.IsNullOrEmpty(SID7[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID7[x]);
                                    RetrevehdnsuperDIV7.Value = RetrevehdnsuperDIV7.Value.Replace(ob.ID + "#", "");
                                }
                                list7.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateExpertise(list7);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV7.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV7.Value.Split('#');
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
                            objIK.DeleteitemsFromSublist("Expertise", ListSID1);
                        }
                    }
                    //////////////////////////////////9///////////////////////

                    List<PublicationsEntity> list8 = new List<PublicationsEntity>();
                    PublicationsEntity Entit8 = new PublicationsEntity();
                    if (!string.IsNullOrEmpty(BookPublicationTitle0.Value))
                    {
                        DateTime Date = new DateTime();
                        if (!string.IsNullOrEmpty(PublishDate0.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(PublishDate0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date = sDate2;
                        }
                       
                        Entit8.PublishDate = Date;
                        Entit8.BookPublicationTitle = BookPublicationTitle0.Value;
                        Entit8.Notes = Notes08.Value;
                        Entit8.Topic = Topic0.Value;
                        Entit8.PID = PID;
                        if (!string.IsNullOrEmpty(SID08.Value))
                        {
                            Entit8.ID = Convert.ToInt32(SID08.Value);
                            RetrevehdnsuperDIV8.Value = RetrevehdnsuperDIV8.Value.Replace(Entit8.ID + "#", "");
                        }
                        Entit8.Title = currentUserlogin;
                        list8.Add(Entit8);
                    }
                    if (hdnsuperDIV8.Value != "" && hdnsuperDIV8.Value != "0")
                    {
                        string[] SID8 = Request.Form.GetValues("SID8");
                        string[] BookPublicationTitle = Request.Form.GetValues("BookPublicationTitle");
                        string[] Topic = Request.Form.GetValues("Topic");
                        string[] Notes8 = Request.Form.GetValues("Notes8");
                        string[] PublishDate = Request.Form.GetValues("PublishDate");
                        for (int x = 0; x < Convert.ToInt32(BookPublicationTitle.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(BookPublicationTitle[x]))
                            {
                                PublicationsEntity ob = new PublicationsEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                DateTime Date = new DateTime();
                                if (!string.IsNullOrEmpty(PublishDate[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(PublishDate[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date = sDate2;
                                }
                               
                                ob.PublishDate = Date;
                                
                                ob.BookPublicationTitle = BookPublicationTitle[x];
                                ob.Topic = Topic[x];
                                ob.Notes = Notes8[x];
                                if (!string.IsNullOrEmpty(SID8[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID8[x]);
                                    RetrevehdnsuperDIV8.Value = RetrevehdnsuperDIV8.Value.Replace(ob.ID + "#", "");
                                }
                                list8.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdatePublications(list8);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV8.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV8.Value.Split('#');
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
                            objIK.DeleteitemsFromSublist("Publications", ListSID1);
                        }
                    }
                    //////////////////////////////////10///////////////////////
                    List<TravelInformationsEntity> list9 = new List<TravelInformationsEntity>();
                    TravelInformationsEntity Entit9 = new TravelInformationsEntity();
                    if (!string.IsNullOrEmpty(DropDownCountryResidentForMoreThan3Months.SelectedValue))
                    {
                        DateTime Date = new DateTime();
                        if (!string.IsNullOrEmpty(TimePeriodFrom0.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(TimePeriodFrom0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date = sDate2;
                        }
                        DateTime Date2 = new DateTime();
                        if (!string.IsNullOrEmpty(TimeperiodTo0.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(TimeperiodTo0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date2 = sDate2;
                        }
                        Entit9.TimePeriodFrom = Date;
                        Entit9.TimeperiodTo = Date2;
                        Entit9.CountryResidentForMoreThan3Month = DropDownCountryResidentForMoreThan3Months.SelectedValue.ToString();
                        Entit9.VisitReasons = VisitReasons0.Value;                        
                        Entit9.PID = PID;
                        if (!string.IsNullOrEmpty(SID09.Value))
                        {
                            Entit9.ID = Convert.ToInt32(SID09.Value);
                            RetrevehdnsuperDIV9.Value = RetrevehdnsuperDIV9.Value.Replace(Entit9.ID + "#", "");
                        }
                        Entit9.Title = currentUserlogin;
                        list9.Add(Entit9);
                    }
                    if (hdnsuperDIV9.Value != "" && hdnsuperDIV9.Value != "0")
                    {
                        string[] SID9 = Request.Form.GetValues("SID9");
                        string[] DropDownCountryResidentForMoreThan3Months = Request.Form.GetValues("DropDownCountryResidentForMoreThan3Months");
                        string[] TimePeriodFrom = Request.Form.GetValues("TimePeriodFrom");
                        string[] TimeperiodTo = Request.Form.GetValues("TimeperiodTo");
                        string[] VisitReasons = Request.Form.GetValues("VisitReasons");
                        for (int x = 0; x < Convert.ToInt32(DropDownCountryResidentForMoreThan3Months.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(DropDownCountryResidentForMoreThan3Months[x]))
                            {
                                TravelInformationsEntity ob = new TravelInformationsEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                DateTime Date = new DateTime();
                                if (!string.IsNullOrEmpty(TimePeriodFrom[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(TimePeriodFrom[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date = sDate2;
                                }
                                DateTime Date2 = new DateTime();
                                if (!string.IsNullOrEmpty(TimeperiodTo[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(TimeperiodTo[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date2 = sDate2;
                                }
                                ob.TimePeriodFrom = Date;
                                ob.TimeperiodTo = Date2;
                                ob.CountryResidentForMoreThan3Month = DropDownCountryResidentForMoreThan3Months[x];
                                ob.VisitReasons = VisitReasons[x];
                                if (!string.IsNullOrEmpty(SID9[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID9[x]);
                                    RetrevehdnsuperDIV9.Value = RetrevehdnsuperDIV9.Value.Replace(ob.ID + "#", "");
                                }
                                list9.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateTravelInformations(list9);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV9.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV9.Value.Split('#');
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
                            objIK.DeleteitemsFromSublist("TravelInformations", ListSID1);
                        }
                    }
                    //////////////////////////////////11///////////////////////

                    List<ParticipationsEntity> list10 = new List<ParticipationsEntity>();
                    ParticipationsEntity Entit10 = new ParticipationsEntity();
                    if (!string.IsNullOrEmpty(ActivityName0.Value))
                    {
                        Entit10.CountryID = DropDownCountry10.SelectedValue.ToString();
                        Entit10.ActivityName = ActivityName0.Value;
                        Entit10.Sponsor = Sponsor0.Value;
                        Entit10.NatureOfTheParticipation = NatureOfTheParticipation0.Value;

                        Entit10.PID = PID;
                        if (!string.IsNullOrEmpty(SID010.Value))
                        {
                            Entit10.ID = Convert.ToInt32(SID010.Value);
                            RetrevehdnsuperDIV10.Value = RetrevehdnsuperDIV10.Value.Replace(Entit10.ID + "#", "");
                        }
                        Entit10.Title = currentUserlogin;
                        list10.Add(Entit10);
                    }
                    if (hdnsuperDIV10.Value != "" && hdnsuperDIV10.Value != "0")
                    {
                        string[] SID10 = Request.Form.GetValues("SID10");
                        string[] ActivityName = Request.Form.GetValues("ActivityName");
                        string[] Sponsor = Request.Form.GetValues("Sponsor");
                        string[] DropDownCountry10 = Request.Form.GetValues("DropDownCountry10");
                        string[] NatureOfTheParticipation = Request.Form.GetValues("NatureOfTheParticipation");
                        for (int x = 0; x < Convert.ToInt32(ActivityName.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(ActivityName[x]))
                            {
                                ParticipationsEntity ob = new ParticipationsEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;                               
                                ob.ActivityName = ActivityName[x];
                                ob.Sponsor = Sponsor[x];
                                ob.CountryID = DropDownCountry10[x];
                                ob.NatureOfTheParticipation = NatureOfTheParticipation[x];
                                if (!string.IsNullOrEmpty(SID10[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID10[x]);
                                    RetrevehdnsuperDIV10.Value = RetrevehdnsuperDIV10.Value.Replace(ob.ID + "#", "");
                                }
                                list10.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateParticipations(list10);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV10.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV10.Value.Split('#');
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
                            objIK.DeleteitemsFromSublist("Participations", ListSID1);
                        }
                    }
                    //////////////////////////////////12///////////////////////
                    List<MembershipEntity> list11 = new List<MembershipEntity>();
                    MembershipEntity Entit11 = new MembershipEntity();
                    if (!string.IsNullOrEmpty(Membership0.Value))
                    {
                        DateTime Date = new DateTime();
                        if (!string.IsNullOrEmpty(FromDate011.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(FromDate011.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date = sDate2;
                        }
                        DateTime Date2 = new DateTime();
                        if (!string.IsNullOrEmpty(ToDate011.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(ToDate011.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Date2 = sDate2;
                        }
                        Entit11.FromDate = Date;
                        Entit11.ToDate = Date2;
                        Entit11.Membership = Membership0.Value;
                        Entit11.Location = Location0.Value;
                        Entit11.Field = Field011.Value;
                        Entit11.Notes = Notes011.Value;
                        Entit11.PID = PID;
                        if (!string.IsNullOrEmpty(SID011.Value))
                        {
                            Entit11.ID = Convert.ToInt32(SID011.Value);
                            RetrevehdnsuperDIV11.Value = RetrevehdnsuperDIV11.Value.Replace(Entit11.ID + "#", "");
                        }
                        Entit11.Title = currentUserlogin;
                        list11.Add(Entit11);
                    }
                    if (hdnsuperDIV11.Value != "" && hdnsuperDIV11.Value != "0")
                    {
                        string[] SID11 = Request.Form.GetValues("SID11");
                        string[] Membership = Request.Form.GetValues("Membership");
                        string[] Location = Request.Form.GetValues("Location");
                        string[] Field11 = Request.Form.GetValues("Field11");
                        string[] FromDate11 = Request.Form.GetValues("FromDate11");
                        string[] ToDate11 = Request.Form.GetValues("ToDate11");
                        string[] Notes11 = Request.Form.GetValues("Notes11");
                        for (int x = 0; x < Convert.ToInt32(Membership.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Membership[x]))
                            {
                                MembershipEntity ob = new MembershipEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                DateTime Date = new DateTime();
                                if (!string.IsNullOrEmpty(FromDate11[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(FromDate11[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date = sDate2;
                                }
                                DateTime Date2 = new DateTime();
                                if (!string.IsNullOrEmpty(ToDate11[x]))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(ToDate11[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Date2 = sDate2;
                                }
                                ob.FromDate = Date;
                                ob.ToDate = Date2;
                                ob.Membership = Membership[x];
                                ob.Location = Location[x];
                                ob.Field = Field11[x];
                                ob.Notes = Notes11[x];
                                if (!string.IsNullOrEmpty(SID11[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID11[x]);
                                    RetrevehdnsuperDIV11.Value = RetrevehdnsuperDIV11.Value.Replace(ob.ID + "#", "");
                                }
                                list11.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateMembership(list11);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV11.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV11.Value.Split('#');
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
                            objIK.DeleteitemsFromSublist("Membership", ListSID1);
                        }
                    }
                    //////////////////////////////////13///////////////////////










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
