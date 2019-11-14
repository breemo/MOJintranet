using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.AddEmployeeDepartment
{
    public partial class AddEmployeeDepartmentUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetDepartments();
            }
        }
        private void GetDepartments()
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.DepartmentsListUrl);
                                if (lst != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.DepartmentsQuery;
                                    oQuery.ViewFields = SharedConstants.Departmentsfields;
                                    SPListItemCollection lstItems = lst.GetItems(oQuery);

                                    ddlDepartments.Items.Insert(0, new ListItem(SPUtility.GetLocalizedString("$Resources: ddlSelect", "Resource", SPContext.Current.Web.Language), ""));
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        ddlDepartments.Items.Add(lstItem["Title"].ToString());
                                    }
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

                        if (ddlDepartments.SelectedIndex != 0)
                        {
                            bool UpdateUserProfile = new AddEmployeeDepartmentBL().AddEmployeeDepartment(currentUser, ddlDepartments.SelectedValue.ToString());
                            if (UpdateUserProfile == true)
                            {
                                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                                if (languageCode == "ar")
                                    Page.Response.Redirect("/ar");
                                else
                                    Page.Response.Redirect("/en");
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
