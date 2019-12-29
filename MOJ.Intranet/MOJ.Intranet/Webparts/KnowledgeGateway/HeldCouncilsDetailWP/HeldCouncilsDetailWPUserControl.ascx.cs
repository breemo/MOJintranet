using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
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
                    knowledgeCouncilEntity item = new knowledgeCouncil().GetHappinessHotline(Convert.ToInt32(Request.Params["RID"]));
                    CouncilNo.Text =    Convert.ToString(item.CouncilNo);
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

