using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class TechnicalSkillsEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string SkillType { get; set; }
        public string SkilllevelID { get; set; }        
        public string AreaOfApplication { get; set; }   
        public string Notes { get; set; }
     
    }
}
