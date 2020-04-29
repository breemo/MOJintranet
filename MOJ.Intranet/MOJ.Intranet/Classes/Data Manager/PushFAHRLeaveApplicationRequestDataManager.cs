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

        public string PushFAHRLeaveApplicationRequest(string EmployeeNumber, string LeaveReason,
            string FromDate, string ToDate, string AbsenceType, string fileName,
            string fileType,byte[] fileContents,string BirthOfTheChild,string PlaceOfBirthOfTheChild
           ,string TitleExitPermitReason, string StartTime, string EndTime, string IssuingAuthority
            )
        {
            string responseMsg = "";
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["FAHRLeaveService"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");               
                var Attachis = "<Attach>\r\n" +
                     "<FileName></FileName>\r\n" +
                     "<FileType></FileType>\r\n" +
                     "<File></File>\r\n" +
                    "</Attach>\r\n";
                var BirthChild = "<ChildBirthDate></ChildBirthDate>\r\n";
                var PlaceChild = "<ChildPlaceOfBirth> </ChildPlaceOfBirth>\r\n";              
                if (AbsenceType == "17278")
                {
                    BirthChild = "<ChildBirthDate>" + BirthOfTheChild + "</ChildBirthDate>\r\n";
                    PlaceChild = "<ChildPlaceOfBirth>" + PlaceOfBirthOfTheChild + "</ChildPlaceOfBirth>\r\n";
                }
                var TimeStartV = "<TimeStart></TimeStart>\r\n";
                var TimeEndV = "<TimeEnd></TimeEnd>\r\n";
                var ExitPermitReason = "<ExitPermitReason></ExitPermitReason>\r\n";
                if (AbsenceType == "17292")
                {
                    TimeStartV = "<TimeStart>" + StartTime + "</TimeStart>\r\n";
                    TimeEndV= "<TimeEnd>" + EndTime + "</TimeEnd>\r\n";
                    ExitPermitReason = "<ExitPermitReason>" + TitleExitPermitReason + "</ExitPermitReason>\r\n";
                }
                var IssuingAuthorityV = "<IssuiingAuthority></IssuiingAuthority>\r\n";
                if (AbsenceType == "17279"|| AbsenceType == "17280")
                {
                    IssuingAuthorityV = "<IssuiingAuthority>" + IssuingAuthority + "</IssuiingAuthority>\r\n";
                }
                if (fileName != "")
                {
                    //String imageAsString = Base64.encodeToString(fileContents, Base64.DEFAULT);
                    String imageAsString = System.Convert.ToBase64String(fileContents);
                    Attachis = "<Attach>\r\n" +
                     "<FileName>"+ fileName + "</FileName>\r\n" +
                     "<FileType>"+ fileType + "</FileType>\r\n" +
                     "<File>"+ imageAsString + "</File>\r\n" +
                    "</Attach>\r\n";
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
                    TimeStartV +
                    "<ToDate>" + ToDate + "</ToDate>\r\n" +
                    TimeEndV +
                    "<ReplacementPerID></ReplacementPerID>\r\n" +
                    ExitPermitReason+
                    "\r\n" +
                    "<Comments>" + LeaveReason + "</Comments>\r\n" +
                    "<Notes></Notes>\r\n" +
                    "<SickLeaveReason>"+ LeaveReason + "</SickLeaveReason>\r\n" +
                    IssuingAuthorityV+
                    BirthChild +
                    PlaceChild +
                    "<Language>US</Language>\r\n" +
                    "<AdvanceRequest></AdvanceRequest>\r\n" +
                    "<Attachments>\r\n" +
                   Attachis+
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
                else
                {
                    responseMsg = "No connection to the web service bytna";
                }

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return responseMsg;
        }

        public string PushReturnFromLeaveRequest(string EmployeeNumber, string AbsenceID,string ReturnDate, string ReturnReason)
        {
            //<EmployeeID>162566</EmployeeID>
            //<AbsenceID>15326386</AbsenceID>
            //<SessionID>-1</SessionID>
            //<Language>US</Language>
            //<ResumeDate>2019-01-25</ResumeDate>
            //<Reason>Returned early - For Testing</Reason>

            string responseMsg = "";
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["ReturnFromLeaveService"].ToString());
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                
                request.AddParameter("text/xml", "" +
                    "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:fah=\"http://esb.bayanati.gov.ae/services/ReturnFromLeaveService/\">\r\n   " +
                    "<soapenv:Header>\r\n " +
                    "</soapenv:Header>\r\n   <soapenv:Body>\r\n" +
                    
                     "<ret:ReturnFromLeaveRequest>                     \r\n" +
                     "<EAIHeader versionID=\"1.0\">                    \r\n" +
                     "<ServiceId>52</ServiceId>                        \r\n" +
                     "<ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n" +
                     "<TransactionRefNo>14052019-2</TransactionRefNo>  \r\n" +
                     "<TransactionSubtype>C</TransactionSubtype>       \r\n" +
                     "<Notes></Notes>                                  \r\n" +
                     "</EAIHeader>                                     \r\n" +
                     "<EAIBody>                                        \r\n" +
                     "<SessionID>-1</SessionID>                        \r\n" +
                     "<Language>US</Language>                          \r\n" +
                     "<EmployeeID>" + EmployeeNumber + "</EmployeeID>  \r\n" +
                     "<AbsenceID>" + AbsenceID + "</AbsenceID>         \r\n" +
                     "<ResumeDate>" + ReturnDate + "</ResumeDate>      \r\n" +
                     "<Reason>" + ReturnReason + "</Reason>            \r\n" +
                     "<XAttribute>                                     \r\n" +
                     "<Attribute1></Attribute1>                        \r\n" +
                     "<Attribute2></Attribute2>                        \r\n" +
                     "<Attribute3></Attribute3>                        \r\n" +
                     "</XAttribute>                                    \r\n" +
                     "</EAIBody>                                       \r\n" +
                     "</ret:ReturnFromLeaveRequest>                    \r\n" +
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
                        string AcceptedValues = node.LastChild.InnerText;
                        responseMsg = AcceptedValues;
                    }
                }
                else
                {
                    responseMsg = "No connection to the web service bytna";
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
