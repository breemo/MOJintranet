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
                if(task.WorkflowName == "RoomBooking")
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


                GetTasksRequest(task.RequestID, task.WorkflowName);

            }
            else
            {

                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: noPermission", "Resource", SPContext.Current.Web.Language) + "<br />";
                posts.Style.Add("display", "none");
                SuccessMsgDiv.Style.Add("display", "block");
            }

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
            addtopage("RequestNumber", ContactWithHRitm.RequestNumber, "title");
            addtopage("ContactReason", ContactWithHRitm.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + ContactWithHRitm.Message + "</textarea>";
            addtopage("Message", Messaghtm);
        }
        public void GetFazaaCardRequestData(string RequestID)
        {
            FazaaCardRequestEntity Fazaaitem = new FazaaCardRequest().GetFazaaCardRequest(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", Fazaaitem.RequestNumber, "title");           
            string Commenthtml = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + Fazaaitem.Comment + "</textarea>";
            addtopage("Comment", Commenthtml);
        }
        public void GetCarOrderServiceData(string RequestID)
        {
            CarOrderServiceEntity caritem = new CarOrderServiceBL().GetCarOrderServiceByID(Convert.ToInt32(RequestID));
            addtopage("RequestNumber", caritem.RequestNumber, "title");
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
            addtopage("RequestNumber", HappinessHotlin.RequestNumber, "title");
            addtopage("ContactReason", HappinessHotlin.ContactReason);
            string Messaghtm = "<textarea disabled name ='txtMessag' id ='txtMessage' class='form-control'cols='120' rows='3'>" + HappinessHotlin.Message + "</textarea>";
            addtopage("Message", Messaghtm);
        }
        public void GetAffirmationSocialSituationData(string RequestID)
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
                HasGovernmentHousingAllowanceHtml = "<span class='icon-check'></span>";                if (HW.HasGovernmentHousingPercentageAllowance)
                HasGovernmentHousingPercentageAllowanceHtml = "<span class='icon-check'></span>";
                addtopage("HasGovernmentHousingAllowance", HasGovernmentHousingAllowanceHtml, "HasGovernmentHousingPercentageAllowance", HasGovernmentHousingPercentageAllowanceHtml);
               AllData.Text += "</div>";
                i++;
            }
            AllData.Text +="<hr>";
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
             AllData.Text += "<div class='row rt  botx'><label>"+ ChangeSS + "</label></div>";        addtopage("Name", AffirmationSocial.Name);            
            addtopage("RelationshipType", AffirmationSocial.RelationshipType);
            addtopage("ChangeReason", AffirmationSocial.ChangeReason);
            addtopage("ChangeDate", Convert.ToDateTime(AffirmationSocial.ChangeDate).ToString("dd MMM yyyy"));                    
        }
        public void GetRoomBookingData(string RequestID) { 
          string valResourcesNeeded = "";
                RoomBookingEntity Room = new RoomBooking().GetRoomBooking(Convert.ToInt32(RequestID));
                SPFieldMultiChoiceValue choices = Room.ResourcesNeeded;
                if (choices!=null)
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
    }
}
