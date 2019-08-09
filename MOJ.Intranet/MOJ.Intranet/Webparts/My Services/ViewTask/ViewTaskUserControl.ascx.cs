using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
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
            AllData.Text = task.AssignedToGroup;
           
            bool havePermission = new Task().HavePermission(Convert.ToInt32(Request.Params["TID"]));
            if (havePermission)
            {
                string valResourcesNeeded = "";
                RoomBookingEntity Room = new RoomBooking().GetRoomBooking(Convert.ToInt32(task.RequestID));
                SPFieldMultiChoiceValue choices = Room.ResourcesNeeded;
                for (int i = 0; i < choices.Count; i++)
                {
                    valResourcesNeeded += "&nbsp;&nbsp;" + choices[i] + "&nbsp;&nbsp;";
                }
                addtopage("AttendeesNumber", Room.AttendeesNumber);
                addtopage("fromDate", Convert.ToDateTime(Room.DateFrom).ToString("dd MMM yyyy hh:mm tt"));
                addtopage("toDate", Convert.ToDateTime(Room.DateTo).ToString("dd MMM yyyy hh:mm tt"));
                addtopage("mission", Room.Mission);
                addtopage("resources", valResourcesNeeded);

            }
            else
            {

                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: noPermission", "Resource", SPContext.Current.Web.Language) + "<br />";
                posts.Style.Add("display", "none");
                SuccessMsgDiv.Style.Add("display", "block");
            }
            
        }

        protected void addtopage(string text,string value)
        {
            string textla = SPUtility.GetLocalizedString("$Resources: "+text, "Resource", SPContext.Current.Web.Language);
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
