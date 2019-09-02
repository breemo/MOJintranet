using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.wpOccasionsList
{
    public partial class wpOccasionsListUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillOccasionsList();
            }
        }
        public void FillOccasionsList()
        {
            try
            {
                List<OccasionsEntity> occasionsLst = new Occasions().GetAllOccasions();

                rptrOccasions.DataSource = occasionsLst;
                rptrOccasions.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
            }
        }
    }
}
