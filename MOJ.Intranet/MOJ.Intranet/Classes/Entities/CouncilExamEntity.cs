using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class CouncilExamEntity
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public int knowledgeCouncilID { get; set; }        
        public int Answer { get; set; }        
        public string possibility1 { get; set; }        
        public string possibility2 { get; set; }        
        public string possibility3 { get; set; }        
        public string possibility4 { get; set; }        
           

    }
}
