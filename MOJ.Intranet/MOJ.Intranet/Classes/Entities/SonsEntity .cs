using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class SonsEntity
    {
        public int id { get; set; }
        public string RequestNumber { get; set; }
        public string Gender { get; set; }        
        public string Name { get; set; }       
        public string age { get; set; }        
        public string Career { get; set; }        
        public string BasicSalary { get; set; }        
        public bool HousingAllowance { get; set; }        
        public string LastEntryDate { get; set; }        
        public string LastExitDate { get; set; }        

    }
}
