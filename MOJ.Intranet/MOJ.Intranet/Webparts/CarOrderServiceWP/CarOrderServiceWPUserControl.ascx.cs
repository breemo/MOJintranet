using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Business;
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.CarOrderServiceWP
{
    public partial class CarOrderServiceWPUserControl : UserControl
    {
        private static int _CarNumber = 000001;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public static string GetNextCarRequestNumber()
        {
            _CarNumber++;
            return _CarNumber.ToString();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb myweb = mySitesCollection.OpenWeb())
                    {
                        SPUser currentUser = myweb.CurrentUser;

                        string RecordPrfix = "";
                        RecordPrfix = "Car-" + DateTime.Now.ToString("yyMMdd") + "-" + GetNextCarRequestNumber().PadLeft(5, '0').ToString();
                        string TravelNeedsValues = string.Empty;
                        string tPassengerNames = string.Empty;
                        foreach (ListItem item in this.cbTravelNeeds.Items)
                            if (item.Selected)
                                TravelNeedsValues += item + ",";

                        DateTime TravelDate = DateTime.ParseExact(txtTravelDate.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                        if (hdnPassenger.Value != "")
                            tPassengerNames += String.Format("{0}", Request.Form["Passenger"] + ",");

                        tPassengerNames += txtPassengerName0.Value;

                        bool AddCarRequest = new CarOrderServiceBL().AddCarOrderServic(currentUser,RecordPrfix, TravelNeedsValues, txtTravelTo.Value,
                            tPassengerNames, txtTravelReson.Value, txtCarPlace.Value, TravelDate, txtduration.Value);

                        if (AddCarRequest == true)
                        {
                            lblSuccessMsg.Text = @"تم ارسال طلبك بنجاح" + Environment.NewLine + "رقم طلبك هو" + Environment.NewLine + RecordPrfix;
                            posts.Style.Add("display", "none");
                            SuccessMsgDiv.Style.Add("display", "block");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
