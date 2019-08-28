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
    public class HusbandORWifeDataManager
    {
       
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
                            item["BasicSalary"] = RequestItem.BasicSalary;
                            item["LastEntryDate"] = RequestItem.LastEntryDate;
                            item["LastExitDate"] = RequestItem.LastExitDate;
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

        
          

        public List<HusbandORWifeEntity> GetHusbandORWife( string title)
        {
            List<HusbandORWifeEntity> ItemsCollection = new List<HusbandORWifeEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.HusbandORWifeUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>"+ title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    
                                   HusbandORWifeEntity itemis = new HusbandORWifeEntity();
                                    itemis.RequestNumber = Convert.ToString(Item["Title"]);
                                    itemis.id = Convert.ToInt32(Item["ID"]);
                                    itemis.Name = Convert.ToString(Item["Name"]);
                                    itemis.workSector = Convert.ToString(Item["workSector"]);
                                    itemis.HusbandORWife = Convert.ToString(Item["HusbandORWife"]);
                                    itemis.Employer = Convert.ToString(Item["Employer"]);
                                    itemis.BasicSalary = Convert.ToString(Item["BasicSalary"]);
                                    itemis.LastEntryDate = Convert.ToString(Item["LastEntryDate"]);
                                    itemis.LastExitDate = Convert.ToString(Item["LastExitDate"]);
                                    itemis.HiringDate = Convert.ToString(Convert.ToDateTime(Item["HiringDate"]));
                                    itemis.DateOfMarriage = Convert.ToString(Convert.ToDateTime(Item["DateOfMarriage"]));
                                    itemis.HasGovernmentHousingAllowance = Convert.ToBoolean(Item["HasGovernmentHousingAllowance"]);
                                    itemis.HasGovernmentHousingPercentageAllowance =Convert.ToBoolean(Item["HasGovernmentHousingPercentageAllowance"]);
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
