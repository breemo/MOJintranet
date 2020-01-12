using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class CertificateToWhomItMayConcernEntity
    { 
        public int ID { get; set; }
        public string Title { get; set; }
        public string SpeechLanguage { get; set; }
        public string RequestType { get; set; }
        public string OrganizationType { get; set; }
        public string SpeechType { get; set; }
        public string TravelCountry { get; set; }
        public string ResponseMsgAR { get; set; }
        public string ResponseMsg { get; set; }
        public string TheSpeechDirectedTo { get; set; }
      
        public SPFieldUserValue CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
    
}
