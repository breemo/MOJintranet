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
        public string EmploymentHistory { get; set; }
        public string Qualifications { get; set; }
        public string LanguageSkills { get; set; }
        public string TechnicalSkills { get; set; }
        public string OtherSkills { get; set; }
        public string TrainingCourses { get; set; }
        public string Expertise { get; set; }
        public string Publications { get; set; }
        public string TravelInformations { get; set; }
        public string Participations { get; set; }
        public string Membership { get; set; }
        public string Hobbies { get; set; }
        public string VoluntaryWork { get; set; }
    }
}
