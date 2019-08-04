using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.HostingRequestWP
{
    public partial class HostingRequestWPUserControl : UserControl
    {
        //private static int _RoomNumber = 000001;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetPlaces();
                GetResources();
            }
        }

        private void GetPlaces()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.RoomBookingUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice PlaceChoice = (SPFieldChoice)lst.Fields["Place"];
                                    for (int i = 0; i < PlaceChoice.Choices.Count; i++)
                                    {
                                        cbPlace.Items.Add(PlaceChoice.Choices[i].ToString());
                                    }
                                }
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void GetResources()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.RoomBookingUrl);
                                if (lst != null)
                                {
                                    SPFieldMultiChoice ResourcesChoice = (SPFieldMultiChoice)lst.Fields["ResourcesNeeded"];
                                    for (int i = 0; i < ResourcesChoice.Choices.Count; i++)
                                    {
                                        cbResources.Items.Add(ResourcesChoice.Choices[i].ToString());
                                    }
                                }
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        //public static string GetNextRoomRequestNumber()
        //{
        //    _RoomNumber++;
        //    return _RoomNumber.ToString();
        //}

        protected void btnSaveRoomBooking_Click(object sender, EventArgs e)
        {
            string RecordPrfix = "";
            RecordPrfix = "Room-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("RoomBooking");
            RoomBookingEntity itemSumbit = new RoomBookingEntity();

            if (!string.IsNullOrEmpty(txtBookingDateFrom.Value))
            {
                DateTime sDate = DateTime.ParseExact(txtBookingDateFrom.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string[] pmSdate = txtBookingTimeFrom.Value.Split(' ');
                TimeSpan tsSdate = TimeSpan.Parse(pmSdate[0]);
                sDate = (pmSdate[1] == "PM") ? (sDate.Date + tsSdate).AddHours(12) : sDate.Date + tsSdate;
                itemSumbit.DateFrom = sDate;
            }

            if (!string.IsNullOrEmpty(txtBookingDateTo.Value))
            {
                DateTime tDate = DateTime.ParseExact(txtBookingDateTo.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string[] pmTdate = txtBookingTimeTo.Value.Split(' ');
                TimeSpan tsTdate = TimeSpan.Parse(pmTdate[0]);
                tDate = (pmTdate[1] == "PM") ? (tDate.Date + tsTdate).AddHours(12) : tDate.Date + tsTdate;
                itemSumbit.DateTo = tDate;
            }

            itemSumbit.AttendeesNumber = txtAttendeesNumber.Value;
            itemSumbit.Mission = txtMission.Value;
            itemSumbit.Place = cbPlace.SelectedValue;
            itemSumbit.Department = "1";

            SPFieldMultiChoiceValue multiValue = new SPFieldMultiChoiceValue();
            foreach (ListItem item in cbResources.Items)
            {
                if (item.Selected)
                    multiValue.Add(item.Value);
            }
            itemSumbit.ResourcesNeeded = multiValue;
            itemSumbit.Status = "Submitted";

            RoomBooking rb = new RoomBooking();
            bool isSaved = rb.SaveUpdate(itemSumbit);

            if (isSaved == true)
            {
                lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                posts.Style.Add("display", "none");
                SuccessMsgDiv.Style.Add("display", "block");
            }
        }

        protected void btnSaveHotelHostingRequest_Click(object sender, EventArgs e)
        {
            //fireach
            //{
            //HotelHostingEntity itemSumbit = new HotelHostingEntity();

            ////itemSumbit.AttendeesNumber = ;
            ////itemSumbit.DateForm = ;
            ////itemSumbit.DateTo = ;
            ////itemSumbit.Department = ;
            ////itemSumbit.Mission = ;
            ////itemSumbit.Place = ;
            ////itemSumbit.ResourcesNeeded = ;
            //itemSumbit.Status = "Submitted";

            //HotelHosting rb = new HotelHosting();
            //bool isSaved = rb.SaveUpdate(itemSumbit);
            //}
        }
    }
}
