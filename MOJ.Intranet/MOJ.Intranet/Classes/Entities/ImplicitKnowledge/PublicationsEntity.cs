using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class PublicationsEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string BookPublicationTitle { get; set; }
        public string Topic { get; set; }        
        public string Notes { get; set; }        
        public DateTime PublishDate { get; set; }
      
    }
}
