using CommonLibrary;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace MOJ.DataManager
{
    public class LetterRequestRequesttDataManager
    {
        //True – For Success
        //False - For Error

        public bool LetterRequestRequest(string EmployeeNumber, string CountryCode, string LetterType, string RequestType, string SpeechLanguage, string OrganizationType, string TheSpeechDirectedTo)
        {
            bool responseMsg = false;
            try
            {                var client = new RestClient(ConfigurationManager.AppSettings["LetterRequestRequest"].ToString());
                var request = new RestRequest(Method.POST);
               
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "" +
                    "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:let=\"http://esb.bayanati.gov.ae/services/LetterRequestService\">\r\n   " +
                    "<soapenv:Header>\r\n"+
                    "</soapenv:Header>\r\n   <soapenv:Body>\r\n" +
                    "<let:LetterRequestRequest>\r\n" +
                    "<EAIHeader versionID=\"1.0\">\r\n" +
                    "<ServiceId>53</ServiceId>\r\n" +
                    "<ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n" +
                    "<TransactionRefNo>14052019-2</TransactionRefNo>\r\n" +
                    "<TransactionSubtype>C</TransactionSubtype>\r\n" +
                    "<Notes>MOJ</Notes>\r\n" +
                    "</EAIHeader>\r\n<EAIBody>\r\n" +
                    "<SessionID>-1</SessionID>\r\n" +
                    "<EmployeeID>" + EmployeeNumber + "</EmployeeID>\r\n" +
                    "<RequestType>"+ RequestType + "</RequestType>\r\n" +
                    "<LetterType>"+ LetterType + "</LetterType>\r\n" +
                    "<Language>"+ SpeechLanguage + "</Language>\r\n" +
                    "<OrgType>" + OrganizationType + "</OrgType>\r\n" +
                    "<OrgName>"+ TheSpeechDirectedTo + "</OrgName>\r\n" +
                    "<CountryCode>"+ CountryCode + "</CountryCode>\r\n" +
                     "<XAttributes>\r\n" +
                      "<Attribute1></Attribute1>\r\n" +
                      "<Attribute2></Attribute2>\r\n" +
                      "<Attribute3></Attribute3>\r\n" +
                     "</XAttributes>\r\n" +                  
                    " </EAIBody>\r\n" +
                    "</let:LetterRequestRequest>\r\n" +
                    "</soapenv:Body>\r\n</soapenv:Envelope>", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;

                if (response.IsSuccessful)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(content));
                    string xmlPathPattern = "//ReplyMessage";

                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
                    foreach (XmlNode node in myNodeList)
                    {
                        //((System.Xml.XmlElement)((System.Xml.XmlElement)node).NextSibling).InnerText

                       string AcceptedValues=  node.LastChild.InnerText;
                        if (AcceptedValues == "SUCCESS")
                            responseMsg = true;
                    }
                }

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return responseMsg;
        }
    }
}
