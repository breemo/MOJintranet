using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class TravelInformationsEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string CountryResidentForMoreThan3Month { get; set; }
        public DateTime TimePeriodFrom { get; set; }      
        public DateTime TimeperiodTo { get; set; }
        public string VisitReasons { get; set; }
    }
}
