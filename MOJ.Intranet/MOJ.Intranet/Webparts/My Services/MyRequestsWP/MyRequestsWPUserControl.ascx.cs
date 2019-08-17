using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
                
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();

                for (int cont= Requestsollection.Count-1; cont >= 0; cont--)
                  
                {
                   MyRequestsEntity item = Requestsollection[cont];
                        string ServiceName="";
                    string Status="";
                         if (languageCode == "ar")
                    {
                         ServiceName = item.ServiceNameAr;
                         Status = item.StatusAr;
                    }
                    else
                    {

                        ServiceName = item.ServiceNameEn;
                        Status = item.StatusEn;
                    }
                    lbMyRequests.Text += @"<tr>
                   <td>" + i + @"</td>
                    <td><a href='" + item.RequestURL + @"'>" + item.RequestNumber + @"</a></td>
                    <td>" + ServiceName + @"</td>                    
                    <td>" + Status + @"</td>                    
                    <td>" + item.Created.ToString("dd MMM yyyy hh:mm tt") + @"</td>                                        
                    <td><a href='" + item.RequestURL + @"'><span class='icon-edit'> </span></a></td>
                    </tr>";
                    i++;

                }

            }
        }
    }
}
