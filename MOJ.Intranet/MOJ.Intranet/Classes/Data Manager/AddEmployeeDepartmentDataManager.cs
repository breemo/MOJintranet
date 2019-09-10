using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.DataManager
{
    public class AddEmployeeDepartmentDataManager
    {
        public bool AddEmployeeDepartment(SPUser user, string EmployeeDepartment)
        {
            bool isUpdated = false;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                try
                {
                    using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb myweb = mySitesCollection.OpenWeb())
                        {
                            string currentUserlogin = user.LoginName;
                            SPServiceContext context = SPServiceContext.GetContext(mySitesCollection);
                            UserProfileManager profileManager = new UserProfileManager(context);
                            UserProfile currentProfile = profileManager.GetUserProfile(currentUserlogin);
                            if (EmployeeDepartment != "")
                            {
                                currentProfile[PropertyConstants.Department].Value = EmployeeDepartment;
                                currentProfile.Commit();
                                isUpdated = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            });
            return isUpdated;
        }
    }
}
