using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class ReturnToDutyNoticeMembersOfTheJudiciaryEntity
    {
        public int id { get; set; }

        public string RequestNumber { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Created { get; set; }        
        public DateTime date { get; set; }
        public SPFieldUserValue CreatedBy { get; set; }
        public string DayID { get; set; }
        public string DayEn { get; set; }
        public string DayAr { get; set; }
        public string ResponseMsg { get; set; }
        public string ResponseMsgAR { get; set; }

        
        

    }
}
