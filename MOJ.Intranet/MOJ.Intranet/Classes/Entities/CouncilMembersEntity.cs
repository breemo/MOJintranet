using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class CouncilExamAnswerEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string loginName { get; set; }
        public string knowledgeCouncilID { get; set; }
        public string ExamID { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public int Result { get; set; }
        public string AnswerID { get; set; }
        public DateTime Created { get; set; }

        public SPFieldUserValue CreatedBy { get; set; }


    }
}
