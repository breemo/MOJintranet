using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class DepartmentsDescription
    {      
        public List<DepartmentsDescriptionEntity> GetDepartmentsDescription( string Departmentvalue)
        {
            return new DepartmentsDescriptionDataManager().GetDepartmentsDescription( Departmentvalue);
        }
      


    }
}
