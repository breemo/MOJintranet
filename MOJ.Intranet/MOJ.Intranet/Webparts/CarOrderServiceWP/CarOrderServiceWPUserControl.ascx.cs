using CommonLibrary;
using MOJ.Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.CarOrderServiceWP
{
    public partial class CarOrderServiceWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string TravelNeedsValues = string.Empty;
                foreach (ListItem item in this.cbTravelNeeds.Items)
                    if (item.Selected)
                        TravelNeedsValues += item + ",";

               // DateTime TravelDate = Convert.ToDateTime(txtTravelDate.Value);
                DateTime dt = DateTime.Now;

                bool AddCarRequest = new CarOrderServiceBL().AddCarOrderServic("Car-310720190001", TravelNeedsValues, txtTravelTo.Value,
                    txtPassengerName.Value, txtTravelReson.Value, txtCarPlace.Value, dt, txtduration.Value);

                if (AddCarRequest == true)
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
