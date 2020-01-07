using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class AskAnExpertAnswerEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public string ExpertLoginName { get; set; }
        public string ExpertPosition { get; set; }
       
        public string ExpertName { get; set; }
        public string AskAnExpertID { get; set; }
        
        public DateTime Created { get; set; }
        public SPFieldUserValue CreatedBy { get; set; }
    }
}
