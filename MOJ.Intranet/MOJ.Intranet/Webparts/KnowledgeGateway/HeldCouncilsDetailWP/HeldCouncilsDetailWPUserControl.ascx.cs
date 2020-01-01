using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.HeldCouncilsDetailWP
{
    public partial class HeldCouncilsDetailWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["RID"]))
                {
                    getExam(Convert.ToInt32(Request.Params["RID"]));
                    knowledgeCouncilEntity item = new knowledgeCouncil().GetHappinessHotline(Convert.ToInt32(Request.Params["RID"]));
                    CouncilNo.Text =    Convert.ToString(item.CouncilNo);
                    ADetailedExplanationOfTheCouncil.Text =    Convert.ToString(item.ADetailedExplanationOfTheCouncil);
                    CouncilHeldDate.Text = item.CouncilDate.ToString("dd/MM/yyyy");
                    Department.Text = Convert.ToString(item.Department);
                    Lecturer.Text = Convert.ToString(item.Lecturer);
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    string CouncilTypename = new knowledgeCouncil().GetCouncilTypeByid(Convert.ToInt32(item.CouncilType), languageCode);

                    CouncilType.Text = CouncilTypename;
                    /////////////////////////////////////////
                    CouncilFeedbackEntity item2 = new CouncilFeedbackEntity();
                    item2.knowledgeCouncilID = Convert.ToString(Request.Params["RID"]);
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                    item2.loginName = currentUserlogin;

                    CouncilFeedbackEntity resalt = new CouncilFeedback().GetCouncilFeedback(item2);
                    if (resalt.ID > 0) {
                        btnsubmit.Enabled = false;
                        btnsubmit.Visible = false;
                        SubjectCouncilCanBeDone.Value = Convert.ToString(resalt.SubjectCouncilCanBeDone);
                        TheBenefitFromTheCouncil.Value= Convert.ToString(resalt.TheBenefitFromTheCouncil);
                        DevelopmentProposalsForCouncil.Value = Convert.ToString(resalt.DevelopmentProposalsForCouncil);
                       
                        TheBenefitFromTheCouncil.Disabled = true;
                        DevelopmentProposalsForCouncil.Disabled = true;
                        SubjectCouncilCanBeDone.Disabled = true;
                    }
                    
                }
            }
        }

        protected void getExam(int CkID)
        {
           

            try
            {
                List<CouncilExamEntity> itemData = new knowledgeCouncil().GetCouncilExam(CkID);
                int x = 0;
                foreach (CouncilExamEntity item in itemData)
                {
                    var Question = SPUtility.GetLocalizedString("$Resources: Question", "Resource", SPContext.Current.Web.Language);
                    var ChooseTheAnswer = SPUtility.GetLocalizedString("$Resources: ChooseTheAnswer", "Resource", SPContext.Current.Web.Language);
                    var htmlrow1 = "<div class='q-row'>" +
                            "<h2><label><asp:Literal runat='server' Text='" + Question + "' /></label></h2>" +
                            "<span>"+ item.Question + "</span>" +
                        "</div>" +
                        "<h2 class='answerTitle'>" + ChooseTheAnswer + "</h2>" +
                        "<div class='poll-popup-answ'>" +
                            "<div class='radioComponent'>" +
                                 "<div class='col-md-2 DivWithinThePlan RadiB'>" +
                            "<input name='QuestionID' value='' type='text' id='QuestionID" + x + "' style='display:none' placeholder=''>" +
                           " <table id='QuestionTable" + x + "' class='checkbox-click-target' style='width:100%;'>" +
                                    "<tbody><tr>";
                    string postin;
                     postin = item.possibility1;
                    if (!string.IsNullOrEmpty(postin)) {
                        htmlrow1 += "<td><input  class='radio-button' onchange=\"handleChange('QuestionID" + x + "','"+ postin + "');\" id='QuestionTable" + x + "_0' type='radio' value='"+ postin + "'>" +
                        "<label for='QuestionTable" + x + "_0' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label>" +
                        "</td>";
                    }
                    postin = item.possibility2;
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<td><input  class='radio-button' onchange=\"handleChange('QuestionID" + x + "','" + postin + "');\" id='QuestionTable" + x + "_1' type='radio' value='" + postin + "'>" +
                        "<label for='QuestionTable" + x + "_1' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label>" +
                        "</td>";
                    }
                    postin = item.possibility3;
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<td><input  class='radio-button' onchange=\"handleChange('QuestionID" + x + "','" + postin + "');\" id='QuestionTable" + x + "_2' type='radio' value='" + postin + "'>" +
                        "<label for='QuestionTable" + x + "_2' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label>" +
                        "</td>";
                    }
                    postin = item.possibility4;
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<td><input  class='radio-button' onchange=\"handleChange('QuestionID" + x + "','" + postin + "');\" id='QuestionTable" + x + "_3' type='radio' value='" + postin + "'>" +
                        "<label for='QuestionTable" + x + "_3' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label>" +
                        "</td>";
                    }
                    htmlrow1 += "</tr></tbody>"+
                        "</table>" +
                            "</div>" +
                                "</div>" +
                            "</div>";

                    System.Web.UI.HtmlControls.HtmlGenericControl newDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    newDiv.Attributes.Add("class", "qa");
                    newDiv.InnerHtml = htmlrow1;
                    QUestion.Controls.Add(newDiv);
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                if (languageCode == "ar")
                {
                    Response.Redirect("/Ar/HeldCouncil.aspx");
                }
                else
                {
                    Response.Redirect("/En/HeldCouncil.aspx");
                }
            }
            protected void btnsubmitexam_Click(object sender, EventArgs e)
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                if (languageCode == "ar")
                {
                    Response.Redirect("/Ar");
                }
                else
                {
                    Response.Redirect("/En");
                }

            }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            CouncilFeedbackEntity item = new CouncilFeedbackEntity();//.GetHappinessHotline(Convert.ToInt32(Request.Params["RID"]));
            item.knowledgeCouncilID = Convert.ToString(Request.Params["RID"]);
            string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
            item.loginName = currentUserlogin;
            item.SubjectCouncilCanBeDone = Convert.ToString(SubjectCouncilCanBeDone.Value);
            item.TheBenefitFromTheCouncil = Convert.ToString(TheBenefitFromTheCouncil.Value);
            item.DevelopmentProposalsForCouncil = Convert.ToString(DevelopmentProposalsForCouncil.Value);

            bool resalt = new CouncilFeedback().SaveUpdate(item);

            btnsubmit.Enabled = false;
            btnsubmit.Visible = false;

        }
    }
}

