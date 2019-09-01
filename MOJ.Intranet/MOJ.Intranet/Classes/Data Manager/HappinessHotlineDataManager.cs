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
    public class HappinessHotlineDataManager
    {       
        public bool AddOrUpdateHappinessHotline(HappinessHotlineEntity HappinessHotlineItem)
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
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.HappinessHotlineUrl);
                            SPListItem item = null;
                            if (HappinessHotlineItem.id > 0)
                            {
                                item = list.GetItemById(HappinessHotlineItem.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }                     
                            item["ContactReason"] = HappinessHotlineItem.ContactReason;
                            item["Message"] = HappinessHotlineItem.Message;                            
                            item["Title"] = HappinessHotlineItem.RequestNumber;
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


        public HappinessHotlineEntity GetHappinessHotlineByID(int id)
        {
            HappinessHotlineEntity obitem = new HappinessHotlineEntity();
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
                                SPList lstRoom = oWeb.GetListFromUrl(oSite.Url + SharedConstants.HappinessHotlineUrl);
                                if (lstRoom != null)
                                {
                                    SPListItem Item = lstRoom.GetItemById(id);                                   
                                    obitem.ContactReason = Convert.ToString(Item["ContactReason"]);
                                    obitem.Message = Convert.ToString(Item["Message"]);
                                    obitem.RequestNumber = Convert.ToString(Item["Title"]);
                                    obitem.Status = Convert.ToString(Item["Status"]);
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
