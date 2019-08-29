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
            string Status="";
                // add new workflow-----------------------------------
                if (listName == "RoomBooking")
                Status= GetRoomBookingData(RequestID);
                if (listName == "AffirmationSocialSituation")
                Status= GetAffirmationSocialSituationData(RequestID);
                if (listName == "HappinessHotline")
                Status= GetHappinessHotlineData(RequestID);
            if (listName == "CarOrderService")
                Status= GetCarOrderServiceData(RequestID);
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



            GetTasksRequest(RequestID, listName);
            AllData.Text += "<hr>";
            addtopage(Status, "");

        }
        public string GetPeriodicalFormForGovernmentHousingData(string RequestID)
        {
            PeriodicalFormForGovernmentHousingEntity masteritem = new PeriodicalFormForGovernmentHousing().GetByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", masteritem.RequestNumber, "title"); 
           addtopage("ContractNumber", masteritem.ContractNumber, "ApartmentNumber", masteritem.ApartmentNumber);
           addtopage("Owner", masteritem.Owner, "NumberOfRooms", masteritem.NumberOfRooms);
           addtopage("ACtype", masteritem.ACtype, "LeasingContractEndDate", masteritem.LeasingContractEndDate);
           addtopage("Mobile", masteritem.Mobile, "HomePhone", masteritem.HomePhone);           
           addtopage("WorkPhone", masteritem.WorkPhone);         

            AllData.Text += "<hr>";
            addtopage("Data", masteritem.HusbandORWife);
            List<HusbandORWifeEntity> HusbandORWifeis = new PeriodicalFormForGovernmentHousing().GetHusbandORWife(masteritem.RequestNumber);
            int i = 0;
            foreach (HusbandORWifeEntity HW in HusbandORWifeis)
            {
                if (i % 2 == 0)
                    AllData.Text += "<div>";
                else
                    AllData.Text += "<div class='evenRow'>";
                addtopage("Name", HW.Name, "HiringDate", Convert.ToDateTime(HW.HiringDate).ToString("dd MMM yyyy"));
                addtopage("WorkSector", HW.workSector, "BasicSalary", HW.BasicSalary);
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
                addtopage("Name", son.Name, "Gender", son.Gender);
                addtopage("age", son.age, "Career" ,son.Career);
                addtopage("age", son.age, "Career" ,son.Career);
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
            addtopage("RequestNumber", obitem.RequestNumber, "title");
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            if (languageCode == "ar")
            {
                addtopage("Emirate", obitem.DayAr);
            }
            else
            {
                addtopage("Emirate", obitem.DayEn);
            }
            addtopage("Date", Convert.ToDateTime(obitem.date).ToString("dd MMM yyyy"));           
            AllData.Text += "<hr>";
            return obitem.Status;
        }

        public string GetAffirmationGHousingHotelData(string RequestID)
        {

            AffirmationReceiptGovernmentHousingEntity AGHousing = new AffirmationReceiptGovernmentHousing().GetByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", AGHousing.RequestNumber, "title");       
                addtopage("MobileNumber", AGHousing.MobileNumber, "ApportionmentDate", Convert.ToDateTime(AGHousing.ApportionmentDate).ToString("dd MMM yyyy"));               
                addtopage("HomeAddress", AGHousing.HomeAddress, "VilaApartmentNumber", AGHousing.VilaApartmentNumber);               
                addtopage("NumberOfRooms", AGHousing.NumberOfRooms, "Owner", AGHousing.Owner);               
                addtopage("agent", AGHousing.agent);       
            return AGHousing.Status;
        }
        
        public string GetReserveHotelData(string RequestID)
        {

            ReserveHotelEntity RHotel = new ReserveHotel().GetByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", RHotel.RequestNumber, "title");
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
            addtopage("RequestNumber", Fazaaitem.RequestNumber, "title");
            string Commenthtml = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + Fazaaitem.Comment + "</textarea>";
            addtopage("Comment", Commenthtml);
            return Fazaaitem.Status;
        }
        public string GetCarOrderServiceData(string RequestID)
        {
            CarOrderServiceEntity caritem = new CarOrderServiceBL().GetCarOrderServiceByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", caritem.RequestNumber, "title");
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
                if (string.IsNullOrEmpty(OutcomeWf))
                
                    OutcomeWf = "Pending";
                string Answer  = item.AnswerBy.LookupValue;
                if (string.IsNullOrEmpty(item.AnswerBy.LookupValue))
                    Answer = item.AssignedToOneUserValue.LookupValue;
                addtopage("AssignTo", Answer, OutcomeWf, "");
                string Commenthtm = "<textarea disabled name ='txtComment' id ='txtComment' class='form-control'cols='120' rows='3'>" + item.Comment + "</textarea>";

                addtopage("Comment", Commenthtm);
                
               AllData.Text += "</div>";
                i++;
            }
            
       }
        public string GetContactWithHRData(string RequestID)
        {
            ContactWithHREntity item = new ContactWithHR().GetContactWithHR(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", item.RequestNumber, "title");
            addtopage("ContactReason", item.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + item.Message + "</textarea>";
            addtopage("Message", Messaghtm);
            return item.Status;
        }

        public string GetHappinessHotlineData(string RequestID)
        {
            HappinessHotlineEntity HappinessHotlin = new HappinessHotline().GetHappinessHotline(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", HappinessHotlin.RequestNumber, "title");
            addtopage("ContactReason", HappinessHotlin.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + HappinessHotlin.Message + "</textarea>";
            addtopage("Message", Messaghtm);
            return HappinessHotlin.Status;
        }
        public string GetAffirmationSocialSituationData(string RequestID)
        {

            AffirmationSocialSituationEntity AffirmationSocial = new AffirmationSocialSituationB().GetAffirmationSocialSituation(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", AffirmationSocial.RequestNumber, "title");
            addtopage("Data", AffirmationSocial.HusbandORWife);
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
                addtopage("WorkSector", HW.workSector, "HiringDate", Convert.ToDateTime(HW.HiringDate).ToString("dd MMM yyyy"));
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
                addtopage("Gender", son.Gender, "age", son.age);
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
                    valResourcesNeeded += "&nbsp;&nbsp;" + choices[i] + "&nbsp;&nbsp;";
                }
            }
            addtopage("RequestNumber", Room.RequestNumber, "title");
            addtopage("Place", Room.Place);
            addtopage("AttendeesNumber", Room.AttendeesNumber);
            addtopage("fromDate", Convert.ToDateTime(Room.DateFrom).ToString("dd MMM yyyy hh:mm tt"));
            addtopage("toDate", Convert.ToDateTime(Room.DateTo).ToString("dd MMM yyyy hh:mm tt"));
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
        protected void addtopage(string text, string value, string text2, string value2)
        {
            string textla = SPUtility.GetLocalizedString("$Resources: " + text, "Resource", SPContext.Current.Web.Language);
            string textlb = SPUtility.GetLocalizedString("$Resources: " + text2, "Resource", SPContext.Current.Web.Language);
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
