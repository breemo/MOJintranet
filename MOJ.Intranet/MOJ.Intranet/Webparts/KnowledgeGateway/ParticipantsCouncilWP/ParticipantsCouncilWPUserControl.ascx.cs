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
using System.Web;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.ParticipantsCouncilWP
{
    public partial class ParticipantsCouncilWPUserControl : SiteUI
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
                else
                {
                    
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                    if (currentUserlogin.ToLower().Equals(@"sharepoint\system"))
                    {
                        currentUserlogin = "i:" + HttpContext.Current.User.Identity.Name;

                    }
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
                    Data();
                }
            }
        }
        private void Data()
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
                int x = 0;
                foreach (ParticipantsCouncilEntity item in ParticipantsData)
                {
                    if (x == 0)
                    {
                        SID0.Value = item.ID.ToString();
                        RetrevehdnsuperDIV1.Value = item.ID.ToString() + "#";
                        ArabicName_0.Value = item.Name;
                        EnglishName_0.Value = item.NameEN;
                        ArabicJobTitle_0.Value = item.JobTitle;
                        EnglishJobTitle_0.Value = item.JobTitleEN;
                        ArabicRole_0.Value = item.Role;
                        EnglishRole_0.Value = item.RoleEN;
                        
                    }
                    else
                    {
                        hdnsuperDIV1.Value = Convert.ToString(x);
                        RetrevehdnsuperDIV1.Value += item.ID.ToString() + "#";

                        var htmlrow1 = "<div class='rowI '> " +

                        " <div class='row'> <div class='col-md-1 DiveDelete '>" +
                                 "<span style='padding-right: 25px;margin-top: -15px;' onclick='removeParticipants(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>" +
                                  " </div></div>" +
                        "</div>" +
                    "<div class='row rt'>" +
                        "<div class='DivSID' style=' display: none;'><input name='SID' value='" + item.ID.ToString() + "' type='text' id='SID" + x + "' class='form-control' placeholder=''></div> " +
                        "<div class='col-md-2 DivArabicName'><input name='ArabicName' value='" + item.Name.ToString() + "' type='text' id='ArabicName" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivEnglishName'><input name='EnglishName' value='" + item.NameEN.ToString() + "' type='text' id='EnglishName" + x + "' class='form-control' placeholder=''></div>" +

                        "<div class='col-md-2 DivArabicJobTitle'><input name='ArabicJobTitle' value='" + item.JobTitle.ToString() + "' type='text' id='ArabicJobTitle" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivEnglishJobTitle'><input name='EnglishJobTitle' value='" + item.JobTitleEN.ToString() + "' type='text' id='EnglishJobTitle" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivArabicRole'><input name='ArabicRole' value='" + item.Role.ToString() + "' type='text' id='ArabicRole" + x + "' class='form-control' placeholder=''></div>" +
                        "<div class='col-md-2 DivEnglishRole'><input name='EnglishRole' value='" + item.RoleEN.ToString() + "' type='text' id='EnglishRole" + x + "' class='form-control' placeholder=''></div>" +
                         
                       
                "</div>";
                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "cnrtnheadbox2");
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

        protected void btnBack_Click(object sender, EventArgs e)
        {

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
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                try
                {
                    string knowledgeCouncilID = Convert.ToString(Request.Params["RID"]);
                    List<ParticipantsCouncilEntity> list = new List<ParticipantsCouncilEntity>();
                    ParticipantsCouncilEntity Entit = new ParticipantsCouncilEntity();
                    if (!string.IsNullOrEmpty(ArabicName_0.Value))
                    {
                        Entit.JobTitle = ArabicJobTitle_0.Value;
                        Entit.JobTitleEN = EnglishJobTitle_0.Value.ToString();
                        Entit.knowledgeCouncil = Convert.ToInt32(knowledgeCouncilID);
                        Entit.Name = ArabicName_0.Value;
                        Entit.NameEN = EnglishName_0.Value;
                        Entit.Role = ArabicRole_0.Value;
                        Entit.RoleEN = EnglishRole_0.Value;
                        if (!string.IsNullOrEmpty(SID0.Value))
                        {
                            Entit.ID = Convert.ToInt32(SID0.Value);
                            RetrevehdnsuperDIV1.Value = RetrevehdnsuperDIV1.Value.Replace(Entit.ID + "#", "");
                        }                       
                        list.Add(Entit);
                    }
                    if (hdnsuperDIV1.Value != "" && hdnsuperDIV1.Value != "0")
                    {
                        string[] SID = Request.Form.GetValues("SID");
                        string[] ArabicName = Request.Form.GetValues("ArabicName");
                        string[] EnglishName = Request.Form.GetValues("EnglishName");
                        string[] ArabicJobTitle = Request.Form.GetValues("ArabicJobTitle");
                        string[] EnglishJobTitle = Request.Form.GetValues("EnglishJobTitle");
                        string[] ArabicRole = Request.Form.GetValues("ArabicRole");
                        string[] EnglishRole = Request.Form.GetValues("EnglishRole");
                        for (int x = 0; x < Convert.ToInt32(ArabicName.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(ArabicName[x]))
                            {
                                ParticipantsCouncilEntity ob = new ParticipantsCouncilEntity();
                                ob.JobTitle = ArabicJobTitle[x];
                                ob.JobTitleEN = EnglishJobTitle[x];
                                ob.knowledgeCouncil = Convert.ToInt32(knowledgeCouncilID);
                                ob.Name = ArabicName[x];
                                ob.NameEN = EnglishName[x];
                                ob.Role = ArabicRole[x];
                                ob.RoleEN = EnglishRole[x];
                           
                                if (!string.IsNullOrEmpty(SID[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID[x]);
                                    RetrevehdnsuperDIV1.Value = RetrevehdnsuperDIV1.Value.Replace(ob.ID + "#", "");
                                }
                                list.Add(ob);
                            }
                        }
                    }
                    knowledgeCouncil objKC = new knowledgeCouncil();
                    bool issave =objKC.SaveUpdateParticipantsCouncil(list);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV1.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV1.Value.Split('#');
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
                            objKC.DeleteitemsFromSublist("ParticipantsCouncil", ListSID1);
                        }
                    }
                  
                    
                       
                  
                    if (issave)
                    {
                        lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: ParticipantsHaveBeenAdded", "Resource", SPContext.Current.Web.Language) + "<br />";
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
