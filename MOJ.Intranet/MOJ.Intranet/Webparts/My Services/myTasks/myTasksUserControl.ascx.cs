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





                List<TaskEntity> taskollection = new Task().GetMyTask();
                foreach (TaskEntity task in taskollection)
                {
                    
                    tasks.Text += @"<tr>
                   <td>" + task.RequestName + @"</td>
                    <td>" + task.Title + @"</td>
                    <td>" + task.Status + @"</td>
                    <td>" + task.WorkflowOutcome + @"</td>
                    <td>" + task.Created.ToString("dd MMM yyyy hh:mm tt") + @"</td>                                        
                    <td><a href='"+ task.RequestURL + @"'><span class='icon-edit'></span></a></td>
                </tr>";

                }

            }
        }
    }
}
