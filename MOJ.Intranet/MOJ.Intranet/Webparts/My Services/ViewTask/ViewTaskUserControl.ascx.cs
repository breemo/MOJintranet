using CommonLibrary;
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

namespace MOJ.Intranet.Webparts.My_Services.ViewTask
{
    public partial class ViewTaskUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["TID"]))
                {
                    GetTaskandRequest();

                }
                else
                {
                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: NoTasks", "Resource", SPContext.Current.Web.Language) + "<br />";
                    posts.Style.Add("display", "none");
                    SuccessMsgDiv.Style.Add("display", "block");
                }
            }
        }
        private void GetTaskandRequest()
        {
            TaskEntity task = new Task().GetTask(Convert.ToInt32(Request.Params["TID"]));
            ValTaskName.Text = task.Title; 
           
            if (task.Status == "Completed")
            {
                btnapprove.Enabled = false;
                btReject.Enabled = false;
                LabelAnswer.Text=  SPUtility.GetLocalizedString("$Resources: " + task.WorkflowOutcome, "Resource", SPContext.Current.Web.Language);

            }
            txtMission.InnerText = task.Comment;
            bool havePermission = new Task().HavePermission(Convert.ToInt32(Request.Params["TID"]));
            if (havePermission)
            { // add new workflow-----------------------------------
                if (task.WorkflowName == "RoomBooking")
                    GetRoomBookingData(task.RequestID);
                if (task.WorkflowName == "AffirmationSocialSituation")
                    GetAffirmationSocialSituationData(task.RequestID);
                if (task.WorkflowName == "HappinessHotline")
                    GetHappinessHotlineData(task.RequestID);
                if (task.WorkflowName == "CarOrderService")
                    GetCarOrderServiceData(task.RequestID);
                if (task.WorkflowName == "FazaaCardRequest")
                    GetFazaaCardRequestData(task.RequestID);
                if (task.WorkflowName == "ContactWithHR")
                    GetContactWithHRData(task.RequestID);
                if (task.WorkflowName == "ReserveHotel")
                    GetReserveHotelData(task.RequestID);
                if (task.WorkflowName == "AffirmationReceiptGovernmentHousing")
                    GetAffirmationGHousingHotelData(task.RequestID);
                if (task.WorkflowName == "ReturnToDutyNoticeMembersOfTheJudiciary")
                    GetReturnNoticeData(task.RequestID);
                if (task.WorkflowName == "PeriodicalFormForGovernmentHousing")
                    GetPeriodicalFormForGovernmentHousingData(task.RequestID);

                if (task.WorkflowName == "knowledgeCouncil")
                    GetknowledgeCouncil(task.RequestID);
                if (task.WorkflowName == "CouncilMembers")
                    GetCouncilMembers(task.RequestID);
                if (task.WorkflowName == "AskAnExpert")
                    GetAskAnExpert(task.RequestID);
                ////
               
                if (task.WorkflowName != "AskAnExpert") {
                    GetTasksRequest(task.RequestID, task.WorkflowName);
                }

            }
            else
            {
                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: noPermission", "Resource", SPContext.Current.Web.Language) + "<br />";
                posts.Style.Add("display", "none");
                SuccessMsgDiv.Style.Add("display", "block");
            }

        }

        public string GetAskAnExpert(string RequestID)
        {
            AskAnExpertEntity masteritem = new AskAnExpert().GetAskAnExpertbyid(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", masteritem.Title, "RequestDate", masteritem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(masteritem.CreatedBy.User.LoginName));
            addtopage("Department", masteritem.Department);
            addtopage("QuestionTitle", masteritem.QuestionTitle);
            string QuestionDetails = "<textarea disabled name ='txtQuestionDetails' id ='txtQuestionDetails' class='form-control'cols='120' rows='3'>" + masteritem.QuestionDetails + "</textarea>";

            addtopage("QuestionDetails", QuestionDetails);
            btReject.Visible = false;
            GetAskAnExpertAnswer(RequestID);
            return masteritem.Status;
        }
        public void GetAskAnExpertAnswer(string RequestID)
        {
           
           
            AllData.Text += "<hr>";
            addtopage("Tasks", "", "title");
          
            try
            {
                int i = 0;
                List<AskAnExpertAnswerEntity> CollectionAnswer = new AskAnExpert().GetAskAnExpertAnswerByID(Convert.ToInt32(RequestID));
                foreach (AskAnExpertAnswerEntity itemAnswer in CollectionAnswer)
                {
                    if (i % 2 == 0)
                        AllData.Text += "<div>";
                    else
                        AllData.Text += "<div class='evenRow'>";
                    addtopage("ExpertName", itemAnswer.ExpertName, "Position", itemAnswer.ExpertPosition);
                    string Commenthtm = "<textarea disabled name ='txtComment' id ='txtComment' cols='70' rows='3'>" + itemAnswer.Answer + "</textarea>";
                    addtopage("Comment", Commenthtm);
                    AllData.Text += "</div>";
                    i++;
                }

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
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

            string text1 = masteritem.HusbandORWife;
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


               
                addtopage("age", son.age, "Career", valuetext4);
                if (son.Career != "Student" && son.Career != "طالب")
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
           

            return RHotel.Status;
        }

        public void GetTasksRequest(string RequestID, string RequestName)
        {
            List<TaskEntity> task = new Task().GetTasksRequest(RequestID, RequestName, "Completed");
            if (task.Count>0) { 
            AllData.Text += "<hr>";
            addtopage("Tasks", "", "title");
        }
            
            int i = 0;
            foreach (TaskEntity item in task)
            {
                if (i % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                string OutcomeWf = item.WorkflowOutcome;
                if (string.IsNullOrEmpty(OutcomeWf))

                    OutcomeWf = "Pending";
                string Answer = item.AnswerBy.LookupValue;
                if (string.IsNullOrEmpty(item.AnswerBy.LookupValue))
                    Answer = item.AssignedToOneUserValue.LookupValue;
                addtopage("AssignTo", Answer, OutcomeWf, "");
                string Commenthtm = "<textarea disabled name ='txtComment' id ='txtComment' class='form-control'cols='120' rows='3'>" + item.Comment + "</textarea>";

                addtopage("Comment", Commenthtm);

                AllData.Text += "</div>";
                i++;
            }

        }
        public void GetContactWithHRData(string RequestID)
        {
            ContactWithHREntity ContactWithHRitm = new ContactWithHR().GetContactWithHR(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", ContactWithHRitm.RequestNumber, "RequestDate", ContactWithHRitm.Created.ToString("dd MMM yyyy"), "title");

            UserData(Convert.ToString(ContactWithHRitm.CreatedBy.User.LoginName));
            addtopage("ContactReason", ContactWithHRitm.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + ContactWithHRitm.Message + "</textarea>";
            addtopage("Message", Messaghtm);
        }
        public void GetFazaaCardRequestData(string RequestID)
        {
            FazaaCardRequestEntity Fazaaitem = new FazaaCardRequest().GetFazaaCardRequest(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", Fazaaitem.RequestNumber, "RequestDate", Fazaaitem.Created.ToString("dd MMM yyyy"), "title");
            UserData(Convert.ToString(Fazaaitem.CreatedBy.User.LoginName));
          
        }
        public void GetCarOrderServiceData(string RequestID)
        {
            CarOrderServiceEntity caritem = new CarOrderServiceBL().GetCarOrderServiceByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", caritem.RequestNumber, "RequestDate", caritem.Created.ToString("dd MMM yyyy"), "title");

            UserData(Convert.ToString(caritem.CreatedBy.User.LoginName));
            addtopage("Carwith", caritem.TravelNeeds);
            addtopage("GoingTo", caritem.TravelTo);
            addtopage("PassengerName", caritem.NameOfPassengers);
            addtopage("TravelReason", caritem.TravelReason, "CarPlace", caritem.CarPlace);
            string Tdate = Convert.ToDateTime(caritem.TravelDate).ToString("dd MMM yyyy");
            addtopage("TravelDate", Tdate, "TravelDuration", caritem.Duration);
        }
        public void GetHappinessHotlineData(string RequestID)
        {           
            HappinessHotlineEntity HappinessHotlin = new HappinessHotline().GetHappinessHotline(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", HappinessHotlin.RequestNumber, "RequestDate", HappinessHotlin.Created.ToString("dd MMM yyyy"), "title");

            UserData(Convert.ToString(HappinessHotlin.CreatedBy.User.LoginName));
            addtopage("ContactReason", HappinessHotlin.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + HappinessHotlin.Message + "</textarea>";
            addtopage("Message", Messaghtm);
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

        public void GetRoomBookingData(string RequestID) { 
          string valResourcesNeeded = "";
                RoomBookingEntity Room = new RoomBooking().GetRoomBooking(Convert.ToInt32(RequestID));
                SPFieldMultiChoiceValue choices = Room.ResourcesNeeded;
                if (choices!=null)
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
                addtopage("fromDate", Convert.ToDateTime(Room.DateFrom).ToString("dd MMM yyyy hh:mm tt"));
                addtopage("toDate", Convert.ToDateTime(Room.DateTo).ToString("dd MMM yyyy hh:mm tt"));
                addtopage("mission", Room.Mission);
                addtopage("resources", valResourcesNeeded);
        }
        protected void addtopage(string text,string value,string title="")
        {
            string textla = SPUtility.GetLocalizedString("$Resources: "+text, "Resource", SPContext.Current.Web.Language);
            if(title!="")
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
        protected void btnapprove_Click(object sender, EventArgs e)
        {
            CompleteTask("Approved","تمت الموافقة");

        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            CompleteTask("Rejected","تم الرفض");
        }
        private void CompleteTask(string Outcome ,string OutcomeArab)
        {
            TaskEntity Taskitem = new Task().GetTask(Convert.ToInt32(Request.Params["TID"]));
            if (Taskitem.WorkflowName == "AskAnExpert")
                AskAnExpertAnswer(Taskitem.RequestID);
            Taskitem.Comment = txtMission.Value;
            Taskitem.WorkflowOutcome = Outcome;
            Taskitem.WorkflowOutcomeAr = OutcomeArab;
            Taskitem.id = Convert.ToInt32(Request.Params["TID"]);
            Taskitem.Title = Convert.ToString(ValTaskName.Text);
            Taskitem.Status = "Completed";
            Task rb = new Task();
            bool isSaved = rb.SaveUpdate(Taskitem);
            if (isSaved == true)
            {
                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyTask", "Resource", SPContext.Current.Web.Language) + "<br />" ;
                posts.Style.Add("display", "none");
                SuccessMsgDiv.Style.Add("display", "block");
            }

        }
      
        private void AskAnExpertAnswer(string RequestID)
        {
            AskAnExpertEntity item = new AskAnExpert().GetAskAnExpertbyid(Convert.ToInt32(RequestID));
            AskAnExpertAnswerEntity AskAnExpertAnsweris = new AskAnExpertAnswerEntity();
            AskAnExpertAnsweris.Answer = txtMission.Value;
            AskAnExpertAnsweris.AskAnExpertID = RequestID;
            AskAnExpertAnsweris.Title = item.QuestionTitle;
            ExpertsEntity Expertsitem = new AskAnExpert().GetExpertsByID(Convert.ToInt32(item.ExpertID));
            string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
            AskAnExpertAnsweris.ExpertLoginName = currentUserlogin;
            AskAnExpertAnsweris.ExpertName = Expertsitem.ExpertName;
            AskAnExpertAnsweris.ExpertPosition = Expertsitem.ExpertPosition;

            bool isSaved =new  AskAnExpert().AddOrUpdateAskAnExpertAnswer(AskAnExpertAnsweris);
           

        }
    }
}
