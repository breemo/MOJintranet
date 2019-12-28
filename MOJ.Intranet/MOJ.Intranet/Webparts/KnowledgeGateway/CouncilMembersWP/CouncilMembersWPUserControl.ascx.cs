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
                        CouncilMembersitem.Title = Convert.ToString(Request.Params["Title"]);
                        CouncilMembersitem.loginName = currentUserlogin;

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
