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

namespace MOJ.Intranet.Webparts.KnowledgeGateway.CreateExamWP
{
    public partial class CreateExamWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Convert.ToString(Request.Params["RID"])))
                {
                    posts.Style.Add("display", "none");
                    
                           btnsubmit.Enabled = false;
                    btnsubmit.Visible = false;
                }
                else {
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                    knowledgeCouncilEntity KCEntity = new knowledgeCouncil().GetknowledgeCouncilByID(Convert.ToInt32(Request.Params["RID"]));

                    Departments Department = new Departments();
                    DepartmentsEntity DEnitiy = Department.GetbyDepartments(KCEntity.Department);
                    if (DEnitiy.DepartmentAdmin.User.LoginName != currentUserlogin)
                    {
                        CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                        if (languageCode == "ar")
                        {
                            Response.Redirect("/Ar/KnowledgeGateway/Pages/KnowledgeCouncils.aspx");
                        }
                        else
                        {
                            Response.Redirect("/En/KnowledgeGateway/Pages/KnowledgeCouncils.aspx");
                        }

                    }
                    AddAnswer();
                    PassPercentage();
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {

            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();

            if (languageCode == "ar")
            {
                Response.Redirect("/Ar/KnowledgeGateway/Pages/HeldCouncilsDetail.aspx?RID="+ Convert.ToString(Request.Params["RID"]));

            }
            else
            {
                Response.Redirect("/En/KnowledgeGateway/Pages/HeldCouncilsDetail.aspx?RID="+ Convert.ToString(Request.Params["RID"]));
            }

        }
        private void AddAnswer()
        {
            string Possibility1 = SPUtility.GetLocalizedString("$Resources: FirstPossibility", "Resource", SPContext.Current.Web.Language);
            string Possibility2 = SPUtility.GetLocalizedString("$Resources: SecondPossibility", "Resource", SPContext.Current.Web.Language);
            string Possibility3 = SPUtility.GetLocalizedString("$Resources: ThirdPossibility", "Resource", SPContext.Current.Web.Language);
            string Possibility4 = SPUtility.GetLocalizedString("$Resources: FourthPossibility", "Resource", SPContext.Current.Web.Language);

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem(Possibility1, "1"));
            items.Add(new ListItem(Possibility2, "2"));
            items.Add(new ListItem(Possibility3, "3"));
            items.Add(new ListItem(Possibility4, "4"));
            DropDownAnswer.Items.AddRange(items.ToArray());
        }
        private void PassPercentage()
        { List<ListItem> items = new List<ListItem>();            
            items.Add(new ListItem("40", "40"));
            items.Add(new ListItem("50", "50"));
            items.Add(new ListItem("60", "60"));
            items.Add(new ListItem("70", "70"));
            items.Add(new ListItem("80", "80"));
            DropDownPassPercentage.Items.AddRange(items.ToArray());
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                try
                {
                    List<CouncilExamEntity> list1 = new List<CouncilExamEntity>();
                    CouncilExamEntity Entit1 = new CouncilExamEntity();
                    if (!string.IsNullOrEmpty(Question0.Value))
                    {
                        Entit1.knowledgeCouncilID =Convert.ToInt32(Request.Params["RID"]);
                        Entit1.Question = Question0.Value;
                        Entit1.possibility1 = Possibility1_0.Value;
                        Entit1.possibility2 = Possibility2_0.Value;
                        Entit1.possibility3 = Possibility3_0.Value;
                        Entit1.possibility4 = Possibility4_0.Value;
                        Entit1.QuestionEN = QuestionEN0.Value;
                        Entit1.possibilityEN1 = PossibilityEN1_0.Value;
                        Entit1.possibilityEN2 = PossibilityEN2_0.Value;
                        Entit1.possibilityEN3 = PossibilityEN3_0.Value;
                        Entit1.possibilityEN4 = PossibilityEN4_0.Value;
                        Entit1.Answer = Convert.ToInt32(DropDownAnswer.SelectedValue);
                        list1.Add(Entit1);
                    }
                    if (hdnsuperDIV1.Value != "" && hdnsuperDIV1.Value != "0")
                    {
                        string[] Question = Request.Form.GetValues("Question");
                        string[] Possibility1 = Request.Form.GetValues("Possibility1");
                        string[] Possibility2 = Request.Form.GetValues("Possibility2");
                        string[] Possibility3 = Request.Form.GetValues("Possibility3");
                        string[] Possibility4 = Request.Form.GetValues("Possibility4");
                        string[] QuestionEN = Request.Form.GetValues("QuestionEN");
                        string[] PossibilityEN1 = Request.Form.GetValues("PossibilityEN1");
                        string[] PossibilityEN2 = Request.Form.GetValues("PossibilityEN2");
                        string[] PossibilityEN3 = Request.Form.GetValues("PossibilityEN3");
                        string[] PossibilityEN4 = Request.Form.GetValues("PossibilityEN4");
                        string[] DropDownAnswer = Request.Form.GetValues("DropDownAnswer");
                        for (int x = 0; x < Convert.ToInt32(Question.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Question[x]))
                            {
                                CouncilExamEntity Entit2 = new CouncilExamEntity();
                                Entit2.knowledgeCouncilID = Convert.ToInt32(Request.Params["RID"]);
                                Entit2.Question = Question[x];
                                Entit2.possibility1 = Possibility1[x];
                                Entit2.possibility2 = Possibility2[x];
                                Entit2.possibility3 = Possibility3[x];
                                Entit2.possibility4 = Possibility4[x];
                                Entit2.QuestionEN = QuestionEN[x];
                                Entit2.possibilityEN1 = PossibilityEN1[x];
                                Entit2.possibilityEN2 = PossibilityEN2[x];
                                Entit2.possibilityEN3 = PossibilityEN3[x];
                                Entit2.possibilityEN4 = PossibilityEN4[x];
                                Entit2.Answer = Convert.ToInt32(DropDownAnswer[x]);
                                list1.Add(Entit2);
                            }
                        }
                    }
                    CreateExam CExam = new CreateExam();
                    knowledgeCouncilEntity objpass = new knowledgeCouncilEntity();
                    objpass.ID = Convert.ToInt32(Request.Params["RID"]);
                    objpass.PassPercentage = Convert.ToInt32(DropDownPassPercentage.SelectedValue);

                    bool issave1 = CExam.UpdatePassPercentage(objpass);
                    bool issave = CExam.SaveUpdate(list1);

                    if (issave)
                    {
                        lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: TheExamWasCreatedSuccessfully", "Resource", SPContext.Current.Web.Language) + "<br />";
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
