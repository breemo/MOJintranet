using MOJ.Entities;
using MOJ.Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Threading;

namespace MOJ.Intranet.Webparts.Home.MyRequests
{
    public partial class MyRequestsUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lbMyRequests.Text += "<div class='d-flex ordercontainer'>";
                List<MyRequestsEntity> Requestsollection = new MyRequestsB().GetMyRequests(6);
               
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                foreach (MyRequestsEntity item in Requestsollection)
                {
                    //MyRequestsEntity item = Requestsollection[cont];
                    string ServiceName = "";
                    string Status = "";
                    string classis="";
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
                    switch (item.StatusEn)
                    {
                        case "Approved":
                            classis = "btnstatusc2";
                            break;
                        case "Rejected":
                            classis = "btnstatusc1";
                            break;
                        default:
                            classis = "btnstatusc3";
                            break;
                    }
                    // lbMyRequests.Text += "<div class='col-sm-4'><div class='orderbox'><div class='topnot'><p>" + ServiceName + "</p></div><div class='botonot'>< a href = '#' class='btnstatus "+ classis + "'> " + Status + " </a></div></div></div>";

                    lbMyRequests.Text += @"<div class='col-sm-4'><div class='orderbox'><div class='topnot'>
					 <p>" + ServiceName + @"</p></div><div class='botonot'>
					  <a href = 'ar/MyServices/Pages/" + item.RequestURL + @"' class='btnstatus " + classis + @"'> " + Status + @" </a></div></div></div>";



                }
                lbMyRequests.Text += "</div>";

            }

        }
    }
}
