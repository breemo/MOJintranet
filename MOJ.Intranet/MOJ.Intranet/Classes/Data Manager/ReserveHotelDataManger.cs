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
    public class ReserveHotelDataManager
    {

        public bool AddOrUpdate(ReserveHotelEntity Item)
        {
            bool isFormSaved = false;
           
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ReserveHotelUrl);
                        SPListItem item = null;
                        if (Item.id > 0)
                        {
                            item = list.GetItemById(Item.id);
                            
                        }
                        else
                        {
                            item = list.AddItem();
                        }                   
                        item["Emirate"] = Item.EmirateID;
                        item["Title"] = Item.RequestNumber;
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


        public bool AddOrUpdateReserveHotelPeople(List<ReserveHotelPeopleEntity> Item)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ReserveHotelPeopleUrl);
                        SPListItem item = null;

                        foreach (ReserveHotelPeopleEntity Itemis in Item)
                        {
                            if (Itemis.id > 0)
                            {
                                item = list.GetItemById(Itemis.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }

                            item["Name"] = Itemis.Name;
                            item["Job"] = Itemis.Job;
                            if (!string.IsNullOrEmpty(Itemis.from))
                            {
                                DateTime ChangeDateV1 = DateTime.ParseExact(Itemis.from, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                item["from"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(ChangeDateV1);

                            }
                            if (!string.IsNullOrEmpty(Itemis.to))
                            {
                                DateTime ChangeDateV2 = DateTime.ParseExact(Itemis.to, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                item["to"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(ChangeDateV2);

                            }
                            item["Task"] = Itemis.Task;
                            item["Title"] = Itemis.RequestNumber;
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




        public ReserveHotelEntity GetByID(int id)
        {
            ReserveHotelEntity obitem = new ReserveHotelEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ReserveHotelUrl);
                                if (lst != null)
                                {
                                    SPListItem Item = lst.GetItemById(id);

                                    obitem.Status = Convert.ToString(Item["Status"]);
                                    string EmirateEn = Convert.ToString(Item["Emirate_x003a_Emirate"]);
                                    string EmirateAr = Convert.ToString(Item["Emirate_x003a_EmirateAr"]);


                                    if (!string.IsNullOrEmpty(EmirateEn)) { 
                                    SPFieldLookupValue SingleValue = new SPFieldLookupValue(EmirateEn);
                                        obitem.EmirateEn = SingleValue.LookupValue;
                                    }
                                    if (!string.IsNullOrEmpty(EmirateAr))
                                    {
                                        SPFieldLookupValue SingleValueAr = new SPFieldLookupValue(EmirateAr);
                                        obitem.EmirateAr = SingleValueAr.LookupValue;
                                    }
                                    obitem.RequestNumber = Convert.ToString(Item["Title"]);
                                    obitem.Status = Convert.ToString(Item["Status"]);

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
            return obitem;
        }



        public List<ReserveHotelPeopleEntity> GetReserveHotelPeople(string title)
        {
            List<ReserveHotelPeopleEntity> ItemsCollection = new List<ReserveHotelPeopleEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ReserveHotelPeopleUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {

                                    ReserveHotelPeopleEntity itemis = new ReserveHotelPeopleEntity();
                                    itemis.RequestNumber = Convert.ToString(Item["Title"]);
                                    itemis.id = Convert.ToInt32(Item["ID"]);
                                    itemis.Name = Convert.ToString(Item["Name"]);
                                    itemis.Job = Convert.ToString(Item["Job"]);
                                    itemis.from = Convert.ToString(Convert.ToDateTime(Item["from"]));
                                    itemis.to = Convert.ToString(Convert.ToDateTime(Item["to"]));
                                    itemis.Task = Convert.ToString(Item["Task"]);                                   
                                   ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }




    }
}
