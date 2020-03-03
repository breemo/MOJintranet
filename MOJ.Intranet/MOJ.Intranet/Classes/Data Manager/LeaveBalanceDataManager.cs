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
    }
}
