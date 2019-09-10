using Microsoft.SharePoint;
using MOJ.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class AddEmployeeDepartmentBL
    {
        public bool AddEmployeeDepartment(SPUser _user, string _Departmentr)
        {
            return new AddEmployeeDepartmentBL().AddEmployeeDepartment(_user, _Departmentr);
        }
    }
}
