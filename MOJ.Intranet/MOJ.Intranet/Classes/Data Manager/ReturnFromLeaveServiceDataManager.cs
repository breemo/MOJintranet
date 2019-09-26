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
    public class ReturnFromLeaveServiceDataManager
    {
        //True – For Success
        //False - For Error

        public bool EmployeeMasterDataByEmployeeNumber(string EmployeeNumber, string LeaveReason)
        {
            bool responseMsg = false;
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["ReturnFromLeaveService"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "" +
                    "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ret=\"http://esb.bayanati.gov.ae/services/ReturnFromLeaveService\">\r\n   " +
                    "<soapenv:Header/>\r\n   <soapenv:Body>\r\n" +
                    "<ret:ReturnFromLeaveRequest>\r\n" +
                    "<EAIHeader versionID=\"1.0\">\r\n" +
                    "<ServiceId>52</ServiceId>\r\n" +
                    "<ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n" +
                    "<TransactionRefNo>14052019-2</TransactionRefNo>\r\n" +
                    "<TransactionSubtype>C</TransactionSubtype>\r\n" +
                    "<Notes>?</Notes>\r\n" +
                    "</EAIHeader>\r\n<EAIBody>\r\n           " +
                    " <SessionID>-1</SessionID>\r\n" +
                    "<Language>US</Language>\r\n" +
                    "<EmployeeID>" + EmployeeNumber + "</EmployeeID>\r\n" +
                    "<AbsenceID>15326386</AbsenceID>\r\n" +
                    "<ResumeDate>2019-01-25</ResumeDate>\r\n" +
                    "<Reason>" + LeaveReason + "</Reason>\r\n" +
                    "<XAttribute>\r\n" +
                    "<Attribute1></Attribute1>\r\n" +
                    "<Attribute2></Attribute2>\r\n" +
                    "<Attribute3></Attribute3>\r\n" +
                    " </XAttribute>\r\n</EAIBody>\r\n" +
                    "</ret:ReturnFromLeaveRequest>\r\n" +
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
