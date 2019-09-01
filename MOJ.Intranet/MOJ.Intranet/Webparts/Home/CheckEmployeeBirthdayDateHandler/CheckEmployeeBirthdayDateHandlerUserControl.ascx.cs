using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.CheckEmployeeBirthdayDateHandler
{
    public partial class CheckEmployeeBirthdayDateHandlerUserControl : UserControl
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
                            string currentUserlogin = currentUser.LoginName;
                            SPServiceContext context = SPServiceContext.GetContext(mySitesCollection);
                            UserProfileManager profileManager = new UserProfileManager(context);
                            UserProfile currentProfile = profileManager.GetUserProfile(currentUserlogin);
                            string EmployeeBithday = currentProfile[PropertyConstants.Birthday].Value != null ? currentProfile[PropertyConstants.Birthday].Value.ToString() : string.Empty;
                            if (!string.IsNullOrEmpty(EmployeeBithday))
                            {
                                DateTime EBithdayt = Convert.ToDateTime(EmployeeBithday);
                                string EmployeeBithdayOnlyMonth = string.Format("{0:MMMM dd}", EBithdayt, CultureInfo.GetCultureInfo("en-US"));
                                DateTime date = DateTime.Now;
                                string TodayDate = string.Format("{0:MMMM dd}", date);
                                if (EmployeeBithdayOnlyMonth == TodayDate)
                                {
                                    if (currentProfile[PropertyConstants.DelveFlags].Value == null || currentProfile[PropertyConstants.DelveFlags].Value.ToString() != DateTime.Now.Year.ToString())
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "EmployeeBirthdayPopUp();", true);
                                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "EmployeeBirthdayPopUp();", true);

                                    }
                                }
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
}
