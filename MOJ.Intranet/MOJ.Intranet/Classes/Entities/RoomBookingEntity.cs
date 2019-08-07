using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class RoomBookingEntity
    {
        public int Id { get; set; }
        //public string Emirate { get; set; }
        public string RequestNumber { get; set; }
        public string Place { get; set; }
        public SPFieldMultiChoiceValue  ResourcesNeeded { get; set; }
        public string AttendeesNumber { get; set; }
        public string Mission { get; set; }
        public string Department { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }

    }
}
