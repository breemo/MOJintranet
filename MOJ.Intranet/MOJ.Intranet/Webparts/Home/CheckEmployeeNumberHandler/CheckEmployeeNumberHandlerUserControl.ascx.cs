using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
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
                            CultureInfo currentCulture2 = Thread.CurrentThread.CurrentUICulture;
                            string languageCode = currentCulture2.TwoLetterISOLanguageName.ToLowerInvariant();

                            string PageURL = "";

                            if (languageCode == "ar")
                            {
                                PageURL = "/Ar/Pages/AddEmployeeDepartment.aspx";
                            }
                            else
                            {
                                PageURL = "/En/Pages/AddEmployeeDepartment.aspx";
                            }


                            SPUser currentUser = myweb.CurrentUser;
                            if (currentUser.ToString() != "SHAREPOINT\\system")
                            {
                                string EmployeeDepartment = CommonLibrary.Methods.GetEmployeeDepartment(currentUser);
                                string EmployeeID = CommonLibrary.Methods.GetEmployeeID(currentUser);

                                if (string.IsNullOrEmpty(EmployeeDepartment))
                                {
                                    Response.Redirect(PageURL, false);
                                }
                                else
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                                    {
                                        using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                                        {
                                            using (SPWeb web = site.RootWeb)
                                            {
                                                SPList DepartmentList = web.GetListFromUrl(site.Url + "/Lists/Departments/AllItems.aspx");
                                                if (DepartmentList != null)
                                                {
                                                    SPQuery oQuery = new SPQuery();
                                                    oQuery.Query = @"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + EmployeeDepartment + "</Value></Eq></Where>";
                                                    SPListItemCollection lstItems = DepartmentList.GetItems(oQuery);
                                                    if (lstItems.Count == 0)
                                                        Response.Redirect(PageURL, false);
                                                }
                                            }
                                        }
                                    });
                                }

                                if (string.IsNullOrEmpty(EmployeeID))
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "showModalPopUp();", true);
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "showModalPopUp();", true);
                                }
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
