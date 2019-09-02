using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;

namespace MOJ.DataManager
{
    public class RoomBookingDataManager
    {
        #region HostingRequest
        public bool AddOrUpdateHostingRequest(RoomBookingEntity HostingRequestItem)
        {
            bool isFormSaved = false;
            bool isUpdate = false;

            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
                using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        try
                        {
                            SPUser currentUser = web.CurrentUser;

                            web.AllowUnsafeUpdates = true;
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.RoomBookingUrl);
                            SPListItem item = null;

                            if (HostingRequestItem.Id > 0)
                            {
                                item = list.GetItemById(HostingRequestItem.Id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }

                            item["AttendeesNumber"] = HostingRequestItem.AttendeesNumber;
                            item["DateFrom"] = Convert.ToDateTime(HostingRequestItem.DateFrom);
                            item["DateTo"] = Convert.ToDateTime(HostingRequestItem.DateTo);
                            item["Department"] = HostingRequestItem.Department;
                            item["Mission"] = HostingRequestItem.Mission;
                            item["Place"] = HostingRequestItem.Place;
                            item["ResourcesNeeded"] = HostingRequestItem.ResourcesNeeded;
                            //item["Created By"] = SPContext.Current.Web.CurrentUser;
                            //item["Modified By"] = SPContext.Current.Web.CurrentUser;
                            item["Title"] = HostingRequestItem.RequestNumber;

                            item.Update();

                            //AddAttendees(HostingRequestItem, isUpdate, web);

                            list.Update();
                            isFormSaved = true;
                        }
                        catch (Exception ex)
                        {
                            isFormSaved = false;
                            LoggingService.LogError("WebParts", ex.Message);
                            throw ex;
                        }
                        finally
                        {
                            web.AllowUnsafeUpdates = false;
                        }
                    }
                }
            //});
            return isFormSaved;
        }
               
        public RoomBookingEntity GetRoomBookingByID(int id)
        {
            RoomBookingEntity RoomBooking = new RoomBookingEntity();
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
                                SPList lstRoom = oWeb.GetListFromUrl(oSite.Url + SharedConstants.RoomBookingUrl);
                                if (lstRoom != null)
                                {
                                    SPListItem Item = lstRoom.GetItemById(id);
                                    RoomBooking.RequestNumber = Convert.ToString(Item["Title"]);
                                    RoomBooking.Place = Convert.ToString(Item["Place"]);
                                    RoomBooking.AttendeesNumber = Convert.ToString(Item["AttendeesNumber"]);
                                    RoomBooking.Mission = Convert.ToString(Item["Mission"]);
                                    RoomBooking.Status = Convert.ToString(Item["Status"]);
                                    RoomBooking.DateFrom = Convert.ToDateTime(Item["DateFrom"]);
                                    RoomBooking.DateTo = Convert.ToDateTime(Item["DateTo"]);
                                    RoomBooking.ResourcesNeeded = new SPFieldMultiChoiceValue(Item["ResourcesNeeded"].ToString());
                                    RoomBooking.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["Author"]));
                                    RoomBooking.Created = Convert.ToDateTime(Item["Created"]);
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
            return RoomBooking;
        }

        //public void AddAttendees(RoomBookingEntity HostingRequestItem, bool isUpdate, SPWeb web)
        //{
        //    //SPList formFAuditTeam = web.Lists[ListTitles.FormFAuditTeam];
        //    //SPList formFComponents = web.Lists[ListTitles.FormFComponents];
        //    SPList list = web.GetListFromUrl(web.Url + SharedConstants.HostingRequestUrl);

        //    if (isUpdate)
        //    {
        //        if (formFAuditTeam != null)
        //        {
        //            List<Guid> result = (from SPListItem item in formFAuditTeam.Items
        //                                 where new SPFieldLookupValue(Convert.ToString(item["FormFID"])).LookupId.Equals(formF.Id)
        //                                 select item.UniqueId).ToList();

        //            foreach (Guid deleteItemId in result)
        //                formFAuditTeam.GetItemByUniqueId(deleteItemId).Delete();

        //            formFAuditTeam.Update();
        //        }

        //        if (formFComponents != null)
        //        {
        //            List<Guid> result = (from SPListItem item in formFComponents.Items
        //                                 where new SPFieldLookupValue(Convert.ToString(item["FormFID"])).LookupId.Equals(formF.Id)
        //                                 select item.UniqueId).ToList();

        //            foreach (Guid deleteItemId in result)
        //                formFComponents.GetItemByUniqueId(deleteItemId).Delete();

        //            formFComponents.Update();
        //        }
        //    }

        //    foreach (AuditMember member in formF.AuditTeam)
        //    {
        //        SPListItem teamItem = formFAuditTeam.AddItem();
        //        teamItem["Title"] = member.MemberName;
        //        teamItem["RegistrationNumber"] = member.MemberRegNo; //formF.Id;                
        //        teamItem["FormFID"] = formF.Id + ";#" + formF.Id;
        //        teamItem.Update();
        //    }

        //    foreach (FormFComponent comp in formF.Components)
        //    {
        //        SPListItem component = formFComponents.AddItem();
        //        component["Major"] = comp.MajorCount;
        //        component["Minor"] = comp.MinorCount;
        //        component["ComponentID"] = comp.Id;
        //        component["FormFID"] = formF.Id + ";#" + formF.Id;
        //        component.Update();
        //    }

        //    isUpdateComplete = true;
        //    return isUpdateComplete;
        //}
        #endregion
    }
}
