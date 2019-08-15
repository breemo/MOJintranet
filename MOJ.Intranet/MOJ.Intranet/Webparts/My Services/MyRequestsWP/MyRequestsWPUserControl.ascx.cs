using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.MyRequestsWP
{
    public partial class MyRequestsWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                List<MyRequestsEntity> Requestsollection = new MyRequests().GetMyRequests();
                int i = 1;
                lbMyRequests.Text += SPContext.Current.Web.Language;
                foreach (MyRequestsEntity item in Requestsollection)
                {

                    lbMyRequests.Text += @"<tr>
                   <td>" + i + @"</td>
                    <td><a href='" + item.RequestNumber + @"'>" + item.RequestNumber + @"</a></td>
                    <td>" + item.ServiceName + @"</td>                    
                    <td>" + item.StatusAr + @"</td>                    
                    <td>" + item.Created.ToString("dd MMM yyyy hh:mm tt") + @"</td>                                        
                    <td><a href='" + item.RequestNumber + @"'><span class='icon-edit'> </span></a></td>
                    </tr>";
                    i++;

                }

            }
        }
    }
}
