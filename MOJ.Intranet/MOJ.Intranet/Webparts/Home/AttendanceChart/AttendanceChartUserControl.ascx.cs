using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.AttendanceChart
{
    public partial class AttendanceChartUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Chartimg.Src = SPUtility.GetLocalizedString("$Resources: AttendeesChartImage", "Resource", SPContext.Current.Web.Language);
            }
        }
    }
}
