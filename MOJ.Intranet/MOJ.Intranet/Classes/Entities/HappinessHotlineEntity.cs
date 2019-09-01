using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class HappinessHotlineEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }       
              
        public DateTime Created { get; set; }
        public string ContactReason { get; set; }
        
        public string Message { get; set; }

        public string Status { get; set; }

        public SPFieldUserValue CreatedBy { get; set; }
    }
}
