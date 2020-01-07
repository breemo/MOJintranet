using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class AskAnExpertEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }       
        public string QuestionTitle { get; set; }       
        public string Department { get; set; }       
        public string ExpertID { get; set; }
        public string QuestionDetails { get; set; }
        public string loginName { get; set; }
        public string Status { get; set; }
        public string CloseTheQuestion { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePosition { get; set; }
        public string StartWF { get; set; }
        public SPFieldUserValue EmployeeLoginName { get; set; }
        public DateTime Created { get; set; }
        public SPFieldUserValue CreatedBy { get; set; }
    }
}
