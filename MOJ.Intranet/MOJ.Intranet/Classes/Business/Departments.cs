using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class Departments
    {
        public DepartmentsEntity GetbyDepartments(string Department)
        {
            return new DepartmentsDataManager().GetbyDepartments(Department);
        }
    }
}
