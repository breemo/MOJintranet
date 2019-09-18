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
    public class GovernmentHousingDataManager
    {       
        public bool AddOrUpdate(GovernmentHousingEntity Item)
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
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.GovernmentHousingUrl);
                            SPListItem item = null;
                            if (Item.id > 0)
                            {
                                item = list.GetItemById(Item.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }                     
                            item["MobileNumber"] = Item.MobileNumber;
                            item["ApportionmentDate"] = Item.ApportionmentDate;                            
                            item["HomeAddress"] = Item.HomeAddress;                            
                            item["VilaApartmentNumber"] = Item.VilaApartmentNumber;                            
                            item["NumberOfRooms"] = Item.NumberOfRooms;                            
                            item["Owner"] = Item.Owner;                            
                            item["agent"] = Item.agent;                            
                            item["Title"] = Item.RequestNumber;
                            item.Update();
                          
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


        public GovernmentHousingEntity GetByID(int id)
        {
            GovernmentHousingEntity obitem = new GovernmentHousingEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.GovernmentHousingUrl);
                                if (lst != null)
                                {
                                    SPListItem Item = lst.GetItemById(id);                                   
                                   
                                    obitem.RequestNumber = Convert.ToString(Item["Title"]);
                                    obitem.Status = Convert.ToString(Item["Status"]);
                                    obitem.MobileNumber = Convert.ToString(Item["MobileNumber"]);
                                    obitem.ApportionmentDate = Convert.ToDateTime(Item["ApportionmentDate"]);
                                    obitem.HomeAddress = Convert.ToString(Item["HomeAddress"]);
                                    obitem.VilaApartmentNumber = Convert.ToString(Item["VilaApartmentNumber"]);
                                    obitem.NumberOfRooms = Convert.ToString(Item["NumberOfRooms"]);
                                    obitem.Owner = Convert.ToString(Item["Owner"]);
                                    obitem.agent = Convert.ToString(Item["agent"]);
                                    obitem.Created = Convert.ToDateTime(Item["Created"]);
                                    obitem.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["Author"]));


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



    }
}
