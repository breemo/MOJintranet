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
        public bool InsertCarOrderRequest(string _RequestNumber, string _TravelNeeds,
            string _TravelTo, string _NameOfPassengers, string _TravelReason, string _CarPlace, DateTime _TravelDate, string _Duration)
        {
            bool isInserted = false;
            List<CarOrderServiceEntity> CarOrder = new List<CarOrderServiceEntity>();

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
                                    oSPListItem.Update();
                                    isInserted = true;
                                    oWeb.AllowUnsafeUpdates = false;
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

            return isInserted;
        }
    }
}
