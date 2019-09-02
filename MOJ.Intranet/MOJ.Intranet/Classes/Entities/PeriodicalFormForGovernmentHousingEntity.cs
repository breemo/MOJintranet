using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class PeriodicalFormForGovernmentHousingEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Created { get; set; }
        public string HusbandORWife { get; set; }
        public string ContractNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Owner { get; set; }
        public string NumberOfRooms { get; set; }
        public string ACtype { get; set; }
        public string LeasingContractEndDate { get; set; }
        public string Mobile { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }

        public SPFieldUserValue CreatedBy { get; set; }

    }
}
