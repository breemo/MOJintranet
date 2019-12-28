using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class CouncilMembersEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string loginName { get; set; }
        public string Status { get; set; }
        public int knowledgeCouncilID { get; set; }

      
       
    }
}
