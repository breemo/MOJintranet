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
    public class PushFAHRLeaveApplicationRequestDataManager
    {
        //True – For Success
        //False - For Error

        public bool PushFAHRLeaveApplicationRequest(string EmployeeNumber, string LeaveReason, string FromDate, string ToDate, string AbsenceType)
        {
            bool responseMsg = false;
            try
            {


                var client = new RestClient(ConfigurationManager.AppSettings["FAHRLeaveService"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "" +
                    "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:fah=\"http://esb.bayanati.gov.ae/services/FAHRLeaveService\">\r\n   " +
                    "<soapenv:Header>\r\n      <wsse:Security soapenv:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">\r\n         <wsse:UsernameToken wsu:Id=\"UsernameToken-38FD82778F5A1168F91576405779048167\">\r\n            <wsse:Username>" + ConfigurationManager.AppSettings["WebServiceUsername"].ToString() + "</wsse:Username>\r\n            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" + ConfigurationManager.AppSettings["WebServicePassword"].ToString() + "</wsse:Password>\r\n            <wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">dwSmgRhrqECU9I3pDTPePg==</wsse:Nonce>\r\n            <wsu:Created>2019-12-15T10:29:39.047Z</wsu:Created>\r\n         </wsse:UsernameToken>\r\n      </wsse:Security>\r\n   </soapenv:Header>\r\n   <soapenv:Body>\r\n" +
                    "<fah:PushFAHRLeaveApplicationRequest>\r\n" +
                    "<EAIHeader versionID=\"1.0\">\r\n" +
                    "<ServiceId>51</ServiceId>\r\n" +
                    "<ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n" +
                    "<TransactionRefNo>14052019-2</TransactionRefNo>\r\n" +
                    "<TransactionSubtype>C</TransactionSubtype>\r\n" +
                    "<Notes>?</Notes>\r\n" +
                    "</EAIHeader>\r\n<EAIBody>\r\n" +
                    "<SessionID>-1</SessionID>\r\n" +
                    "<TransactionID>-1</TransactionID>\r\n" +
                    "<EmployeeID>" + EmployeeNumber + "</EmployeeID>\r\n" +
                    "<AbsenceType>"+ AbsenceType + "</AbsenceType>\r\n" +
                    "<FromDate>" + FromDate + "</FromDate>\r\n" +
                    "<TimeStart></TimeStart>\r\n" +
                    "<ToDate>" + ToDate + "</ToDate>\r\n" +
                    "<TimeEnd></TimeEnd>\r\n" +
                    "<ReplacementPerID></ReplacementPerID>\r\n" +
                    "<ExitPermitReason></ExitPermitReason>\r\n" +
                    "<Comments>" + LeaveReason + "</Comments>\r\n" +
                    "<Notes></Notes>\r\n" +
                    "<SickLeaveReason></SickLeaveReason>\r\n" +
                    "<IssuiingAuthority></IssuiingAuthority>\r\n" +
                    "<ChildBirthDate></ChildBirthDate>\r\n" +
                    "<ChildPlaceOfBirth></ChildPlaceOfBirth>\r\n" +
                    "<Language>US</Language>\r\n" +
                    "<AdvanceRequest></AdvanceRequest>\r\n" +
                    "<Attachments>\r\n" +
                     "<Attach>\r\n" +
                      "<FileName></FileName>\r\n" +
                      "<FileType></FileType>\r\n" +
                      "<File></File>\r\n" +
                     "</Attach>\r\n" +
                    "</Attachments>\r\n" +
                    " </EAIBody>\r\n" +
                    "</fah:PushFAHRLeaveApplicationRequest>\r\n" +
                    "</soapenv:Body>\r\n</soapenv:Envelope>", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;

                if (response.IsSuccessful)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(content));
                    string xmlPathPattern = "//ResponseDate";

                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
                    foreach (XmlNode node in myNodeList)
                    {
                        //((System.Xml.XmlElement)((System.Xml.XmlElement)node).NextSibling).InnerText

                        XmlNode Accepted = node.NextSibling;
                        string AcceptedValues = Accepted.InnerText;
                        if (AcceptedValues == "True")
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
