using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities.ImplicitKnowledge
{
    public class TrainingCoursesEntity
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Title { get; set; }        
        public string CourseName { get; set; }
        public string WithinThePlan { get; set; }        
        public string TrainingHours { get; set; }        
        public string CourseLocation { get; set; }        
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
