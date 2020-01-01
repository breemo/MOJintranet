﻿using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.ViewRequestWP
{
    public partial class ViewRequestWPUserControl : UserControl
    {
        protected void btnGoToMyRequests_Click(object sender, EventArgs e)
        {

            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
         
                if (languageCode == "ar")
                {
                 Response.Redirect("/Ar/MyServices/Pages/MyRequests.aspx");
                   
                }
                else
                {
                Response.Redirect("/En/MyServices/Pages/MyRequests.aspx");
                     }
               
        }

        protected void btnCanceledworkflow_Click(object sender, EventArgs e)
        {
            string listNameC = Convert.ToString(Request.Params["list"]);
            string RequestIDC = Convert.ToString(Request.Params["RID"]);

            bool iscanceld = new Task().TerminateWorkflow(listNameC, Convert.ToInt32(RequestIDC));

            btnCanceled.Visible = false;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();

            if (languageCode == "ar")
            {
                Response.Redirect("/Ar/MyServices/Pages/MyRequests.aspx");

            }
            else
            {
                Response.Redirect("/En/MyServices/Pages/MyRequests.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["RID"]))
                {
                    GetRequest();
                }
                else
                {
                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: NoTasks", "Resource", SPContext.Current.Web.Language) + "<br />";
                    posts.Style.Add("display", "none");
                    SuccessMsgDiv.Style.Add("display", "block");
                }
            }
        }
        private void GetRequest()
        {
            string listName = Convert.ToString(Request.Params["list"]);
            string RequestID = Convert.ToString(Request.Params["RID"]);
            string Status = "";
            // add new workflow-----------------------------------
            if (listName == "RoomBooking")
                Status = GetRoomBookingData(RequestID);
            if (listName == "AffirmationSocialSituation")
                Status = GetAffirmationSocialSituationData(RequestID);
            if (listName == "HappinessHotline")
                Status = GetHappinessHotlineData(RequestID);
            if (listName == "CarOrderService")
                Status = GetCarOrderServiceData(RequestID);
            if (listName == "FazaaCardRequest")
                Status = GetFazaaCardRequestData(RequestID);
            if (listName == "ContactWithHR")
                Status = GetContactWithHRData(RequestID);
            if (listName == "ReserveHotel")
                Status = GetReserveHotelData(RequestID);
            if (listName == "AffirmationReceiptGovernmentHousing")
                Status = GetAffirmationGHousingHotelData(RequestID);
            if (listName == "ReturnToDutyNoticeMembersOfTheJudiciary")
                Status = GetReturnNoticeData(RequestID);
            if (listName == "PeriodicalFormForGovernmentHousing")
                Status = GetPeriodicalFormForGovernmentHousingData(RequestID);
            if (listName == "knowledgeCouncil")
                Status = GetknowledgeCouncil(RequestID);
            if (listName == "CouncilMembers")
                Status = GetCouncilMembers(RequestID);
            GetTasksRequest(RequestID, listName);

            AllData.Text += "<hr>";
            addtopage(Status, "");
            if (Status == "Canceled") { 
            btnCanceled.Visible = false;
         }
        }

        public string GetCouncilMembers(string RequestID)
        {
            CouncilMembersEntity masteritem = new CouncilMembers().GetCouncilMembers(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", masteritem.Title, "RequestDate", masteritem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(masteritem.CreatedBy.User.LoginName));
            addtopage("Department", masteritem.Department);
            addtopage("CouncilTopic", masteritem.CouncilTopic);
            return masteritem.Status;
        }
        public string GetknowledgeCouncil(string RequestID)
        {
            knowledgeCouncilEntity masteritem = new knowledgeCouncil().GetknowledgeCouncilByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", masteritem.Title, "RequestDate", masteritem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(masteritem.CreatedBy.User.LoginName));
            addtopage("Department", masteritem.Department);
            addtopage("CouncilTopic", masteritem.CouncilTopic);
            string CouncilTarget = "<textarea disabled name ='txtCouncilTarget' id ='txtCouncilTarget' class='form-control'cols='120' rows='3'>" + masteritem.CouncilTarget + "</textarea>";

            addtopage("CouncilTarget", CouncilTarget);
            string JoiningConditions = "<textarea disabled name ='txtCouncilTarget' id ='txtCouncilTarget' class='form-control'cols='120' rows='3'>" + masteritem.JoiningConditions + "</textarea>";
            addtopage("JoiningConditions", JoiningConditions);
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            string CouncilTypename = new knowledgeCouncil().GetCouncilTypeByid(Convert.ToInt32(masteritem.CouncilType), languageCode);

            addtopage("CouncilDate", masteritem.CouncilDate.ToString("dd MMM yyyy"), "CouncilType", CouncilTypename);
            return masteritem.Status;
        }

        private void UserData(string userloginName)
        {
            try
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().GetEmployeeMasterDataByEmployeeNumber(userloginName);
                foreach (EmployeeMasterDataEntity item in EmployeeValues)
                {
                    Enumber.Value = item.employeeNumberField.ToString();
                    EFullNameArabic.Value = item.employeeNameArabicField.ToString();
                    EFullNameEnglish.Value = item.employeeNameEnglishField.ToString();
                    EEmail.Value = item.employeeEmailField.ToString();
                    if (languageCode == "ar")
                    {
                        EDepartment.Value = item.departmentNameField_AR.ToString();
                        ENationality.Value = item.nationality_ARField.ToString();
                        EPosition.Value = item.positionNameField_AR.ToString();
                        EMaritalStatus.Value = item.maritalStatus_ARField.ToString();
                    }
                    else
                    {
                        EDepartment.Value = item.departmentNameField_US.ToString();
                        ENationality.Value = item.nationality_USField.ToString();
                        EPosition.Value = item.positionNameField_US.ToString();
                        EMaritalStatus.Value = item.maritalStatus_USField.ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }               
        public string GetPeriodicalFormForGovernmentHousingData(string RequestID)
        {
            PeriodicalFormForGovernmentHousingEntity masteritem = new PeriodicalFormForGovernmentHousing().GetByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", masteritem.RequestNumber, "RequestDate", masteritem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(masteritem.CreatedBy.User.LoginName));
            addtopage("ContractNumber", masteritem.ContractNumber, "ApartmentNumber", masteritem.ApartmentNumber);
           addtopage("Owner", masteritem.Owner, "NumberOfRooms", masteritem.NumberOfRooms);
           addtopage("ACtype", masteritem.ACtype, "LeasingContractEndDate", masteritem.LeasingContractEndDate);
           addtopage("Mobile", masteritem.Mobile, "HomePhone", masteritem.HomePhone);           
           addtopage("WorkPhone", masteritem.WorkPhone);
            AllData.Text += "<hr>";

            string text1= masteritem.HusbandORWife;
            string trim1 = text1.Replace(" ", "");
            var valuetext1 = SPUtility.GetLocalizedString("$Resources: " + trim1, "Resource", SPContext.Current.Web.Language);
           

            addtopage("Data", valuetext1);
            List<HusbandORWifeEntity> HusbandORWifeis = new PeriodicalFormForGovernmentHousing().GetHusbandORWife(masteritem.RequestNumber);
            int i = 0;
            foreach (HusbandORWifeEntity HW in HusbandORWifeis)
            {
                if (i % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                addtopage("Name", HW.Name, "HiringDate", Convert.ToDateTime(HW.HiringDate).ToString("dd MMM yyyy"));
                string text2 = HW.workSector;
                string trim2 = text2.Replace(" ", "");
                var valuetext2 = SPUtility.GetLocalizedString("$Resources: " + trim2, "Resource", SPContext.Current.Web.Language);

                addtopage("WorkSector", valuetext2, "BasicSalary", HW.BasicSalary);
                addtopage("LastEntryDate", HW.LastEntryDate, "LastExitDate", HW.LastExitDate);               

                 var HasGovernmentHousingPercentageAllowanceHtml = "<span class='icon-times'></span>";              
                if (HW.HasGovernmentHousingPercentageAllowance)
                    HasGovernmentHousingPercentageAllowanceHtml = "<span class='icon-check'></span>";
                addtopage("HasGovernmentHousingPercentageAllowance", HasGovernmentHousingPercentageAllowanceHtml);
                AllData.Text += "</div>";
                i++;
            }
            AllData.Text += "<hr>";
            //-------------------------------------------------------
            string textChildren = SPUtility.GetLocalizedString("$Resources: Children", "Resource", SPContext.Current.Web.Language);
            AllData.Text += "<div class='row rt  botx'><label>" + textChildren + "</label></div>";
            List<SonsEntity> sons = new PeriodicalFormForGovernmentHousing().Getsons(masteritem.RequestNumber);
            int conter = 0;
            foreach (SonsEntity son in sons)
            {
                if (conter % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                string text3 = son.Gender;
                string trim3 = text3.Replace(" ", "");
                var valuetext3 = SPUtility.GetLocalizedString("$Resources: " + trim3, "Resource", SPContext.Current.Web.Language);

                addtopage("Name", son.Name, "Gender", valuetext3);
                string text4 = son.Career;
                string trim4 = text4.Replace(" ", "");
                var valuetext4 = SPUtility.GetLocalizedString("$Resources: " + trim4, "Resource", SPContext.Current.Web.Language);


               
                addtopage("age", son.age, "Career" , valuetext4);
                if (son.Career!= "Student" && son.Career!="طالب")
                {
                    var HousingAllowanceHtml = "<span class='icon-times'></span>";
                    if (son.HousingAllowance)
                        HousingAllowanceHtml = "<span class='icon-check'></span>";
                    addtopage("BasicSalary", son.BasicSalary, "Career", HousingAllowanceHtml);
                }

                addtopage("LastEntryDate", son.LastEntryDate, "LastExitDate", son.LastExitDate);

                AllData.Text += "</div>";
                conter++;
            }            
            return masteritem.Status;
        }

        public string GetReturnNoticeData(string RequestID)

        {
            ReturnToDutyNoticeMembersOfTheJudiciaryEntity obitem = new ReturnToDutyNoticeMembersOfTheJudiciary().GetByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", obitem.RequestNumber, "RequestDate", obitem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(obitem.CreatedBy.User.LoginName));
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            if (languageCode == "ar")
            {
                addtopage("ResponseMsg", obitem.ResponseMsgAR);

                addtopage("Emirate", obitem.DayAr);
            }
            else
            {
                addtopage("ResponseMsg", obitem.ResponseMsg);

                addtopage("Emirate", obitem.DayEn);
            }
            addtopage("Date", Convert.ToDateTime(obitem.date).ToString("dd MMM yyyy"));           
            AllData.Text += "<hr>";
            return obitem.Status;
        }

        public string GetAffirmationGHousingHotelData(string RequestID)
        {

            AffirmationReceiptGovernmentHousingEntity AGHousing = new AffirmationReceiptGovernmentHousing().GetByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", AGHousing.RequestNumber, "RequestDate", AGHousing.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(AGHousing.CreatedBy.User.LoginName));
            addtopage("MobileNumber", AGHousing.MobileNumber, "ApportionmentDate", Convert.ToDateTime(AGHousing.ApportionmentDate).ToString("dd MMM yyyy"));               
                addtopage("HomeAddress", AGHousing.HomeAddress, "VilaApartmentNumber", AGHousing.VilaApartmentNumber);               
                addtopage("NumberOfRooms", AGHousing.NumberOfRooms, "Owner", AGHousing.Owner);               
                addtopage("agent", AGHousing.agent);       
            return AGHousing.Status;
        }
        
        public string GetReserveHotelData(string RequestID)
        {

            ReserveHotelEntity RHotel = new ReserveHotel().GetByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", RHotel.RequestNumber, "RequestDate", RHotel.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(RHotel.CreatedBy.User.LoginName));
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();         
                if (languageCode == "ar")
                {
                addtopage("Emirate", RHotel.EmirateAr);
                 }
                else
                {
                addtopage("Emirate", RHotel.EmirateEn);
                 }
                
            List<ReserveHotelPeopleEntity> RHPeople = new ReserveHotel().GetReserveHotelPeople(RHotel.RequestNumber);
            int i = 0;
            foreach (ReserveHotelPeopleEntity HW in RHPeople)
            {
                if (i % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                addtopage("Name", HW.Name, "Job", HW.Job);
               
                addtopage("from", Convert.ToDateTime(HW.from).ToString("dd MMM yyyy"), "to", Convert.ToDateTime(HW.to).ToString("dd MMM yyyy"));
                addtopage("mission", HW.Task);
                AllData.Text += "</div>";
                i++;
            }
            AllData.Text += "<hr>";
            
           return RHotel.Status;
        }

        public string GetFazaaCardRequestData(string RequestID)
        {
            FazaaCardRequestEntity Fazaaitem = new FazaaCardRequest().GetFazaaCardRequest(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", Fazaaitem.RequestNumber, "RequestDate", Fazaaitem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(Fazaaitem.CreatedBy.User.LoginName));
          
            return Fazaaitem.Status;
        }
        public string GetCarOrderServiceData(string RequestID)
        {
            CarOrderServiceEntity caritem = new CarOrderServiceBL().GetCarOrderServiceByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", caritem.RequestNumber, "RequestDate", caritem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(caritem.CreatedBy.User.LoginName));
            addtopage("Carwith", caritem.TravelNeeds);
            addtopage("GoingTo", caritem.TravelTo);
            addtopage("PassengerName", caritem.NameOfPassengers);
            addtopage("TravelReason", caritem.TravelReason, "CarPlace", caritem.CarPlace);
            string Tdate = Convert.ToDateTime(caritem.TravelDate).ToString("dd MMM yyyy hh:mm tt");
            addtopage("TravelDate", Tdate, "TravelDuration", caritem.Duration);
            return caritem.Status;
        }
        public void GetTasksRequest(string RequestID, string RequestName)
        {
            AllData.Text += "<hr>";
            addtopage("Tasks", "", "title");
            
            List<TaskEntity> task = new Task().GetTasksRequest(RequestID, RequestName);
            int i = 0;
            foreach (TaskEntity item in task)
            {
                if (i % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                string OutcomeWf = item.WorkflowOutcome;
                string ActionDate = "";
                if (item.Status == "Completed") { 
                     ActionDate = item.ActionDate.ToString("dd MMM yyyy HH:mm:ss");
                    btnCanceled.Visible = false;
                }
                if (string.IsNullOrEmpty(OutcomeWf))                
                    OutcomeWf = "Pending";
                string Answer  = item.AnswerBy.LookupValue;
                if (string.IsNullOrEmpty(item.AnswerBy.LookupValue))
                    Answer = item.AssignedToOneUserValue.LookupValue;
                addtopage("AssignTo", Answer, OutcomeWf, "");
                addtopage("ActionDate", ActionDate);
                string Commenthtm = "<textarea disabled name ='txtComment' id ='txtComment' cols='70' rows='3'>" + item.Comment + "</textarea>";

                addtopage("Comment", Commenthtm);
                
               AllData.Text += "</div>";
                i++;
            }
            
            
       }
        public string GetContactWithHRData(string RequestID)
        {
            ContactWithHREntity item = new ContactWithHR().GetContactWithHR(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", item.RequestNumber, "RequestDate", item.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(item.CreatedBy.User.LoginName));
            addtopage("ContactReason", item.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='70' rows='3'>" + item.Message + "</textarea>";
            addtopage("Message", Messaghtm);
            return item.Status;
        }

        public string GetHappinessHotlineData(string RequestID)
        {
            HappinessHotlineEntity HappinessHotlin = new HappinessHotline().GetHappinessHotline(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", HappinessHotlin.RequestNumber, "RequestDate", HappinessHotlin.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(HappinessHotlin.CreatedBy.User.LoginName));
            addtopage("ContactReason", HappinessHotlin.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='70' rows='3'>" + HappinessHotlin.Message + "</textarea>";
            addtopage("Message", Messaghtm);
            return HappinessHotlin.Status;
        }
        public string GetAffirmationSocialSituationData(string RequestID)
        {

            AffirmationSocialSituationEntity AffirmationSocial = new AffirmationSocialSituationB().GetAffirmationSocialSituation(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", AffirmationSocial.RequestNumber, "RequestDate", AffirmationSocial.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(AffirmationSocial.CreatedBy.User.LoginName));


            string text = AffirmationSocial.HusbandORWife;
            string trim = text.Replace(" ", "");
            var HusbandORWifetext = SPUtility.GetLocalizedString("$Resources: " + trim, "Resource", SPContext.Current.Web.Language);
           

            addtopage("Data", HusbandORWifetext);
            List<HusbandORWifeEntity> HusbandORWifeis = new AffirmationSocialSituationB().GetHusbandORWife(AffirmationSocial.RequestNumber);
            int i = 0;
            foreach (HusbandORWifeEntity HW in HusbandORWifeis)
            {
                if (i % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                addtopage("Name", HW.Name);
                addtopage("DateMarriage", Convert.ToDateTime(HW.DateOfMarriage).ToString("dd MMM yyyy"), "Employer", HW.Employer);
                string workSectortext1 = HW.workSector;
                string workSectortrim = workSectortext1.Replace(" ", "");
                var workSectortext = SPUtility.GetLocalizedString("$Resources: " + workSectortrim, "Resource", SPContext.Current.Web.Language);




                addtopage("WorkSector", workSectortext, "HiringDate", Convert.ToDateTime(HW.HiringDate).ToString("dd MMM yyyy"));
                var HasGovernmentHousingAllowanceHtml = "<span class='icon-times'></span>";
                var HasGovernmentHousingPercentageAllowanceHtml = "<span class='icon-times'></span>";
                if (HW.HasGovernmentHousingAllowance)
                    HasGovernmentHousingAllowanceHtml = "<span class='icon-check'></span>"; if (HW.HasGovernmentHousingPercentageAllowance)
                    HasGovernmentHousingPercentageAllowanceHtml = "<span class='icon-check'></span>";
                addtopage("HasGovernmentHousingAllowance", HasGovernmentHousingAllowanceHtml, "HasGovernmentHousingPercentageAllowance", HasGovernmentHousingPercentageAllowanceHtml);
                AllData.Text += "</div>";
                i++;
            }
            AllData.Text += "<hr>";
            //-------------------------------------------------------
            string textChildren = SPUtility.GetLocalizedString("$Resources: Children", "Resource", SPContext.Current.Web.Language);
            AllData.Text += "<div class='row rt  botx'><label>" + textChildren + "</label></div>";

            List<SonsEntity> sons = new AffirmationSocialSituationB().Getsons(AffirmationSocial.RequestNumber);
            int conter = 0;
            foreach (SonsEntity son in sons)
            {
                if (conter % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                addtopage("Name", son.Name);
                string Gendertext1 = son.Gender;
                string Gendertrim = Gendertext1.Replace(" ", "");
                var Gendertext = SPUtility.GetLocalizedString("$Resources: " + Gendertrim, "Resource", SPContext.Current.Web.Language);

                addtopage("Gender", Gendertext, "age", son.age);
                AllData.Text += "</div>";
                conter++;
            }
            AllData.Text += "<hr>";
            //--------------------------------------
            string ChangeSS = SPUtility.GetLocalizedString("$Resources: ChangeSocialStatus", "Resource", SPContext.Current.Web.Language);
            AllData.Text += "<div class='row rt  botx'><label>" + ChangeSS + "</label></div>"; addtopage("Name", AffirmationSocial.Name);
            addtopage("RelationshipType", AffirmationSocial.RelationshipType);
            addtopage("ChangeReason", AffirmationSocial.ChangeReason);
            addtopage("ChangeDate", Convert.ToDateTime(AffirmationSocial.ChangeDate).ToString("dd MMM yyyy"));
            return AffirmationSocial.Status;
        }
        public string GetRoomBookingData(string RequestID)
        {
            string valResourcesNeeded = "";
            
           RoomBookingEntity Room = new RoomBooking().GetRoomBooking(Convert.ToInt32(RequestID));
            
            SPFieldMultiChoiceValue choices = Room.ResourcesNeeded;
            
            if (choices != null)
            {
                for (int i = 0; i < choices.Count; i++)
                {

                    string text = choices[i].ToString();
                    string Choicetrim = text.Replace(" ", "");
                    var placetext = SPUtility.GetLocalizedString("$Resources: " + Choicetrim, "Resource", SPContext.Current.Web.Language);

                    valResourcesNeeded += "&nbsp;&nbsp;" + placetext + "&nbsp;&nbsp;";
                }
            }
            addtopage("RequestNumber", Room.RequestNumber, "RequestDate", Room.Created.ToString("dd MMM yyyy"), "title");

            UserData(Convert.ToString(Room.CreatedBy.User.LoginName));

            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            if (languageCode == "ar")
            {
                addtopage("Emirate", Room.EmirateAr);
            }
            else
            {
                addtopage("Emirate", Room.EmirateEn);
            }

            string textRoom = Room.Place;
            string ChoiceRoomtrim = textRoom.Replace(" ", "");
            var placeRoomtext = SPUtility.GetLocalizedString("$Resources: " + ChoiceRoomtrim, "Resource", SPContext.Current.Web.Language);


            addtopage("Place", placeRoomtext);
            addtopage("AttendeesNumber", Room.AttendeesNumber);
            if (!string.IsNullOrEmpty(Room.DateFrom))
            {
                addtopage("fromDate", Convert.ToDateTime(Room.DateFrom).ToString("dd MMM yyyy hh:mm tt"));
            }

            if (!string.IsNullOrEmpty(Room.DateTo))
            {
                addtopage("toDate", Convert.ToDateTime(Room.DateTo).ToString("dd MMM yyyy hh:mm tt"));

            }
            addtopage("mission", Room.Mission);
            addtopage("resources", valResourcesNeeded);
             return Room.Status;
        }

        protected void addtopage(string text, string value, string title = "")
        {
            string textla = SPUtility.GetLocalizedString("$Resources: " + text, "Resource", SPContext.Current.Web.Language);
            if (title != "")
                AllData.Text += "<div class='RequestTitle'>";
            AllData.Text += @"<div class='row rt'>
                        <div class='col-md-12'>
                            <div class='row'>
                                <div class='col-md-3'>
                                <label >" + textla + @"</label>
                               </div>
                                <div class='col-md-9'>
                        <label >" + value + @"</label>                               
                                </div>
                            </div>
                        </div>                        
                    </div>";
            if (title != "")
                AllData.Text += "</div>";
        }
        protected void addtopage(string text, string value, string text2, string value2, string title = "")
        {
            string textla = SPUtility.GetLocalizedString("$Resources: " + text, "Resource", SPContext.Current.Web.Language);
            string textlb = SPUtility.GetLocalizedString("$Resources: " + text2, "Resource", SPContext.Current.Web.Language);
            if (title != "")
            {
                TitleData.Text += "<div class='RequestTitle'>";
                TitleData.Text += @"<div class='row rt'>
                        <div class='col-md-6'>
                            <div class='row'>
                                <div class='col-md-4'>
                                <label >" + textla + @"</label>
                               </div>
                                <div class='col-md-8'>
                        <label >" + value + @"</label>                               
                                </div>
                            </div>
                        </div> 
                            <div class='col-md-6'>
                            <div class='row'>
                                <div class='col-md-4'>
                                <label >" + textlb + @"</label>
                               </div>
                                <div class='col-md-8'>
                        <label >" + value2 + @"</label>                               
                                </div>
                            </div>
                        </div>
                    </div>";
                TitleData.Text += "</div>";

            }
            else
            {
                AllData.Text += @"<div class='row rt'>
                        <div class='col-md-6'>
                            <div class='row'>
                                <div class='col-md-4'>
                                <label >" + textla + @"</label>
                               </div>
                                <div class='col-md-8'>
                        <label >" + value + @"</label>                               
                                </div>
                            </div>
                        </div> 
                            <div class='col-md-6'>
                            <div class='row'>
                                <div class='col-md-4'>
                                <label >" + textlb + @"</label>
                               </div>
                                <div class='col-md-8'>
                        <label >" + value2 + @"</label>                               
                                </div>
                            </div>
                        </div>
                    </div>";
            }
        }

    }
}
