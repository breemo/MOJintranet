using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            }
            else
            {

                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: noPermission", "Resource", SPContext.Current.Web.Language) + "<br />";
                posts.Style.Add("display", "none");
                SuccessMsgDiv.Style.Add("display", "block");
            }
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
            CompleteTask("Approved");

        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            CompleteTask("Rejected");
        }
        private void CompleteTask(string Outcome)
        {
            TaskEntity Taskitem = new Task().GetTask(Convert.ToInt32(Request.Params["TID"]));
            Taskitem.Comment = txtMission.Value;
            Taskitem.WorkflowOutcome = Outcome;
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
