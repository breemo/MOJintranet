using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class ReserveHotelPeopleEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Created { get; set; }        
        
        public string Name { get; set; }
        public string Job { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string Task { get; set; }
                

    }
}
