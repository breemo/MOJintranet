using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class AffirmationReceiptGovernmentHousingEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Created { get; set; }
        public string ChangeDate { get; set; }
        
        public string MobileNumber { get; set; }

        public string ApportionmentDate { get; set; }
        public string HomeAddress { get; set; }
        public string VilaApartmentNumber { get; set; }
        public string NumberOfRooms { get; set; }
        public string Owner { get; set; }
        public string agent { get; set; }
        

    }
}
