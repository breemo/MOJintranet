﻿using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class knowledgeCouncilEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CouncilTopic { get; set; }

        public string EmployeeName { get; set; }       
        public string Lecturer { get; set; }       
        public string LecturerEN { get; set; }       
              
       
        public string EmployeeNumber { get; set; }
        public string Designation { get; set; }
        public string Status { get; set; }

        public string Department { get; set; }
        public string DirectManager { get; set; }
        public string CouncilTarget { get; set; }
        public string JoiningConditions { get; set; }
        public DateTime CouncilDate { get; set; }
        public string CouncilType { get; set; }
        public string RequestURL { get; set; }
        public string ADetailedExplanationOfTheCouncil { get; set; }
        public string CouncilDescription { get; set; }
        public string CouncilDescriptionEN { get; set; }
        public string CouncilGoals { get; set; }
        public string CouncilGoalsEN { get; set; }
       
               
        public DateTime Created { get; set; }
       
        public SPFieldUserValue CreatedBy { get; set; }
        public int CouncilNo { get; set; }
        public int PassPercentage { get; set; }
        public string URLAttachments { get; set; }
    }
}
