using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class ExpertsEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }       
        public string Department { get; set; }       
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string ExpertName { get; set; }
        public SPFieldUserValue ExpertLoginName { get; set; }
        public string ExpertPosition { get; set; }
        public string Topics { get; set; }
        public string TopicsAR { get; set; }
        public DateTime Created { get; set; }
        public SPFieldUserValue CreatedBy { get; set; }
    }
}
