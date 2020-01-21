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

        public string PushFAHRLeaveApplicationRequest(string EmployeeNumber, string LeaveReason, string FromDate, string ToDate, string AbsenceType)
        {
            string responseMsg = "";
            try
            {


                var client = new RestClient(ConfigurationManager.AppSettings["FAHRLeaveService"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                var ExitPermitReason = "<ExitPermitReason></ExitPermitReason>";
                if (AbsenceType== "17292")
                {
                    ExitPermitReason = "<ExitPermitReason>"+ LeaveReason + "</ExitPermitReason>";
                }
                request.AddParameter("text/xml", "" +
                    "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:fah=\"http://esb.bayanati.gov.ae/services/FAHRLeaveService/\">\r\n   " +
                    "<soapenv:Header>\r\n "+
                    "</soapenv:Header>\r\n   <soapenv:Body>\r\n" +
                    "<fah:PushFAHRLeaveApplicationRequest>\r\n" +
                    "<EAIHeader versionID=\"1.0\">\r\n" +
                    "<ServiceId>51</ServiceId>\r\n" +
                    "<ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n" +
                    "<TransactionRefNo>14052019-2</TransactionRefNo>\r\n" +
                    "<TransactionSubtype>C</TransactionSubtype>\r\n" +
                    "<Notes>moj</Notes>\r\n" +
                    "</EAIHeader>\r\n<EAIBody>\r\n" +
                    "<SessionID>-1</SessionID>\r\n" +
                    "<TransactionID>-1</TransactionID>\r\n" +
                    "<EmployeeeID>" + EmployeeNumber + "</EmployeeeID>\r\n" +
                    "<AbsenceType>"+ AbsenceType + "</AbsenceType>\r\n" +
                    "<FromDate>" + FromDate + "</FromDate>\r\n" +
                    "<TimeStart></TimeStart>\r\n" +
                    "<ToDate>" + ToDate + "</ToDate>\r\n" +
                    "<TimeEnd></TimeEnd>\r\n" +
                    "<ReplacementPerID></ReplacementPerID>\r\n" +
                    ExitPermitReason+
                    "\r\n" +
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
                    string xmlPathPattern = "//ReplyMessage";

                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
                    foreach (XmlNode node in myNodeList)
                    {
                        ////((System.Xml.XmlElement)((System.Xml.XmlElement)node).NextSibling).InnerText

                        //XmlNode Accepted = node.NextSibling;
                        //string AcceptedValues = Accepted.InnerText;
                        //if (AcceptedValues == "True")
                        //    responseMsg = true;


                        string AcceptedValues = node.LastChild.InnerText;
                        //if (AcceptedValues == "SUCCESS")
                        responseMsg = AcceptedValues;
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
