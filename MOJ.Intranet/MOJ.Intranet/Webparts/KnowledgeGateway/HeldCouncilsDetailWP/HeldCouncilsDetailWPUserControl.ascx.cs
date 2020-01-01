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

namespace MOJ.Intranet.Webparts.KnowledgeGateway.HeldCouncilsDetailWP
{
    public partial class HeldCouncilsDetailWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["RID"]))
                {
                    getExam(Convert.ToInt32(Request.Params["RID"]));
                    knowledgeCouncilEntity item = new knowledgeCouncil().GetknowledgeCouncilByID(Convert.ToInt32(Request.Params["RID"]));
                    CouncilNo.Text = Convert.ToString(item.CouncilNo);
                    ADetailedExplanationOfTheCouncil.Text = Convert.ToString(item.ADetailedExplanationOfTheCouncil);
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
                    if (resalt.ID > 0)
                    {
                        btnsubmit.Enabled = false;
                        btnsubmit.Visible = false;
                        SubjectCouncilCanBeDone.Value = Convert.ToString(resalt.SubjectCouncilCanBeDone);
                        TheBenefitFromTheCouncil.Value = Convert.ToString(resalt.TheBenefitFromTheCouncil);
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

                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                CouncilExaminersEntity Examiners = new knowledgeCouncil().GeCouncilExaminersByID(CkID,currentUserlogin);
                string disabled = "";
                if (Examiners.ID != 0)
                {
                   
                    btnsubmitexam.Enabled = false;
                    btnsubmitexam.Visible = false;
                    disabled = "disabled";
                    var SuccessfulMSG = SPUtility.GetLocalizedString("$Resources: TheExamResultIsSuccessful", "Resource", SPContext.Current.Web.Language);
                    var FailedMSG = SPUtility.GetLocalizedString("$Resources: TheExamResultIsFailed", "Resource", SPContext.Current.Web.Language);
                    if (Examiners.Resalt== "Success")
                    {
                        LBresalt.Text = SuccessfulMSG;
                    }
                    else
                    {
                        LBresalt.Text = FailedMSG;
                    }

                    LBresalt.Text +=  " (" + Examiners .percentage+ ") ";
                }



                List<CouncilExamEntity> itemData = new knowledgeCouncil().GetCouncilExam(CkID);
                if(itemData.Count <= 0){
                    btnsubmitexam.Enabled = false;
                    btnsubmitexam.Visible = false;
                }
                int x = 0;
                foreach (CouncilExamEntity item in itemData)
                {
                    CouncilExamAnswerEntity ExamAnswer = new knowledgeCouncil().GetCouncilExamAnswer(item.ID, currentUserlogin);

                    int oldAnswer = Convert.ToInt32(ExamAnswer.AnswerID);
                    string checked1 = "";
                    string checked2 = "";
                    string checked3 = "";
                    string checked4 = "";
                    if (oldAnswer==1)
                    checked1 = "checked ='checked'";
                    if (oldAnswer==2)
                    checked2 = "checked ='checked'";
                    if (oldAnswer == 3)
                        checked3 = "checked ='checked'";     
                    if (oldAnswer==4)
                    checked4 = "checked ='checked'";
                    var Question = SPUtility.GetLocalizedString("$Resources: Question", "Resource", SPContext.Current.Web.Language);
                    var ChooseTheAnswer = SPUtility.GetLocalizedString("$Resources: ChooseTheAnswer", "Resource", SPContext.Current.Web.Language);
                    var htmlrow1 = "<div class='q-row'>" +
                            "<h2><label><asp:Literal runat='server' Text='" + Question + "' /></label></h2>" +
                            "<span>" + item.Question + "</span>" +
                        "</div>" +
                        "<h2 class='answerTitle'>" + ChooseTheAnswer + "</h2>" +
                        "<div class='poll-popup-answ'>";
                    string postin;
                    postin = item.possibility1;
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<input name='QuestionID' value='"+ item.ID + "' type='text' id='QuestionID" + x + "' style='display:none' placeholder=''>" +

                        "<input name='AnswerIs' value='' type='text' id='AnswerIs" + x + "' style='display:none' placeholder=''>" +

                         "<div class='radioComponent'><input "+ disabled + " type='radio' "+ checked1 + " onchange=\"handleChange('AnswerIs" + x + "','1');\"  name='common-radio-name" + x + "' id='radio-" + x + "' class='radio-button' />" +
                        "<label for='radio-" + x + "' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label></div>";
                    }
                    postin = item.possibility2;
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<div class='radioComponent'><input " + disabled + " type='radio' " + checked2+ " onchange=\"handleChange('AnswerIs" + x + "','2');\"  name='common-radio-name" + x + "' id='radio-" + x + "' class='radio-button' />" +
                       "<label for='radio-" + x + "' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label></div>";
                    }
                    postin = item.possibility3;
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<div class='radioComponent'><input " + disabled + " type='radio' " + checked3+ " onchange=\"handleChange('AnswerIs" + x + "','3');\"  name='common-radio-name" + x + "' id='radio-" + x + "' class='radio-button' />" +
                       "<label for='radio-" + x + "' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label></div>";
                    }
                    postin = item.possibility4;
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<div class='radioComponent'><input " + disabled + " type='radio' " + checked4+ "  onchange=\"handleChange('AnswerIs" + x + "','4');\"  name='common-radio-name" + x + "' id='radio-" + x + "' class='radio-button' />" +
                       "<label for='radio-" + x + "' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label></div>";
                    }
                    htmlrow1 += "</div>";
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
            if (!_isRefresh)
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                List<CouncilExamAnswerEntity> list6 = new List<CouncilExamAnswerEntity>();
                int AllResult = 0;
                string[] QuestionID = Request.Form.GetValues("QuestionID");
                string[] AnswerIs = Request.Form.GetValues("AnswerIs");
                for (int x = 0; x < Convert.ToInt32(QuestionID.Length); x++)
                {
                    if (!string.IsNullOrEmpty(QuestionID[x]))
                    {
                        CouncilExamAnswerEntity Answerob = new CouncilExamAnswerEntity();
                        CouncilExamEntity QuestionData = new knowledgeCouncil().GetCouncilExamBYID(Convert.ToInt32(QuestionID[x]));
                        if (Convert.ToString(AnswerIs[x]) == "1")
                        {
                            Answerob.Answer = QuestionData.possibility1;
                        }
                        if (Convert.ToString(AnswerIs[x]) == "2")
                        {
                            Answerob.Answer = QuestionData.possibility2;
                        }
                        if (Convert.ToString(AnswerIs[x]) == "3")
                        {
                            Answerob.Answer = QuestionData.possibility3;
                        }
                        if (Convert.ToString(AnswerIs[x]) == "4")
                        {
                            Answerob.Answer = QuestionData.possibility4;
                        }
                        Answerob.loginName = currentUserlogin;
                        Answerob.AnswerID = Convert.ToString(AnswerIs[x]);
                        Answerob.ExamID = Convert.ToString(QuestionID[x]);
                        Answerob.knowledgeCouncilID = Convert.ToString(Request.Params["RID"]);
                        Answerob.Question = QuestionData.Question;
                        if (Convert.ToString(AnswerIs[x]) == Convert.ToString(QuestionData.Answer))
                        {
                            Answerob.Result = 1;
                            AllResult+=1;
                        }
                        else
                        {
                            Answerob.Result = 0;
                        }
                        list6.Add(Answerob);
                    }
                }
                knowledgeCouncilEntity item = new knowledgeCouncil().GetknowledgeCouncilByID(Convert.ToInt32(Request.Params["RID"]));

                bool saveAnswer = new knowledgeCouncil().SaveUpdateCouncilExamAnswer(list6);
                CouncilExaminersEntity Examiners = new CouncilExaminersEntity();
                Examiners.loginName = currentUserlogin;
                Examiners.knowledgeCouncil = Convert.ToInt32(Request.Params["RID"]);
                Examiners.knowledgeCouncilID = Convert.ToInt32(Request.Params["RID"]);
                double per = (Convert.ToDouble(AllResult)/Convert.ToDouble(QuestionID.Length)) * 100;
                Examiners.percentage = per + "%";
                if (Convert.ToDouble(item.PassPercentage) <= per)
                {
                    Examiners.Resalt = "Success";
                }
                else
                {
                    Examiners.Resalt = "Failure";
                }
                bool saveAnswer2 = new knowledgeCouncil().SaveUpdateCouncilExaminers(Examiners);
                btnsubmitexam.Enabled = false;
                btnsubmitexam.Visible = false;
                getExam(Convert.ToInt32(Request.Params["RID"]));
                var SuccessfulMSG = SPUtility.GetLocalizedString("$Resources: TheExamResultIsSuccessful", "Resource", SPContext.Current.Web.Language);
                var FailedMSG = SPUtility.GetLocalizedString("$Resources: TheExamResultIsFailed", "Resource", SPContext.Current.Web.Language);
                string ResaltMSG = "";
                if (Examiners.Resalt == "Success")
                {
                    ResaltMSG = SuccessfulMSG;
                }
                else
                {
                    ResaltMSG = FailedMSG;
                }

                ResaltMSG += " (" + per + "%" + ") ";
                string script = string.Format(@"
                                alert('ResaltMSG');
                                window.location = '{0}';
                                ", "");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", script, true);


              
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                if (languageCode == "ar")
                {
                    Response.Redirect("/Ar/KnowledgeGateway/Pages/HeldCouncilsDetail.aspx?RID="+Convert.ToString(Request.Params["RID"]));
                }
                else
                {
                    Response.Redirect("/En/KnowledgeGateway/Pages/HeldCouncilsDetail.aspx?RID=" + Convert.ToString(Request.Params["RID"]));
                }
                //string script = string.Format(@"
                //                alert('Hello World!');
                //                window.location = '{0}';
                //                ", "");

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "_key123", script, true);

            }

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
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
}

