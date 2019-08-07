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
                GetTaskandRoomBooking();

            }
        }
   

        private void GetTaskandRoomBooking()
        {
            TaskEntity task = new Task().GetTask(Convert.ToInt32(Request.Params["TID"]));
            ValTaskName.Text= task.Title;
            RoomBookingEntity Room = new RoomBooking().GetRoomBooking(Convert.ToInt32(task.RequestID));
            valAttendeesNumber.Text = Room.AttendeesNumber;
            valMission.Text = Room.Mission;
            
            valBookingDateFrom.Text = Convert.ToDateTime(Room.DateFrom).ToString("dd MMM yyyy hh:mm tt");
            valBookingDateTo.Text = Convert.ToDateTime(Room.DateTo).ToString("dd MMM yyyy hh:mm tt");

           
        }



        protected void btnapprove_Click(object sender, EventArgs e)

        {
            TaskEntity Taskitem = new TaskEntity();

            Taskitem.Comment = txtMission.Value;
            Taskitem.WorkflowOutcome = "Approved";
           // Taskitem.PercentComplete = "100";
            Taskitem.Status = "Completed";

           

            Task rb = new Task();
            bool isSaved = rb.SaveUpdate(Taskitem);

            if (isSaved == true)
            {
                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" ;
                posts.Style.Add("display", "none");
                SuccessMsgDiv.Style.Add("display", "block");
            }












        }


    }
}
