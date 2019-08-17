using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.DataManager
{
    public class CarOrderServiceDataManager
    {
        public bool InsertCarOrderRequest(SPUser _CurrentUser, string _RequestNumber, string _TravelNeeds,
            string _TravelTo, string _NameOfPassengers, string _TravelReason, string _CarPlace, DateTime _TravelDate, string _Duration)
        {
            bool isInserted = false;
            List<CarOrderServiceEntity> CarOrder = new List<CarOrderServiceEntity>();

            try
            {
                //SPSecurity.RunWithElevatedPrivileges(delegate ()
                //{
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList oList = oWeb.Lists[SharedConstants.CarOrderServiceName];
                                if (oList != null)
                                {
                                    oWeb.AllowUnsafeUpdates = true;
                                    SPListItem oSPListItem = oList.Items.Add();
                                    oSPListItem["Title"] = Convert.ToString(_RequestNumber);
                                    oSPListItem["Travel Needs"] = Convert.ToString(_TravelNeeds);
                                    oSPListItem["Travel To"] = Convert.ToString(_TravelTo);
                                    oSPListItem["Travel Reason"] = Convert.ToString(_TravelReason);
                                    oSPListItem["Name Of Passengers"] = Convert.ToString(_NameOfPassengers);
                                    oSPListItem["Car Place"] = Convert.ToString(_CarPlace);
                                    oSPListItem["Travel Date"] = Convert.ToDateTime(_TravelDate);
                                    oSPListItem["Duration"] = Convert.ToString(_Duration);
                                    oSPListItem["Created By"] = _CurrentUser;
                                    oSPListItem.Update();
                                    isInserted = true;
                                    oWeb.AllowUnsafeUpdates = false;
                                }
                            }
                        }
                    }
                //});
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }

            return isInserted;
        }

        public CarOrderServiceEntity GetCarOrderServiceByID(int id)
        {
            CarOrderServiceEntity caritem = new CarOrderServiceEntity();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                    //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                    using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstcar = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CarOrderServiceUrl);
                                if (lstcar != null)
                                {
                                    SPListItem Item = lstcar.GetItemById(id);

                                    caritem.RequestNumber = Convert.ToString(Item["Title"]);
                                    caritem.ID = Convert.ToString(Item["ID"]);
                                    caritem.TravelNeeds = Convert.ToString(Item["Travel_x0020_Needs"]);
                                    caritem.TravelTo = Convert.ToString(Item["Travel_x0020_to"]);
                                    caritem.NameOfPassengers = Convert.ToString(Item["Name_x0020_Of_x0020_Passengers"]);
                                    caritem.TravelReason = Convert.ToString(Item["Travel_x0020_reason"]);
                                    caritem.CarPlace = Convert.ToString(Item["Car_x0020_Place"]);
                                    caritem.TravelDate = Convert.ToDateTime(Item["Travel_x0020_Date"]);
                                    caritem.Duration = Convert.ToString(Item["Duration"]);
                                    caritem.Status = Convert.ToString(Item["Status"]);
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
            return caritem;
        }
    }

}
