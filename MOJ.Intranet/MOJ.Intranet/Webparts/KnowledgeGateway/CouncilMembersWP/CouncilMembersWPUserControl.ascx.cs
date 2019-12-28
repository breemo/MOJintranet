using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Entities.ImplicitKnowledge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.CouncilMembersWP
{
    public partial class CouncilMembersWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["TID"]))
                {
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                     CouncilMembersEntity CouncilMembersEntity = new CouncilMembers().GetMemberID(Convert.ToInt32(Request.Params["TID"]), currentUserlogin);
                   int memberID = CouncilMembersEntity.ID;
                    if (memberID == 0)
                    {

                        CouncilMembersEntity CouncilMembersitem = new CouncilMembersEntity();
                        CouncilMembersitem.knowledgeCouncilID = Convert.ToInt32(Request.Params["TID"]);
                        string RecordPrfix = "";
                        RecordPrfix = "CouncilMembers-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("CouncilMembers");

                        CouncilMembersitem.Title = RecordPrfix;
                        CouncilMembersitem.CouncilTopic = Convert.ToString(Request.Params["Title"]);
                        CouncilMembersitem.loginName = currentUserlogin;
                        try
                        {
                            ImplicitKnowledge objIK = new ImplicitKnowledge();
                            ImplicitKnowledgeEntity Employment = objIK.GetImplicitKnowledge(currentUserlogin);
                            if (Employment.ID > 0)
                            {
                                CouncilMembersitem.UserName = Employment.Name.ToString();
                            }
                            SPSecurity.RunWithElevatedPrivileges(delegate ()
                            {
                                using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                                {
                                    using (SPWeb web = site.OpenWeb())
                                    {
                                        SPUser user = SPContext.Current.Web.CurrentUser;
                                        SPUser CurrentUser = user;
                                        var userLoginName = CurrentUser.LoginName;
                                        SPServiceContext serviceContext = SPServiceContext.GetContext(site);
                                        var profileManager = new UserProfileManager(serviceContext);
                                        String[] breakApart = userLoginName.Split('|');
                                        var accountName = breakApart[1];
                                        var userProfile = profileManager.GetUserProfile(accountName);
                                        var Department = userProfile["Department"].Value != null
                                            ? userProfile["Department"].Value.ToString()
                                            : "";
                                        CouncilMembersitem.Department = Department;
                                    }
                                }
                            });
                        }
                        catch (Exception ex)
                        {

                            LoggingService.LogError("WebParts", ex.Message);
                        }
                        

                        bool isSave = new CouncilMembers().SaveUpdate(CouncilMembersitem);
                        if (isSave)
                        {
                            lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: YourRequestToJoinSuccessfully", "Resource", SPContext.Current.Web.Language) + "<br />";
                        }
                        else
                        {
                            lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: TheJoinRequestHasNoBeenSent", "Resource", SPContext.Current.Web.Language) + "<br />";

                        }
                    }
                    else
                    {
                        lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: YouHaveAlreadySentAJoinRequest", "Resource", SPContext.Current.Web.Language) + "<br />";
                     }
                }
                else
                {
                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: TheJoinRequestHasNoBeenSent", "Resource", SPContext.Current.Web.Language) + "<br />";
                   
                }
            }
        }
    }
}
