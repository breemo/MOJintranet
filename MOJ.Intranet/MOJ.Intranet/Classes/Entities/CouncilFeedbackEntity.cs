using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class CouncilFeedbackEntity
    {
        public int ID { get; set; }
        public string loginName { get; set; }
        public string knowledgeCouncilID { get; set; }        
        public string SubjectCouncilCanBeDone { get; set; }        
        public string DevelopmentProposalsForCouncil { get; set; }        
        public string TheBenefitFromTheCouncil { get; set; }        
           

    }
}
