using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.CheckEmployeeNumberHandler
{
    public partial class CheckEmployeeNumberHandlerUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb myweb = mySitesCollection.OpenWeb())
                        {
                            SPUser currentUser = myweb.CurrentUser;

                            string EmployeeID = CommonLibrary.Methods.GetEmployeeID(currentUser);

                            if (string.IsNullOrEmpty(EmployeeID))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "showModalPopUp();", true);
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "showModalPopUp();", true);
                            }
                            #region old Code
                            //string currentUserlogin = currentUser.LoginName;
                            //SPServiceContext context = SPServiceContext.GetContext(mySitesCollection);
                            //UserProfileManager profileManager = new UserProfileManager(context);
                            //UserProfile currentProfile = profileManager.GetUserProfile(currentUserlogin);

                            //if (currentProfile.GetProfileValueCollection(ConfigurationManager.AppSettings["ADAttributesEmployeeID"].ToString()).Count == 0)
                            //{

                            //}
                            #endregion
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
}
