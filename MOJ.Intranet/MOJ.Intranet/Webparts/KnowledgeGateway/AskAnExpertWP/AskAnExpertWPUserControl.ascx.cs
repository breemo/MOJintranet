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

namespace MOJ.Intranet.Webparts.KnowledgeGateway.AskAnExpertWP
{
    public partial class AskAnExpertWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetLookup();
                BindData();
            }          
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
               
                BindData();

            }
        }
        private void GetLookup()
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
                                SPList lst2 = oWeb.GetListFromUrl(oSite.Url + SharedConstants.DepartmentsUrl);
                                if (lst2 != null)
                                {
                                    List<ListItem> items = new List<ListItem>();
                                    items.Add(new ListItem("", ""));
                                    SPQuery qry1 = new SPQuery();
                                    string camlquery1 = "<Where></Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                    qry1.Query = camlquery1;
                                    SPListItemCollection listItemsCollection1 = lst2.GetItems(qry1);
                                    foreach (SPListItem Item in listItemsCollection1)
                                    {
                                        items.Add(new ListItem(Convert.ToString(Item["Title"]), Convert.ToString(Item["Title"])));
                                    }
                                    DropDownDepartment.Items.AddRange(items.ToArray());
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
        private void BindData()
        {
            if (!_isRefresh)
            {
                string Departmentvalue = "";
                if (!string.IsNullOrEmpty(DropDownDepartment.SelectedValue))
                {
                    Departmentvalue = Convert.ToString(DropDownDepartment.SelectedValue);
                }
                string Titlevalue = "";
                if (!string.IsNullOrEmpty(Topic.Value))
                {
                    Titlevalue = Convert.ToString(Topic.Value);
                }
                try
                {
                 List<AskAnExpertEntity> Collection = new AskAnExpert().GetAskAnExpert(0,Departmentvalue, Titlevalue);
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;

                    var htmlrow1 = "<dl>";
                    foreach (AskAnExpertEntity item in Collection)
                    {
                        //CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                        //string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();

                        htmlrow1 += "<dt>" + item.QuestionTitle + "</dt>" +
                                       "<dd>" +
                                         "<div class='questionbox'>" +
                                               "<div class='queshead'>" +
                                                  "<p class='fiteml'>" + item.EmployeeName + " </p>" +
                                                  "<p>" + item.EmployeePosition + "</p>" +
                                               "</div>" +
                                               "<div class='quesbody'>" +
                                                   "<p>" + item.QuestionDetails + "</p>" +
                                               "</div>" +
                                           "</div>";
                        List<AskAnExpertAnswerEntity> CollectionAnswer = new AskAnExpert().GetAskAnExpertAnswerByID(Convert.ToInt32(item.ID));
                        foreach (AskAnExpertAnswerEntity itemAnswer in CollectionAnswer)
                        {

                            htmlrow1 += " <div class='answerbox'>" +
                                               "<div class='queshead'>" +
                                                  "<p class='fiteml'>" +
                                                     itemAnswer.ExpertName + 
                                                  "</p>" +
                                                  "<p>"+ itemAnswer.ExpertPosition + "</p> " +
                                               "</div>" +
                                               "<div class='quesbody'>" +
                                                  "<p>" +
                                                  itemAnswer.Answer + 
                                                  "</p>" +
                                              "</div>" +
                                              "</div>  ";

                        }


                                                   htmlrow1 += "</dd> ";
                    }
                    htmlrow1 += "</dl>";
                    System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    newDiv.Attributes.Add("class", "new");
                    newDiv.InnerHtml = htmlrow1;
                    questions.Controls.Add(newDiv);


                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }
    }
}
