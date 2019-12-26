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
              
       
        public string EmployeeNumber { get; set; }

        public string Department { get; set; }
        public string DirectManager { get; set; }
        public string CouncilTarget { get; set; }
        public string JoiningConditions { get; set; }
        public DateTime CouncilDate { get; set; }
        public string CouncilType { get; set; }
       
    }
}
