using Microsoft.SharePoint;
using MOJ.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class AddEmployeeNumberBL
    {
        public bool AddEmployeeEnumber(SPUser _user,string _EmployeeNumber)
        {
            return new AddEmployeeNumberDataManger().AddEmployeeEnumber(_user, _EmployeeNumber);
        }
    }
}
