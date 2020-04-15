using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class ReturnFromLeaveEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ApprovedVacation { get; set; }

        public string StartDateVacation { get; set; }
        public string EndDateVacation { get; set; }
        public DateTime ReturnDateFromVacation { get; set; }
        public string RreasonForTheDelay { get; set; }
        public string ResponseMsg { get; set; }
        public string ResponseMsgAR { get; set; }
        public string Status { get; set; }
        
    }
}
