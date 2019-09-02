using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class CarOrderServiceEntity
    {
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string TravelNeeds { get; set; }
        public string PageName { get; set; }
        public string TravelTo { get; set; }
        public string TravelReason { get; set; }
        public string NameOfPassengers { get; set; }
        public string CarPlace { get; set; }
        public DateTime TravelDate { get; set; }
        public string Duration { get; set; }
        public string ApprovalBy { get; set; }
        public string ID { get; set; }
        public string Status { get; set; }
        public SPFieldUserValue CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
    
}
