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
    public class SonsDataManager
    {
       
      
        public bool AddOrUpdateHostingChildren(List<SonsEntity> Items)
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

                        foreach (SonsEntity Item in Items)
                        {
                            if (Item.id > 0)
                            {
                                item = list.GetItemById(Item.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            
                            item["Name"] = Item.Name;
                            item["age"] = Item.age;
                            item["Gender"] = Item.Gender;                                                     
                            item["Title"] = Item.RequestNumber;

                            item["LastEntryDate"] = Item.LastEntryDate;
                            item["LastExitDate"] = Item.LastExitDate;
                            item["BasicSalary"] = Item.BasicSalary;
                            item["Career"] = Item.Career;
                            item["HousingAllowance"] = Item.HousingAllowance;
                           
                           
                            item.Update();
                        }
                       
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

        
      
            public List<SonsEntity> Getsons(string title)
        {
            List<SonsEntity> ItemsCollection = new List<SonsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.SonsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    SonsEntity itemis = new SonsEntity();
                                    itemis.RequestNumber = Convert.ToString(Item["Title"]);
                                    itemis.LastEntryDate = Convert.ToString(Item["LastEntryDate"]);
                                    itemis.LastExitDate = Convert.ToString(Item["LastExitDate"]);
                                    itemis.BasicSalary = Convert.ToString(Item["BasicSalary"]);
                                    itemis.Career = Convert.ToString(Item["Career"]);
                                    itemis.HousingAllowance = Convert.ToBoolean(Item["HousingAllowance"]);
                                    itemis.id = Convert.ToInt32(Item["ID"]);
                                    itemis.Name = Convert.ToString(Item["Name"]);
                                    itemis.Gender = Convert.ToString(Item["Gender"]);
                                    itemis.age = Convert.ToString(Item["age"]);
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
