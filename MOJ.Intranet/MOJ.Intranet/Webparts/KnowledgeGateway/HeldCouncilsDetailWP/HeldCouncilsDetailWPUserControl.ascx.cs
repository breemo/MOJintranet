﻿using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Configuration;

using System.Linq;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.HeldCouncilsDetailWP
{
    public partial class HeldCouncilsDetailWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetDropDownTheBenefitFromTheCouncil();

                if (!string.IsNullOrEmpty(Request.Params["RID"]))
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    AddParticipants.Enabled = false;
                    AddParticipants.Visible = false;
                    ModifyCouncil.Enabled = false;
                    ModifyCouncil.Visible = false;
                    AllFeedback.Enabled = false;
                    AllFeedback.Visible = false;
                    btn_PDFEmail.Enabled = false;
                    btn_PDFEmail.Visible = false;

                    string currentUserloginp = SPContext.Current.Web.CurrentUser.LoginName;
                    if (currentUserloginp.ToLower().Equals(@"sharepoint\system"))
                    {
                        currentUserloginp = "i:" + HttpContext.Current.User.Identity.Name;

                    }

                    ///////////////////////////////////////AddParticipants/////
                    knowledgeCouncilEntity KCEntityp = new knowledgeCouncil().GetknowledgeCouncilByID(Convert.ToInt32(Request.Params["RID"]));

                    Departments Departmentp = new Departments();
                    DepartmentsEntity DEnitiyp = Departmentp.GetbyDepartments(KCEntityp.Department);
           
                    if (DEnitiyp.DepartmentAdmin.User.LoginName.ToLower() == currentUserloginp.ToLower())
                    {
                        AddParticipants.Enabled = true;
                        AddParticipants.Visible = true;
                        ModifyCouncil.Enabled = true;
                        ModifyCouncil.Visible = true;
                        AllFeedback.Enabled = true;
                        AllFeedback.Visible = true;
                    }
                    getExam(Convert.ToInt32(Request.Params["RID"]));
                    knowledgeCouncilEntity item = new knowledgeCouncil().GetknowledgeCouncilByID(Convert.ToInt32(Request.Params["RID"]));
                    NumberOfParticipants.Text = Convert.ToString(item.NumberOfParticipants);
                    CouncilNo.Text = Convert.ToString(item.CouncilNo);
                    if (languageCode == "ar")
                    {
                        ADetailedExplanationOfTheCouncil.Text = Convert.ToString(item.CouncilDescription);
                        Lecturer.Text = Convert.ToString(item.Lecturer);
                        CouncilGoals.Text = Convert.ToString(item.CouncilGoals);
                    }
                    else
                    {
                        ADetailedExplanationOfTheCouncil.Text = Convert.ToString(item.CouncilDescriptionEN);
                        Lecturer.Text = Convert.ToString(item.LecturerEN);
                        CouncilGoals.Text = Convert.ToString(item.CouncilGoalsEN);
                    }                  
                    CouncilHeldDate.Text = item.CouncilDate.ToString("dd/MM/yyyy");
                    Department.Text = Convert.ToString(item.Department);               

                    if (!string.IsNullOrEmpty(item.URLAttachments))
                    {
                        string data = item.URLAttachments;
                        string[] arr = data.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        foreach (string URLAtt in arr)
                        {
                           // int firstindex = URLAtt.LastIndexOf("/");
                            string[] arr1 = URLAtt.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                             string URLAttTitle = arr1[arr1.Length - 1];
                            string iconfiles = "icon-files";

                            if (URLAttTitle.Contains("doc"))
                            {
                                iconfiles = "icon-file-word1";
                            }
                            if (URLAttTitle.Contains("pdf"))
                            {
                                iconfiles = "icon-file-pdf1";
                            }
                            int lastindex = URLAttTitle.LastIndexOf('.');
                            string URLtitle = URLAttTitle.Substring(0, lastindex);
                            string HtmlAttachment ="<div class='boxfoo'>" +
                                                   "<span class='"+ iconfiles + "' style='font-size: 64px;color: #0d65b1;'></span>" +
                                                    "<p>" +
                                                        "<a href='#'>" + URLtitle + "</a>" +
                                                    "</p>" +
                                                    "<div class='buttonbottom'>" +
                                                        "<a href='"+ URLAtt + "' class='firicon'>" +
                                                            "<span class='icon-eye1' style='color:white;'>" +
                                                            "</span>" +
                                                       "</a>" +
                                                        "<a href='/_layouts/15/download.aspx?SourceUrl="+ URLAtt + "' class='secicon'>" +
                                                           " <span class='icon-download'>" +
                                                          "  </span>" +
                                                       " </a>" +
                                                   " </div>" +                                               
                                            "</div>";
                            System.Web.UI.HtmlControls.HtmlGenericControl newDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                            newDiv.Attributes.Add("class", "onefive");
                            newDiv.InnerHtml = HtmlAttachment;
                            AttachmentDiv.Controls.Add(newDiv);
                        }
                    }
                    
                    string CouncilTypename = new knowledgeCouncil().GetCouncilTypeByid(Convert.ToInt32(item.CouncilType), languageCode);

                    CouncilType.Text = CouncilTypename;
                    /////////////////////////////////////////
                    CouncilFeedbackEntity item2 = new CouncilFeedbackEntity();
                    item2.knowledgeCouncilID = Convert.ToString(Request.Params["RID"]);

                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                    if (currentUserlogin.ToLower().Equals(@"sharepoint\system"))
                    {
                        currentUserlogin = "i:" + HttpContext.Current.User.Identity.Name;

                    }

                    item2.loginName = currentUserlogin;

                    CouncilFeedbackEntity resalt = new CouncilFeedback().GetCouncilFeedback(item2);
                    if (resalt.ID > 0)
                    {
                        btnsubmit.Enabled = false;
                        btnsubmit.Visible = false;
                        SubjectCouncilCanBeDone.Value = Convert.ToString(resalt.SubjectCouncilCanBeDone);
                        TheBenefitFromTheCouncil.SelectedValue = Convert.ToString(resalt.TheBenefitFromTheCouncil);
                        DevelopmentProposalsForCouncil.Value = Convert.ToString(resalt.DevelopmentProposalsForCouncil);
                       
                        TheBenefitFromTheCouncil.Enabled = false;
                        DevelopmentProposalsForCouncil.Disabled = true;
                        SubjectCouncilCanBeDone.Disabled = true;
                    }
                    ParticipantsData();

                }
            }
        }
        private void GetDropDownTheBenefitFromTheCouncil()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            //DataTable dataC = new RequestAVacation().GetVacationsTypes();
            DataTable dataC = new CouncilFeedback().GetBenefitFromTheCouncil();





            TheBenefitFromTheCouncil.DataSource = dataC;
            TheBenefitFromTheCouncil.DataValueField = "ID";
            if (languageCode == "ar")
            {
                TheBenefitFromTheCouncil.DataTextField = "Title";
            }
            else
            {
                TheBenefitFromTheCouncil.DataTextField = "TitleEN";
            }

            TheBenefitFromTheCouncil.DataBind();
        }
        private void ParticipantsData()
        {
            try
            {


                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                if (currentUserlogin.ToLower().Equals(@"sharepoint\system"))
                {
                    currentUserlogin = "i:" + HttpContext.Current.User.Identity.Name;

                }
                knowledgeCouncil objKC = new knowledgeCouncil();
                List<ParticipantsCouncilEntity> ParticipantsData = objKC.GetParticipants(Convert.ToString(Request.Params["RID"]));
          
                foreach (ParticipantsCouncilEntity item in ParticipantsData)
                {
                    var nameis = "";
                    var JobTitleis = "";
                    var Roleis = "";
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    if (languageCode == "ar")
                    {
                        nameis = item.Name.ToString();
                        JobTitleis = item.JobTitle.ToString();
                        Roleis = item.Role.ToString();
                    }
                    else
                    {
                        nameis = item.NameEN.ToString();
                        JobTitleis = item.JobTitleEN.ToString();
                        Roleis = item.RoleEN.ToString();
                    }
                    var htmlrow1 = "<td>" + nameis + "</td>" +
                            "<td>" + JobTitleis + "</td>" +
                            "<td>" + Roleis + "</td>";                    

                           
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("tr");
                       
                        newDiv.InnerHtml = htmlrow1;
                    DivParticipants.Controls.Add(newDiv);

                    tableParticipants.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        protected void getExam(int CkID)
        {

            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                if (currentUserlogin.ToLower().Equals(@"sharepoint\system"))
                {
                    currentUserlogin = "i:" + HttpContext.Current.User.Identity.Name;

                    }
                btnCreateExam.Enabled = false;
                btnCreateExam.Visible = false;
               
              
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
                        LBresalt2.Text = SuccessfulMSG;

                        btn_PDFEmail.Enabled = true;
                        btn_PDFEmail.Visible = true;
                    }
                    else
                    {
                        LBresalt.Text = FailedMSG;
                        LBresalt2.Text = FailedMSG;
                    }
                    LBresalt.Text +=  " (" + Examiners .percentage+ ") ";
                    LBresalt2.Text +=  " (" + Examiners .percentage+ ") ";
                }
                List<CouncilExamEntity> itemData = new knowledgeCouncil().GetCouncilExam(CkID);
                if(itemData.Count <= 0){
                    btnsubmitexam.Enabled = false;
                    btnsubmitexam.Visible = false;
                    var ThereIsNoTestForThisCouncilMSG = SPUtility.GetLocalizedString("$Resources: ThereIsNoTestForThisCouncil", "Resource", SPContext.Current.Web.Language);

                    LBresalt2.Text = ThereIsNoTestForThisCouncilMSG;

                    ///////////////////////////////////////creatExiam/////
                    knowledgeCouncilEntity KCEntity = new knowledgeCouncil().GetknowledgeCouncilByID(Convert.ToInt32(Request.Params["RID"]));
                   
                    Departments Department = new Departments();
                    DepartmentsEntity DEnitiy= Department.GetbyDepartments(KCEntity.Department);
                   if (DEnitiy.DepartmentAdmin.User.LoginName.ToLower() == currentUserlogin.ToLower())
                    {
                        btnCreateExam.Enabled = true;
                        btnCreateExam.Visible = true;
                        

                    }
                }
               
                int x = 0;
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
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
                    string Questionis = "";
                    if (languageCode == "ar")
                    {
                        Questionis = item.Question;
                    }
                    else
                    {
                        Questionis = item.QuestionEN;
                    }


                    var htmlrow1 = "<div class='q-row'>" +
                            "<h2><label><asp:Literal runat='server' Text='" + Question + "' /></label></h2>" +
                            "<span>" + Questionis + "</span>" +
                        "</div>" +
                        "<h2 class='answerTitle'>" + ChooseTheAnswer + "</h2>" +
                        "<div class='poll-popup-answ'>";
                    string postin;
                   
                    if (languageCode == "ar")
                    {
                        postin = item.possibility1;
                    }
                    else
                    {
                        postin = item.possibilityEN1;
                    }
                    
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<input name='QuestionID' value='"+ item.ID + "' type='text' id='QuestionID" + x + "' style='display:none' placeholder=''>" +
                        "<input name='AnswerIs' value='' type='text' id='AnswerIs" + x + "' style='display:none' placeholder=''>" +
                         "<div class='radioComponent'><input "+ disabled + " type='radio' "+ checked1 + " onchange=\"handleChange('AnswerIs" + x + "','1');\"  name='common-radio-name" + x + "' id='radio-" + x + "' class='radio-button' />" +
                        "<label for='radio-" + x + "' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label></div>";
                    }
                    if (languageCode == "ar")
                    {
                        postin = item.possibility2;
                    }
                    else
                    {
                        postin = item.possibilityEN2;
                    }
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<div class='radioComponent'><input required " + disabled + " type='radio' " + checked2+ " onchange=\"handleChange('AnswerIs" + x + "','2');\"  name='common-radio-name" + x + "' id='radio-" + x + "' class='radio-button' />" +
                       "<label for='radio-" + x + "' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label></div>";
                    }
                    if (languageCode == "ar")
                    {
                        postin = item.possibility3;
                    }
                    else
                    {
                        postin = item.possibilityEN3;
                    }
                    if (!string.IsNullOrEmpty(postin))
                    {
                        htmlrow1 += "<div class='radioComponent'><input " + disabled + " type='radio' " + checked3+ " onchange=\"handleChange('AnswerIs" + x + "','3');\"  name='common-radio-name" + x + "' id='radio-" + x + "' class='radio-button' />" +
                       "<label for='radio-" + x + "' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + postin + "</label></div>";
                    }
                    if (languageCode == "ar")
                    {
                        postin = item.possibility4;
                    }
                    else
                    {
                        postin = item.possibilityEN4;
                    }
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
       
        protected void btnCreateExam_Click(object sender, EventArgs e)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            if (languageCode == "ar")
            {
                Response.Redirect("/Ar/KnowledgeGateway/Pages/CreateExam.aspx?RID="+ Convert.ToString(Request.Params["RID"]));
            }
            else
            {
                Response.Redirect("/En/KnowledgeGateway/Pages/CreateExam.aspx?RID="+ Convert.ToString(Request.Params["RID"]));
            }
        }
        protected void AddParticipants_Click(object sender, EventArgs e)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            if (languageCode == "ar")
            {
                Response.Redirect("/Ar/KnowledgeGateway/Pages/ParticipantsCouncil.aspx?RID=" + Convert.ToString(Request.Params["RID"]));
            }
            else
            {
                Response.Redirect("/En/KnowledgeGateway/Pages/ParticipantsCouncil.aspx?RID=" + Convert.ToString(Request.Params["RID"]));
            }
        }
        protected void ModifyCouncil_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("/Lists/knowledgeCouncil/EditForm.aspx?ID=" + Convert.ToString(Request.Params["RID"]));
           
        } protected void AllFeedback_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("/Lists/CouncilFeedback/AllItems.aspx#InplviewHash288ec745-79c3-4849-9c63-dbb6a9b220b2=FilterField1%3DknowledgeCouncilID-FilterValue1%3D" + Convert.ToString(Request.Params["RID"]));
           
        }
        protected void btnsubmitexam_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;

               
                if (currentUserlogin.ToLower().Equals(@"sharepoint\system"))
                {
                    currentUserlogin = "i:"  + HttpContext.Current.User.Identity.Name;

                }
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
                if (currentUserlogin.ToLower().Equals(@"sharepoint\system"))
                {
                    currentUserlogin = "i:" + HttpContext.Current.User.Identity.Name;
                }
                item.loginName = currentUserlogin;
                item.SubjectCouncilCanBeDone = Convert.ToString(SubjectCouncilCanBeDone.Value);
                item.TheBenefitFromTheCouncil = Convert.ToString(TheBenefitFromTheCouncil.SelectedValue);
                item.DevelopmentProposalsForCouncil = Convert.ToString(DevelopmentProposalsForCouncil.Value);
                bool resalt = new CouncilFeedback().SaveUpdate(item);
                btnsubmit.Enabled = false;
                btnsubmit.Visible = false;
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                if (languageCode == "ar")
                {
                    Response.Redirect("/Ar/KnowledgeGateway/Pages/HeldCouncilsDetail.aspx?RID=" + Convert.ToString(Request.Params["RID"]));
                }
                else
                {
                    Response.Redirect("/En/KnowledgeGateway/Pages/HeldCouncilsDetail.aspx?RID=" + Convert.ToString(Request.Params["RID"]));
                }
            }
        }

        [Obsolete]
        protected void btn_PDFEmail_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                if (!DesignMode)

                {
                    //add your initializing code (for runtime!) here



                    StringBuilder sb = new StringBuilder();
                    sb.Append("<header class='clearfix'>");
                    sb.Append("<h1>INVOICE</h1>");
                    sb.Append("<div id='company' class='clearfix'>");
                    sb.Append("<div>Company Name</div>");
                    sb.Append("<div>455 John Tower,<br /> AZ 85004, US</div>");
                    sb.Append("<div>(602) 519-0450</div>");
                    sb.Append("<div><a href='mailto:naser_asad@hotmail.com'>naser_asad@hotmail.com</a></div>");
                    sb.Append("</div>");
                    sb.Append("<div id='project'>");
                    sb.Append("<div><span>PROJECT</span> Website development</div>");
                    sb.Append("<div><span>CLIENT</span> John Doe</div>");
                    sb.Append("<div><span>ADDRESS</span> 796 Silver Harbour, TX 79273, US</div>");
                    sb.Append("<div><span>EMAIL</span> <a href='mailto:naser_asad@hotmail.com'>naser_asad@hotmail.com</a></div>");
                    sb.Append("<div><span>DATE</span> April 13, 2016</div>");
                    sb.Append("<div><span>DUE DATE</span> May 13, 2016</div>");
                    sb.Append("</div>");
                    sb.Append("</header>");
                    sb.Append("<main>");
                    sb.Append("<table>");
                    sb.Append("<thead>");
                    sb.Append("<tr>");
                    sb.Append("<th class='service'>SERVICE</th>");
                    sb.Append("<th class='desc'>DESCRIPTION</th>");
                    sb.Append("<th>PRICE</th>");
                    sb.Append("<th>QTY</th>");
                    sb.Append("<th>TOTAL</th>");
                    sb.Append("</tr>");
                    sb.Append("</thead>");
                    sb.Append("<tbody>");
                    sb.Append("<tr>");
                    sb.Append("<td class='service'>Design</td>");
                    sb.Append("<td class='desc'>Creating a recognizable design solution based on the company's existing visual identity</td>");
                    sb.Append("<td class='unit'>$400.00</td>");
                    sb.Append("<td class='qty'>2</td>");
                    sb.Append("<td class='total'>$800.00</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td colspan='4'>SUBTOTAL</td>");
                    sb.Append("<td class='total'>$800.00</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td colspan='4'>TAX 25%</td>");
                    sb.Append("<td class='total'>$200.00</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td colspan='4' class='grand total'>GRAND TOTAL</td>");
                    sb.Append("<td class='grand total'>$1,000.00</td>");
                    sb.Append("</tr>");
                    sb.Append("</tbody>");
                    sb.Append("</table>");
                    sb.Append("<div id='notices'>");
                    sb.Append("<div>NOTICE:</div>");
                    sb.Append("<div class='notice'>A finance charge of 1.5% will be made on unpaid balances after 30 days.</div>");
                    sb.Append("</div>");
                    sb.Append("</main>");
                    sb.Append("<footer>");
                    sb.Append("Invoice was created on a computer and is valid without the signature and seal.");
                    sb.Append("</footer>");


                    StringReader sr = new StringReader(sb.ToString());

                   Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    //iTextSharp.text.html.simpleparser.HTMLWorker jj;
                    iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();

                        htmlparser.Parse(sr);
                        pdfDoc.Close();

                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();


                        // Clears all content output from the buffer stream                 
                        Response.Clear();
                        // Gets or sets the HTTP MIME type of the output stream.
                        Response.ContentType = "application/pdf";
                        // Adds an HTTP header to the output stream
                        Response.AddHeader("Content-Disposition", "attachment; filename=Invoice.pdf");

                        //Gets or sets a value indicating whether to buffer output and send it after
                        // the complete response is finished processing.
                        Response.Buffer = true;
                        // Sets the Cache-Control header to one of the values of System.Web.HttpCacheability.
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        // Writes a string of binary characters to the HTTP output stream. it write the generated bytes .
                        Response.BinaryWrite(bytes);
                        // Sends all currently buffered output to the client, stops execution of the
                        // page, and raises the System.Web.HttpApplication.EndRequest event.

                        Response.End();
                        // Closes the socket connection to a client. it is a necessary step as you must close the response after doing work.its best approach.
                        Response.Close();
                    }


                }

            }
        }
    }
}

