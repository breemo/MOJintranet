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
    public class LeaveBalanceDataManager
    {
        public string LeaveBalance(string EmployeeNumber)
        {
            string LeaveBalance = "";
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["LeaveBalance"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:fah=\"http://esb.bayanati.gov.ae/services/FAHRLookupService/\">\r\n      <soapenv:Header>\r\n      <wsse:Security soapenv:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">\r\n         <wsse:UsernameToken wsu:Id=\"UsernameToken-38FD82778F5A1168F91576405779048167\">\r\n            <wsse:Username>" + ConfigurationManager.AppSettings["WebServiceUsername"].ToString() + "</wsse:Username>\r\n            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" + ConfigurationManager.AppSettings["WebServicePassword"].ToString() + "</wsse:Password>\r\n            <wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">dwSmgRhrqECU9I3pDTPePg==</wsse:Nonce>\r\n            <wsu:Created>2019-12-15T10:29:39.047Z</wsu:Created>\r\n         </wsse:UsernameToken>\r\n      </wsse:Security>\r\n   </soapenv:Header>\r\n   <soapenv:Body>\r\n      <fah:FAHRLookupMessageRequest>\r\n         <EAIHeader versionID=\"1.0\">\r\n            <ServiceId>50</ServiceId>\r\n            <ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n            <TransactionRefNo>R12</TransactionRefNo>\r\n            <TransactionSubtype>R</TransactionSubtype> \r\n            <Notes></Notes>\r\n         </EAIHeader>\r\n         <EAIBody> \r\n            <SessionID>-1</SessionID> \r\n            <Language>AR</Language> \r\n            <LookupType>ANNUAL_LEAVE_BALANCE</LookupType> \r\n            <ExtraAttributes> \r\n               <Attribute1>"+ EmployeeNumber + "</Attribute1> \r\n               <Attribute2></Attribute2> \r\n               <Attribute3></Attribute3>\r\n            </ExtraAttributes>\r\n         </EAIBody>\r\n      </fah:FAHRLookupMessageRequest>\r\n   </soapenv:Body>\r\n</soapenv:Envelope>\r\n", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;

                if (response.IsSuccessful)
                {
                    string totVal = "";
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(content));
                    string xmlPathPattern = "//LookupValue";
                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
                    foreach (XmlNode node in myNodeList)
                    {
                        LeaveBalance = node.FirstChild.InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return LeaveBalance;
        }

        public string SickLeaveBalance(string EmployeeNumber)
        {
            string LeaveBalance = "";
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["LeaveBalance"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:fah=\"http://esb.bayanati.gov.ae/services/FAHRLookupService/\">\r\n      <soapenv:Header>\r\n      <wsse:Security soapenv:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">\r\n         <wsse:UsernameToken wsu:Id=\"UsernameToken-38FD82778F5A1168F91576405779048167\">\r\n            <wsse:Username>" + ConfigurationManager.AppSettings["WebServiceUsername"].ToString() + "</wsse:Username>\r\n            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" + ConfigurationManager.AppSettings["WebServicePassword"].ToString() + "</wsse:Password>\r\n            <wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">dwSmgRhrqECU9I3pDTPePg==</wsse:Nonce>\r\n            <wsu:Created>2019-12-15T10:29:39.047Z</wsu:Created>\r\n         </wsse:UsernameToken>\r\n      </wsse:Security>\r\n   </soapenv:Header>\r\n   <soapenv:Body>\r\n      <fah:FAHRLookupMessageRequest>\r\n         <EAIHeader versionID=\"1.0\">\r\n            <ServiceId>50</ServiceId>\r\n            <ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n            <TransactionRefNo>R12</TransactionRefNo>\r\n            <TransactionSubtype>R</TransactionSubtype> \r\n            <Notes></Notes>\r\n         </EAIHeader>\r\n         <EAIBody> \r\n            <SessionID>-1</SessionID> \r\n            <Language>AR</Language> \r\n            <LookupType>SICK_LEAVE_BALANCE</LookupType> \r\n            <ExtraAttributes> \r\n               <Attribute1>" + EmployeeNumber + "</Attribute1> \r\n               <Attribute2></Attribute2> \r\n               <Attribute3></Attribute3>\r\n            </ExtraAttributes>\r\n         </EAIBody>\r\n      </fah:FAHRLookupMessageRequest>\r\n   </soapenv:Body>\r\n</soapenv:Envelope>\r\n", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;

                if (response.IsSuccessful)
                {
                    string totVal = "";
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(content));
                    string xmlPathPattern = "//LookupValue";
                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
                    foreach (XmlNode node in myNodeList)
                    {
                        LeaveBalance = node.FirstChild.InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return LeaveBalance;
        }

        public string ExitPermitBalance(string EmployeeNumber)
        {
            string LeaveBalance = "";
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["LeaveBalance"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:fah=\"http://esb.bayanati.gov.ae/services/FAHRLookupService/\">\r\n      <soapenv:Header>\r\n      <wsse:Security soapenv:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">\r\n         <wsse:UsernameToken wsu:Id=\"UsernameToken-38FD82778F5A1168F91576405779048167\">\r\n            <wsse:Username>" + ConfigurationManager.AppSettings["WebServiceUsername"].ToString() + "</wsse:Username>\r\n            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" + ConfigurationManager.AppSettings["WebServicePassword"].ToString() + "</wsse:Password>\r\n            <wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">dwSmgRhrqECU9I3pDTPePg==</wsse:Nonce>\r\n            <wsu:Created>2019-12-15T10:29:39.047Z</wsu:Created>\r\n         </wsse:UsernameToken>\r\n      </wsse:Security>\r\n   </soapenv:Header>\r\n   <soapenv:Body>\r\n      <fah:FAHRLookupMessageRequest>\r\n         <EAIHeader versionID=\"1.0\">\r\n            <ServiceId>50</ServiceId>\r\n            <ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n            <TransactionRefNo>R12</TransactionRefNo>\r\n            <TransactionSubtype>R</TransactionSubtype> \r\n            <Notes></Notes>\r\n         </EAIHeader>\r\n         <EAIBody> \r\n            <SessionID>-1</SessionID> \r\n            <Language>AR</Language> \r\n            <LookupType>EXIT_PERMIT_BALANCE</LookupType> \r\n            <ExtraAttributes> \r\n               <Attribute1>" + EmployeeNumber + "</Attribute1> \r\n               <Attribute2>PERSONAL</Attribute2> \r\n               <Attribute3></Attribute3>\r\n            </ExtraAttributes>\r\n         </EAIBody>\r\n      </fah:FAHRLookupMessageRequest>\r\n   </soapenv:Body>\r\n</soapenv:Envelope>\r\n", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;

                if (response.IsSuccessful)
                {
                    string totVal = "";
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(content));
                    string xmlPathPattern = "//LookupValue";
                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
                    foreach (XmlNode node in myNodeList)
                    {
                        LeaveBalance = node.FirstChild.InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return LeaveBalance;
        }

        public List<LeavesListObject> RETURN_FROM_LEAVE_LIST(string EmployeeNumber)
        {
            List<LeavesListObject> LeavesList = new List<LeavesListObject>();
            try
            {
                var client = new RestClient("https://esbdev.fahr.gov.ae/services/FAHRLookupService");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:fah=\"http://esb.bayanati.gov.ae/services/FAHRLookupService/\">\r\n      <soapenv:Header>\r\n      <wsse:Security soapenv:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">\r\n         <wsse:UsernameToken wsu:Id=\"UsernameToken-38FD82778F5A1168F91576405779048167\">\r\n            <wsse:Username>testing.fahresb.MOJ@fahr.gov.ae</wsse:Username>\r\n            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">testing.fahresb.MOJ@fahr.gov.ae</wsse:Password>\r\n            <wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">dwSmgRhrqECU9I3pDTPePg==</wsse:Nonce>\r\n            <wsu:Created>2019-12-15T10:29:39.047Z</wsu:Created>\r\n         </wsse:UsernameToken>\r\n      </wsse:Security>\r\n   </soapenv:Header>\r\n   <soapenv:Body>\r\n      <fah:FAHRLookupMessageRequest>\r\n         <EAIHeader versionID=\"1.0\">\r\n            <ServiceId>50</ServiceId>\r\n            <ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n            <TransactionRefNo>R12</TransactionRefNo>\r\n            <TransactionSubtype>R</TransactionSubtype> \r\n            <Notes></Notes>\r\n         </EAIHeader>\r\n         <EAIBody> \r\n            <SessionID>-1</SessionID> \r\n            <Language>AR</Language> \r\n            <LookupType>RETURN_FROM_LEAVE_LIST</LookupType> \r\n            <ExtraAttributes> \r\n               <Attribute1>" + EmployeeNumber + "</Attribute1> \r\n               <Attribute2></Attribute2> \r\n               <Attribute3></Attribute3>\r\n            </ExtraAttributes>\r\n         </EAIBody>\r\n      </fah:FAHRLookupMessageRequest>\r\n   </soapenv:Body>\r\n</soapenv:Envelope>\r\n", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;

                if (response.IsSuccessful)
                {
                    string totVal = "";
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(content));
                    string xmlPathPattern = "//LookupValue";
                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);

                    foreach (XmlNode node in myNodeList)
                    {
                        DateTime startDate = new DateTime(int.Parse(node.LastChild.InnerText.Split()[2].Split('-')[2]),
                            int.Parse(node.LastChild.InnerText.Split()[2].Split('-')[1]), int.Parse(node.LastChild.InnerText.Split()[2].Split('-')[0]));

                        DateTime EndDate = new DateTime(int.Parse(node.LastChild.InnerText.Split()[4].Split('-')[2]),
                            int.Parse(node.LastChild.InnerText.Split()[4].Split('-')[1]), int.Parse(node.LastChild.InnerText.Split()[4].Split('-')[0]));

                        LeavesList.Add(new LeavesListObject(node.InnerText, node.FirstChild.InnerText, startDate, EndDate));
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggingService.LogError("WebParts", ex.Message);
            }
            return LeavesList;
        }
    }

    public class LeavesListObject
    {
        private string absenceID;
        private string description;
        private DateTime startDateVacation;
        private DateTime endDateVacation;

        public LeavesListObject(string description, string absenceID, DateTime startDateVacation, DateTime endDateVacation)
        {
            this.absenceID = absenceID;
            this.description = description;
            this.startDateVacation = startDateVacation;
            this.endDateVacation = endDateVacation;
        }

        public string AbsenceID
        {
            get { return absenceID; }
            set { absenceID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime StartDateVacation
        {
            get { return startDateVacation; }
            set { startDateVacation = value; }
        }
        public DateTime EndDateVacation
        {
            get { return endDateVacation; }
            set { endDateVacation = value; }
        }
    }
}