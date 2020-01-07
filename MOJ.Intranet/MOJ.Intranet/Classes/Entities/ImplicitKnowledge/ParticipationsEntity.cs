using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class ParticipationsEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string ActivityName { get; set; }
        public string Sponsor { get; set; }      
        public string CountryID { get; set; }
        public string NatureOfTheParticipation { get; set; }
    }
}
