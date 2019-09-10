using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.DataManage
{
    public class EmployeeProfileDataManager
    {
        public List<EmployeeProfileEntity> GetEmployeeProfiles()
        {
            List<EmployeeProfileEntity> Employeelst = new List<EmployeeProfileEntity>();
            EmployeeProfileEntity Employee = new EmployeeProfileEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPServiceContext serverContext = SPServiceContext.GetContext(oSite);
                            UserProfileManager profileManager = new UserProfileManager(serverContext);
                            foreach (UserProfile _Profile in profileManager)
                            {
                                Employee.AccountName = Convert.ToString(_Profile[PropertyConstants.AccountName].Value);
                                Employee.Email = Convert.ToString(_Profile[PropertyConstants.WorkEmail].Value);
                                Employee.Department = Convert.ToString(_Profile[PropertyConstants.Department].Value);
                                Employee.JobTitle = Convert.ToString(_Profile[PropertyConstants.JobTitle].Value);
                                Employee.OfficeNumber = Convert.ToString(_Profile[PropertyConstants.WorkPhone].Value);
                                Employee.OfficeLocation = Convert.ToString(_Profile[PropertyConstants.Location].Value);

                                Employeelst.Add(Employee);
                            }
                        }
                    }
                }
            });
            return Employeelst;
        }
        public DataTable GetEmployeeProfilesWithFilter(string FieldToSearch, string Value)
        {
            DataTable dtProfile = new DataTable();
            DataRow dr;
            dtProfile.Columns.Add("AccountName");
            dtProfile.Columns.Add("WorkEmail");
            dtProfile.Columns.Add("Department");
            dtProfile.Columns.Add("JobTitle");
            dtProfile.Columns.Add("OfficeNumber");


            List<EmployeeProfileEntity> Employeelst = new List<EmployeeProfileEntity>();
            EmployeeProfileEntity Employee = new EmployeeProfileEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPServiceContext serverContext = SPServiceContext.GetContext(oSite);
                            UserProfileManager profileManager = new UserProfileManager(serverContext);
                            foreach (UserProfile _Profile in profileManager)
                            {
                                dr = dtProfile.NewRow();
                                dr["AccountName"] = Convert.ToString(_Profile[PropertyConstants.AccountName].Value);
                                dr["WorkEmail"] = Convert.ToString(_Profile[PropertyConstants.WorkEmail].Value);
                                dr["Department"] = Convert.ToString(_Profile[PropertyConstants.Department].Value);
                                dr["JobTitle"] = Convert.ToString(_Profile[PropertyConstants.JobTitle].Value);
                                dr["OfficeNumber"] = Convert.ToString(_Profile[PropertyConstants.Location].Value);

                                dtProfile.Rows.Add(dr);
                            }

                            if (Value != "")
                                dtProfile.DefaultView.RowFilter = FieldToSearch + "Like '%" + Value + "%'";
                        }
                    }
                }
            });
            return dtProfile;
        }

        public EmployeeProfileEntity GetShortUserProfile(UserProfile profile)
        {
            try
            {
                EmployeeProfileEntity currEmployee = new EmployeeProfileEntity();

                //currEmployee.EmployeeID = profile["employeeID"].Value.ToSafeString();
                currEmployee.AccountName = Convert.ToString(profile[PropertyConstants.AccountName].Value);
                currEmployee.Email = Convert.ToString(profile[PropertyConstants.WorkEmail].Value);
                //currEmployee.OfficeNumber = Convert.ToString(profile[PropertyConstants.WorkPhone].Value);
                //currEmployee.PhoneNumber = Convert.ToString(profile[PropertyConstants.CellPhone].Value);
                currEmployee.Department = Convert.ToString(profile[PropertyConstants.Department].Value);
                currEmployee.JobTitle = Convert.ToString(profile[PropertyConstants.JobTitle].Value);
                currEmployee.OfficeNumber = Convert.ToString(profile[PropertyConstants.WorkPhone].Value);
                currEmployee.OfficeLocation = Convert.ToString(profile[PropertyConstants.Location].Value);


                return currEmployee;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
    }
}
