using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class CouncilExaminersEntity
    {
        public int ID { get; set; }
        public int knowledgeCouncilID { get; set; }        
        public int knowledgeCouncil { get; set; }        
        public string loginName { get; set; }        
        public string Resalt { get; set; }        
        public string percentage { get; set; }    
        public DateTime Created { get; set; }    
           

    }
}
