using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class DepartmentProcedures
    {
        public List<DepartmentProceduresEntity> GetDepartmentProcedures()
        {
            return new DepartmentProceduresDataManager().GetDepartmentProcedures();
        }
        public DepartmentProceduresEntity GetDepartmentProceduresByID(int id)
        {
            return new DepartmentProceduresDataManager().GetDepartmentProceduresByID(id);
        }
    }
}
