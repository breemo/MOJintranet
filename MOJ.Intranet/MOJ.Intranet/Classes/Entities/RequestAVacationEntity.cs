using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class RequestAVacationEntity
    {
        public int ID { get; set; }

        public string Title { get; set; }
        
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ChildBirthDate { get; set; }
        public string ResponseMsgAR { get; set; }
        public string ChildPlaceOfBirth { get; set; }
        public string ExitPermitReason { get; set; }
        public string code { get; set; }
        public string TitleExitPermitReason { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        
        public string ResponseMsg { get; set; }
        public string Comments { get; set; }
        public string SubstituteEmployee { get; set; }
        public string VacationType { get; set; }
        public string fileName { get; set; }
        public byte[] fileContents { get; set; }
       


        public SPFieldUserValue CreatedBy { get; set; }
    }
}
