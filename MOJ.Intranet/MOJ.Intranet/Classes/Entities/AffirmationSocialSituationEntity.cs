using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class AffirmationSocialSituationEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Created { get; set; }
        public string ChangeDate { get; set; }
        
        public string Name { get; set; }

        public string RelationshipType { get; set; }
        public string ChangeReason { get; set; }
        public string HusbandORWife { get; set; }
        

    }
}
