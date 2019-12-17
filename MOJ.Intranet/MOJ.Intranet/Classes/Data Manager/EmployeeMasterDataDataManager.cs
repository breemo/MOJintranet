using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using MOJ.Entities;
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
    public class EmployeeMasterDataDataManager
    {
        public List<EmployeeMasterDataEntity> EmployeeMasterDataByEmployeeNumber(string EmployeeNumber)
        {
            List<EmployeeMasterDataEntity> Employee = new List<EmployeeMasterDataEntity>();
            try
            {
                string webserviceUsername = ConfigurationManager.AppSettings["WebServiceUsername"].ToString();
                string webservicePassword = ConfigurationManager.AppSettings["WebServicePassword"].ToString();

                var client = new RestClient(ConfigurationManager.AppSettings["EmployeeMasterDataServiceWebService"].ToString());
                //client.Proxy = null;
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "text/xml");
                request.AddParameter("text/xml", "<soapenv:Envelope xmlns:emp=\"http://esb.bayanati.gov.ae/services/EmployeeMasterDataService/\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n   <soapenv:Header>\r\n      <wsse:Security soapenv:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">\r\n         <wsse:UsernameToken wsu:Id=\"UsernameToken-38FD82778F5A1168F91576405779048167\">\r\n            <wsse:Username>" + webserviceUsername + "</wsse:Username>\r\n            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" + webservicePassword + "</wsse:Password>\r\n            <wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">dwSmgRhrqECU9I3pDTPePg==</wsse:Nonce>\r\n            <wsu:Created>2019-12-15T10:29:39.047Z</wsu:Created>\r\n         </wsse:UsernameToken>\r\n      </wsse:Security>\r\n   </soapenv:Header>\r\n   <soapenv:Body>\r\n      <emp:EmployeeMasterDataRequest>\r\n         <EAIHeader versionID=\"1.0\">\r\n            <ServiceId>54</ServiceId>\r\n            <ExternalAuthorityCode>21</ExternalAuthorityCode>\r\n            <TransactionRefNo>test12</TransactionRefNo>\r\n            <TransactionSubtype>I</TransactionSubtype>\r\n            <Notes/>\r\n         </EAIHeader>\r\n         <EAIBody>\r\n            <EmployeeNumber>" + EmployeeNumber + "</EmployeeNumber>\r\n         </EAIBody>\r\n      </emp:EmployeeMasterDataRequest>\r\n   </soapenv:Body>\r\n</soapenv:Envelope>", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;

                if (response.IsSuccessful)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(content));
                    string xmlPathPattern = "//EmployeeMasterData/Employee";
                    XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
                    foreach (XmlNode node in myNodeList)
                    {
                        EmployeeMasterDataEntity EmployeeValues = new EmployeeMasterDataEntity();

                        XmlNode ArabicEmployeeName = node.FirstChild.FirstChild;
                        EmployeeValues.employeeNameArabicField = ArabicEmployeeName.InnerText;

                        XmlNode EnglishEmployeeName = node.FirstChild.LastChild;
                        EmployeeValues.employeeNameEnglishField = EnglishEmployeeName.InnerText;

                        XmlNode DepartmentID = node.FirstChild.NextSibling;
                        EmployeeValues.departmentIDField = DepartmentID.InnerText;

                        XmlNode EnglishDepartmentName = DepartmentID.NextSibling;
                        EmployeeValues.departmentNameField_US = EnglishDepartmentName.InnerText;

                        XmlNode ArabicDepartmentName = DepartmentID.NextSibling.LastChild;
                        EmployeeValues.departmentNameField_AR = ArabicDepartmentName.InnerText;

                        XmlNode PositionID = EnglishDepartmentName.NextSibling;
                        EmployeeValues.positionIDField = PositionID.InnerText;

                        XmlNode EnglishNamePositionName = PositionID.NextSibling;
                        EmployeeValues.positionNameField_US = EnglishNamePositionName.InnerText;

                        XmlNode ArabicNamePositionName = PositionID.NextSibling.LastChild;
                        EmployeeValues.positionNameField_AR = ArabicNamePositionName.InnerText;

                        XmlNode EmployeeNumberValue = EnglishNamePositionName.NextSibling;
                        EmployeeValues.employeeNumberField = EmployeeNumberValue.InnerText;

                        XmlNode EmployementDate = EmployeeNumberValue.NextSibling;
                        EmployeeValues.employementDateField = EmployementDate.InnerText;

                        XmlNode ManagerID_DirectManager = EmployementDate.NextSibling.FirstChild;
                        EmployeeValues.ManagerID_DirectManager = ManagerID_DirectManager.InnerText;

                        XmlNode ManagerName_DirectManager = EmployementDate.NextSibling.FirstChild.NextSibling;
                        EmployeeValues.ManagerName_DirectManager = ManagerName_DirectManager.InnerText;

                        XmlNode ManagerEmail_DirectManager = EmployementDate.NextSibling.FirstChild.NextSibling.NextSibling;
                        EmployeeValues.ManagerEmail_DirectManager = ManagerEmail_DirectManager.InnerText;


                        XmlNode ManagerID_HigherManager = EmployementDate.NextSibling.NextSibling.FirstChild;
                        EmployeeValues.ManagerID_HigherManager = ManagerID_HigherManager.InnerText;

                        if (ManagerID_HigherManager.InnerText != "")
                        {
                            XmlNode ManagerName_HigherManager = EmployementDate.NextSibling.NextSibling.FirstChild.NextSibling;
                            EmployeeValues.ManagerName_HigherManager = ManagerName_HigherManager.InnerText;

                            XmlNode ManagerEmail_HigherManager = EmployementDate.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling;
                            EmployeeValues.ManagerEmail_HigherManager = ManagerEmail_HigherManager.InnerText;
                        }



                        XmlNode Nationality_AR = EmployementDate.NextSibling.NextSibling.NextSibling;
                        EmployeeValues.nationality_ARField = Nationality_AR.InnerText;

                        XmlNode Nationality_US = Nationality_AR.NextSibling;
                        EmployeeValues.nationality_USField = Nationality_US.InnerText;

                        XmlNode DateOfBirth = Nationality_US.NextSibling;
                        EmployeeValues.dateOfBirthField = DateOfBirth.InnerText;

                        XmlNode MaritalStatus_US = DateOfBirth.NextSibling;
                        EmployeeValues.maritalStatus_USField = MaritalStatus_US.InnerText;

                        XmlNode MaritalStatus_AR = MaritalStatus_US.NextSibling;
                        EmployeeValues.maritalStatus_ARField = MaritalStatus_AR.InnerText;

                        XmlNode EmployeeEmail = MaritalStatus_AR.NextSibling;
                        EmployeeValues.employeeEmailField = EmployeeEmail.InnerText;

                        XmlNode ContactNumber = EmployeeEmail.NextSibling;
                        EmployeeValues.contactNumberField = ContactNumber.InnerText;

                        XmlNode Status = ContactNumber.NextSibling;
                        EmployeeValues.statusField = Status.InnerText;

                        Employee.Add(EmployeeValues);
                    }
                }

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return Employee;
        }


        public List<EmployeeMasterDataEntity> GetCurrentEmployeeMasterDataByEmployeeNumber(string Userlogin = null)
        {
            List<EmployeeMasterDataEntity> EmployeeValues = new List<EmployeeMasterDataEntity>();
            try
            {
                using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb myweb = mySitesCollection.OpenWeb())
                    {
                        string currentUserlogin;
                        if (Userlogin == null)
                        {
                            SPUser currentUser = myweb.CurrentUser;
                            currentUserlogin = currentUser.LoginName;
                        }
                        else
                        {
                            currentUserlogin = Userlogin;
                        }
                        SPServiceContext context = SPServiceContext.GetContext(mySitesCollection);
                        UserProfileManager profileManager = new UserProfileManager(context);
                        UserProfile currentProfile = profileManager.GetUserProfile(currentUserlogin);

                        if (currentProfile.GetProfileValueCollection(ConfigurationManager.AppSettings["ADAttributesEmployeeID"].ToString()).Count != 0)
                        {
                            ProfileValueCollectionBase EmployeeNumber = currentProfile.GetProfileValueCollection(ConfigurationManager.AppSettings["ADAttributesEmployeeID"].ToString());
                            EmployeeValues = EmployeeMasterDataByEmployeeNumber(EmployeeNumber.ToString());

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return EmployeeValues;


        }

    }

}
