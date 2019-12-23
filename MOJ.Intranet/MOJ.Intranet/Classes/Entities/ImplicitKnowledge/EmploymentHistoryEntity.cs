using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class EmploymentHistoryEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string Designation { get; set; }
        public string OrganizationalUnit { get; set; }        
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
