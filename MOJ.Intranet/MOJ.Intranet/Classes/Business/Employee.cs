using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class Employee
    {
        public bool SaveUpdate(EmployeeEntity obj)
        {
            return new EmployeeDataManager().AddOrUpdate(obj);
        }

        
    }
}
