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
    public class  PeriodicalFormForGovernmentHousingDataManager
    {
       
        public bool AddOrUpdate(PeriodicalFormForGovernmentHousingEntity Item)
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
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.PeriodicalFormForGovernmentHousingUrl);
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
                        
                            item["ContractNumber"] = Item.ContractNumber;
                            item["ApartmentNumber"] = Item.ApartmentNumber;
                            item["Owner"] = Item.Owner;
                            item["NumberOfRooms"] = Item.NumberOfRooms;                            
                            item["ACtype"] = Item.ACtype;                            
                            item["LeasingContractEndDate"] = Item.LeasingContractEndDate;                            
                            item["Mobile"] = Item.Mobile;
                            item["HusbandORWife"] = Item.HusbandORWife;
                            item["HomePhone"] = Item.HomePhone;                            
                            item["WorkPhone"] = Item.WorkPhone;                            
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


            public PeriodicalFormForGovernmentHousingEntity GetByID(int id)
        {
            PeriodicalFormForGovernmentHousingEntity obitem = new PeriodicalFormForGovernmentHousingEntity();
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
                                SPList lstRoom = oWeb.GetListFromUrl(oSite.Url + SharedConstants.PeriodicalFormForGovernmentHousingUrl);
                                if (lstRoom != null)
                                {
                                    SPListItem Item = lstRoom.GetItemById(id);
                                   obitem.HusbandORWife = Convert.ToString(Item["HusbandORWife"]);
                                   obitem.ContractNumber = Convert.ToString(Item["ContractNumber"]);
                                   obitem.ApartmentNumber = Convert.ToString(Item["ApartmentNumber"]);
                                   obitem.Owner = Convert.ToString(Item["Owner"]);
                                   obitem.NumberOfRooms = Convert.ToString(Item["NumberOfRooms"]);
                                   obitem.ACtype = Convert.ToString(Item["ACtype"]);
                                   obitem.LeasingContractEndDate = Convert.ToString(Item["LeasingContractEndDate"]);
                                   obitem.Mobile = Convert.ToString(Item["Mobile"]);
                                   obitem.HomePhone = Convert.ToString(Item["HomePhone"]);
                                   obitem.WorkPhone = Convert.ToString(Item["WorkPhone"]);                                    
                                   obitem.RequestNumber = Convert.ToString(Item["Title"]);
                                   obitem.Status = Convert.ToString(Item["Status"]);
                                    obitem.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["Author"]));
                                    obitem.Created = Convert.ToDateTime(Item["Created"]);
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
