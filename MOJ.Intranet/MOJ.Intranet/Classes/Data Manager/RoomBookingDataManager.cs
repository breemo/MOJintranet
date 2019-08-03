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

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
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
                            item["DateFrom"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(HostingRequestItem.DateFrom);
                            item["DateTo"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(HostingRequestItem.DateTo);
                            item["Department"] = HostingRequestItem.Department;
                            item["Mission"] = HostingRequestItem.Mission;
                            item["Place"] = HostingRequestItem.Place;
                            item["ResourcesNeeded"] = HostingRequestItem.ResourcesNeeded;
                            item["Created By"] = currentUser;

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
            });
            return isFormSaved;
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
