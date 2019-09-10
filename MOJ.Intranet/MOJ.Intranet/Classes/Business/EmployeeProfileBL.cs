using Microsoft.Office.Server.UserProfiles;
using MOJ.DataManage;
using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class EmployeeProfileBL
    {
        public List<EmployeeProfileEntity> GetEmployeeProfile()
        {
            return new EmployeeProfileDataManager().GetEmployeeProfiles();
        }

        public DataTable GetEmployeeProfilewithFilter(string FieldToSearch,string value)
        {
            return new EmployeeProfileDataManager().GetEmployeeProfilesWithFilter(FieldToSearch,value);
        }
        public EmployeeProfileEntity GetShortUserProfile(UserProfile profile)
        {

        }
    }
}
