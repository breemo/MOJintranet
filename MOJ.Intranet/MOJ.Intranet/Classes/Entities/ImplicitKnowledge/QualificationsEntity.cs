using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class QualificationsEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string Qualification { get; set; }
        public string Major { get; set; }        
        public string Institution { get; set; }        
        public DateTime GraduationYear { get; set; }
        public string CountryID { get; set; }
        public string CountryAr { get; set; }
        public string CountryEN { get; set; }
    }
}
