using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class DepartmentCirculars
    {
        public List<DepartmentCircularsEntity> GetDepartmentCirculars()
        {
            return new DepartmentCircularsDataManager().GetDepartmentCirculars();
        }
        public DepartmentCircularsEntity GetDepartmentCircularsByID(int id)
        {
            return new DepartmentCircularsDataManager().GetDepartmentCircularsByID(id);
        }
    }
}
