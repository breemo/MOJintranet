using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class MyRequestsEntity
    {
        public int id { get; set; }
        //public string Emirate { get; set; }
        public string RequestNumber { get; set; }        
        public string RequestID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNameAr { get; set; }
        public string ServiceNameEn { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }
        public SPFieldUserValue RequestBy { get; set; }       
        public DateTime Created { get; set; }
      
      
    }
}
