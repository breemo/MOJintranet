using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using MOJ.Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.AddEmployeeNumber
{
    public partial class AddEmployeeNumberUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errormsg.Style.Add("display", "none");
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb myweb = mySitesCollection.OpenWeb())
                    {
                        SPUser currentUser = myweb.CurrentUser;
                        string currentUserlogin = currentUser.LoginName;
                        SPServiceContext context = SPServiceContext.GetContext(mySitesCollection);
                        UserProfileManager profileManager = new UserProfileManager(context);
                        UserProfile currentProfile = profileManager.GetUserProfile(currentUserlogin);
                        string email = currentProfile[PropertyConstants.WorkEmail].Value != null ? currentProfile[PropertyConstants.WorkEmail].Value.ToString() : string.Empty;

                        if (txtEmployeeNumber.Value != "" && txtEmployeeNumber.Value == txtEmployeeNumberMatch.Value && txtEmail.Value == email)
                        {
                            errormsg.Style.Add("display", "none");
                            bool UpdateUserProfile = new AddEmployeeNumberBL().AddEmployeeEnumber(currentUser, txtEmployeeNumber.Value);
                            if (UpdateUserProfile == true)
                            {
                                Context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup();</script>");
                                Context.Response.Write("<script type='text/javascript'>window.opener.location.reload();</script>");
                                Context.Response.Write("<script type='text/javascript'>window.location.reload();</script>");
                                Context.Response.Flush();
                                Context.Response.End();
                            }
                        }
                        else
                        {
                            errormsg.Style.Add("display", "block");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }

        }
    }
}
