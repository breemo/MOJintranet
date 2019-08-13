using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Globalization;

namespace MOJ.DataManager
{
    public class AffirmationSocialSituationDataManager
    {
        #region HostingRequest
        public bool AddOrUpdateHostingRequest(AffirmationSocialSituationEntity HostingRequestItem)
        {
            bool isFormSaved = false;          
            bool isUpdate=false;
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
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.AffirmationSocialSituationUrl);
                            SPListItem item = null;

                            if (HostingRequestItem.id > 0)
                            {
                                item = list.GetItemById(HostingRequestItem.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                        if (!string.IsNullOrEmpty(HostingRequestItem.ChangeDate))
                        {
                            DateTime ChangeDateV = DateTime.ParseExact(HostingRequestItem.ChangeDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            item["ChangeDate"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(ChangeDateV);

                        }
                        item["Name"] = HostingRequestItem.Name;
                            item["RelationshipType"] = HostingRequestItem.RelationshipType;
                            item["ChangeReason"] = HostingRequestItem.ChangeReason;
                            item["HusbandORWife"] = HostingRequestItem.HusbandORWife;                            
                            item["Title"] = HostingRequestItem.RequestNumber;
                            item.Update();
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


        public bool AddOrUpdateHostingChildren(List<SonsEntity> listHostingRequestItem)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.SonsUrl);
                        SPListItem item = null;

                        foreach (SonsEntity HostingRequestItem in listHostingRequestItem)
                        {
                            if (HostingRequestItem.id > 0)
                            {
                                item = list.GetItemById(HostingRequestItem.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            
                            item["Name"] = HostingRequestItem.Name;
                            item["age"] = HostingRequestItem.age;
                            item["Gender"] = HostingRequestItem.Gender;                                                     
                            item["Title"] = HostingRequestItem.RequestNumber;
                            item.Update();
                        }
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

        
             public bool AddOrUpdateHusbandORWife(List<HusbandORWifeEntity> listRequestItem)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.HusbandORWifeUrl);
                        SPListItem item = null;
                        foreach (HusbandORWifeEntity RequestItem in listRequestItem)
                        {
                            if (RequestItem.id > 0)
                            {
                                item = list.GetItemById(RequestItem.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Name"] = RequestItem.Name;
                            item["Title"] = RequestItem.RequestNumber;
                            item["workSector"] = RequestItem.workSector;
                            item["HusbandORWife"] = RequestItem.HusbandORWife;
                            item["Employer"] = RequestItem.Employer;
                            if (!string.IsNullOrEmpty(RequestItem.HiringDate))
                            {
                                DateTime ChangeDateV2 = DateTime.ParseExact(RequestItem.HiringDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                item["HiringDate"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(ChangeDateV2);

                            }
                            if (!string.IsNullOrEmpty(RequestItem.DateOfMarriage))
                            {
                                DateTime ChangeDateV3 = DateTime.ParseExact(RequestItem.DateOfMarriage, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                item["DateOfMarriage"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(ChangeDateV3);
                            }
                            item["HasGovernmentHousingAllowance"] = RequestItem.HasGovernmentHousingAllowance;
                            item["HasGovernmentHousingPercentageAllowance"] = RequestItem.HasGovernmentHousingPercentageAllowance;
                            item.Update();
                        }
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

        #endregion
    }
}
