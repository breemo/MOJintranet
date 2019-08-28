using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class HusbandORWifeEntity
    {
        public int id { get; set; }
        public string RequestNumber { get; set; }              
        public string Name { get; set; }       
        public string HusbandORWife { get; set; }
        public string Employer { get; set; }
        public string workSector { get; set; }
        public string HiringDate { get; set; }
        public string DateOfMarriage { get; set; }
        public bool HasGovernmentHousingAllowance { get; set; }
        public bool HasGovernmentHousingPercentageAllowance { get; set; }
        public string LastExitDate { get; set; }
        public string LastEntryDate { get; set; }
        public string BasicSalary { get; set; }
    }
}
