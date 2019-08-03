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
        private static int _RoomNumber = 000001;

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
        public static string GetNextRoomRequestNumber()
        {
            _RoomNumber++;
            return _RoomNumber.ToString();
        }

        protected void btnSaveRoomBooking_Click(object sender, EventArgs e)
        {
            string RecordPrfix = "";
            RecordPrfix = "Room-" + DateTime.Now.ToString("yyMMdd") + "-" + GetNextRoomRequestNumber().PadLeft(5, '0').ToString();

            RoomBookingEntity itemSumbit = new RoomBookingEntity();

            itemSumbit.AttendeesNumber = txtAttendeesNumber.Value;
            itemSumbit.Mission = txtMission.Value;
            itemSumbit.Place = cbPlace.SelectedValue;


            DateTime s = DateTime.ParseExact(txtBookingDateFrom.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            TimeSpan ts = TimeSpan.Parse(txtBookingTimeFrom.Value);
            s = s.Date + ts;

            //DateTime dtFrom = DateTime.ParseExact(txtBookingDateFrom.Value + "T" + txtBookingTimeFrom.Value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            //DateTime dtTo = DateTime.ParseExact(txtBookingDateTo.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            itemSumbit.DateFrom = DateTime.Now;
            itemSumbit.DateTo = DateTime.Now;
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
                lblSuccessMsg.Text = @"تم ارسال طلبك بنجاح" + Environment.NewLine + "رقم طلبك هو" + Environment.NewLine + RecordPrfix;
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
