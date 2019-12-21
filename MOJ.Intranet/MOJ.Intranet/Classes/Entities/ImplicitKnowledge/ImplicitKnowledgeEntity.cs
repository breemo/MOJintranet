using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class ImplicitKnowledgeEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }        
        public string UserName { get; set; }
        public string EmployeeNumber { get; set; }        
        public string Designation { get; set; }
        public string Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
    }
}
