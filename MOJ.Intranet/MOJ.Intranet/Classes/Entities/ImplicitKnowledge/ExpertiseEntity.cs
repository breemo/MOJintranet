using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class ExpertiseEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string OrganizationName { get; set; }
        public string NatureOfTheJob { get; set; }        
        public string CountryID { get; set; }   
     
        public string YearsOfExperience { get; set; }
        public string Notes { get; set; }
    }
}
