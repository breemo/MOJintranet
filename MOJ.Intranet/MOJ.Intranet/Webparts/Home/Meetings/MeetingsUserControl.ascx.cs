using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.Meetings
{
    public partial class MeetingsUserControl : UserControl
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        BindData();
                    }
                }
                catch (Exception ex)
                {

                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }
        #endregion

        #region Methods
        private void BindData()
        {
            try
            {
                List<MeetingsEntity> MeetingsLst = new MeetingsBL().GetMeetings();
                lblDrawItems.Text = "";
                int Count = 0;
                foreach (MeetingsEntity item in MeetingsLst)
                {
                    Count++;
                    lblDrawItems.Text +=
                        string.Format(@"
                        <div class='mettingitem'>
                                <a href = '{0}' >{1}</a>
                            <p class='medate'>
                                <span class='icon-calendar-alt1'></span>
                                {2}
                            </p>
                            <p class='meclock'>
                                <span class='icon-time'></span>
                                {3}
                            </p>
                       </div>", "/Lists/Meetings/DispForm.aspx?ID=" + item.ID, item.Title, Convert.ToDateTime(item.StartTime).ToString("dd-MMM-yyyy"), Convert.ToDateTime(item.StartTime).ToString("HH:mm tt"));

                }
            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }

        }

        #endregion
    }
}
