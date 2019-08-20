using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class FazaaCardRequestEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }       
              
        public DateTime Created { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }


    }
}
