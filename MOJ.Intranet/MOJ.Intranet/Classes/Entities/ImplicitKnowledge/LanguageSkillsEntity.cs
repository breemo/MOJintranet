using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class LanguageSkillsEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string Language { get; set; }
        public string ReadinglevelID { get; set; }        
        public string WritinglevelID { get; set; }   
        public string ConversationlevelID { get; set; }
     
    }
}
