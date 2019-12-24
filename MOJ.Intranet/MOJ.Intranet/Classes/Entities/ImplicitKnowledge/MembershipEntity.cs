using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class MembershipEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string Membership { get; set; }
        public string Location { get; set; }        
        public string Field { get; set; }        
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Notes { get; set; }
    }
}
