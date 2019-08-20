using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace MOJ.Intranet.Webparts.My_Services.myTasks
{
    public partial class myTasksUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                List<TaskEntity> taskollection = new Task().GetMyTasks("NOCompleted");
                int i = 1;
                foreach (TaskEntity task in taskollection)
                {
                 string ServiceName=  SPUtility.GetLocalizedString("$Resources: " + task.ServiceName, "Resource", SPContext.Current.Web.Language);
                 string Title =  SPUtility.GetLocalizedString("$Resources: " + task.Title, "Resource", SPContext.Current.Web.Language);
                    
                    MyTasks.Text += @"<tr>
                   <td>" + i + @"</td>
                    <td><a href='" + task.TaskURL + @"'>" + task.RequestName + @"</a></td>
                    <td>" + ServiceName + @"</td>                    
                    <td>" + Title + @"</td> 
                    <td>" + task.Created.ToString("dd MMM yyyy hh:mm tt") + @"</td>                                        
                    <td><a href='"+ task.TaskURL + @"'><span class='icon-edit'> </span></a></td>
                    </tr>";
                    i++;

                }
                List<TaskEntity> taskollectionC = new Task().GetMyTasks("Completed");
                int i2 = 1;
                foreach (TaskEntity task in taskollectionC)
                {
                    string ServiceName = SPUtility.GetLocalizedString("$Resources: " + task.ServiceName, "Resource", SPContext.Current.Web.Language);
                    string Title = SPUtility.GetLocalizedString("$Resources: " + task.Title, "Resource", SPContext.Current.Web.Language);
                    string Outcome = "";
                    if (!string.IsNullOrEmpty(task.WorkflowOutcome))
                        Outcome = SPUtility.GetLocalizedString("$Resources: " + task.WorkflowOutcome, "Resource", SPContext.Current.Web.Language);

                    MyAccomplishedTasks.Text += @"<tr>
                   <td>" + i2 + @"</td>
                    <td><a href='" + task.TaskURL + @"'>" + task.RequestName + @"</a></td>
                    <td>" + ServiceName + @"</td>                    
                    <td>" + Title + @"</td>                   
                    <td>" + Outcome + @"</td>
                    <td>" + task.Created.ToString("dd MMM yyyy hh:mm tt") + @"</td>                                        
                    <td><a href='" + task.TaskURL + @"'><span class='icon-edit'> </span></a></td>
                    </tr>";
                    i++;

                }

            }
        }
    }
}
