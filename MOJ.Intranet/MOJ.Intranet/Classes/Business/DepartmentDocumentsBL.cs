using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class DepartmentDocumentsBL
    {
        public List<DepartmentDocumentsEntity> GetDepartmentDocuments()
        {
            return new DepartmentDocumentsDataManager().GetDepartmentDocuments();
        }
        public List<DepartmentDocumentsEntity> GetAllDocuments()
        {
            return new DepartmentDocumentsDataManager().GetAllDocuemts();
        }
    }
}
