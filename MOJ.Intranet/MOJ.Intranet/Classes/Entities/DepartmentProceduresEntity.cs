using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class DepartmentProceduresEntity
    {
        public int ID { get; set; }
        public string ProcedureTitle { get; set; }
        public DateTime ProcedureDate { get; set; }
        public string ProcedureBody { get; set; }
    }
}
