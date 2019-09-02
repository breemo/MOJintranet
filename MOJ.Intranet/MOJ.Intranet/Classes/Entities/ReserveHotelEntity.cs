using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class ReserveHotelEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Created { get; set; }
        public SPFieldUserValue CreatedBy { get; set; }
        public string EmirateID { get; set; }
        public string EmirateEn { get; set; }
        public string EmirateAr { get; set; }

        
        

    }
}
