using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class ParticipantsCouncilEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }           
        public string NameEN { get; set; }        
        public string JobTitle { get; set; }        
        public string JobTitleEN { get; set; }        
        public string Role { get; set; }        
        public string RoleEN { get; set; }        
        public int knowledgeCouncil { get; set; }        
 

    }
}
