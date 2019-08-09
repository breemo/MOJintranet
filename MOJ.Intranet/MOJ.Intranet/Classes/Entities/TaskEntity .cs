﻿using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class TaskEntity
    {
        public int id { get; set; }
        //public string Emirate { get; set; }
        public string Title { get; set; }
        public  string WorkflowOutcome { get; set; }
        public string RequestID { get; set; }
        public string RequestURL { get; set; }
        public string RequestName { get; set; }
        public string WorkflowName { get; set; }
        public string Status { get; set; }
        public string PercentComplete { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public SPFieldUserValueCollection AssignedTo { get; set; }
        public string AssignedTotype { get; set; }
        public string AssignedToGroup { get; set; }
    }
}
