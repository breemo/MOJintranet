using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.HostingRequestWP
{
    public partial class HostingRequestWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: fill 

            //1. ddl (

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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.DepartmentsUrl);
                                if (lst != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    //oQuery.Query = SharedConstants.NewsQuery;
                                    //oQuery.ViewFields = SharedConstants.NewsViewfields;

                                    SPListItemCollection lstItems = lst.GetItems(oQuery);

                                    //MatGrp.DataSource = lstItems;
                                    //MatGrp.DataValueField = "ID"; // List field holding value - first column is called Title anyway!  
                                    //MatGrp.DataTextField = "Title"; // List field holding name to be displayed on page   
                                    //MatGrp.DataBind();

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

        protected void btnSaveRoomBooking_Click(object sender, EventArgs e)
        {
            RoomBookingEntity itemSumbit = new RoomBookingEntity();

            //itemSumbit.AttendeesNumber = ;
            //itemSumbit.DateForm = ;
            //itemSumbit.DateTo = ;
            //itemSumbit.Department = ;
            //itemSumbit.Mission = ;
            //itemSumbit.Place = ;
            //itemSumbit.ResourcesNeeded = ;
            itemSumbit.Status = "Submitted";

            RoomBooking rb = new RoomBooking();
            bool isSaved = rb.SaveUpdate(itemSumbit);
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
