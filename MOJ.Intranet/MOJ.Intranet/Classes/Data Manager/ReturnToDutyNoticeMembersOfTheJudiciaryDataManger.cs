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
    public class ReturnToDutyNoticeMembersOfTheJudiciaryDataManager
    {

        public bool AddOrUpdate(ReturnToDutyNoticeMembersOfTheJudiciaryEntity Item)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ReturnToDutyNoticeMembersOfTheJudiciaryUrl);
                        SPListItem item = null;
                        if (Item.id > 0)
                        {
                            item = list.GetItemById(Item.id);
                            
                        }
                        else
                        {
                            item = list.AddItem();
                        }                   
                        item["Day"] = Item.DayID;
                        item["Date"] = Item.date;
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


      

        public ReturnToDutyNoticeMembersOfTheJudiciaryEntity GetByID(int id)
        {
            ReturnToDutyNoticeMembersOfTheJudiciaryEntity obitem = new ReturnToDutyNoticeMembersOfTheJudiciaryEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ReturnToDutyNoticeMembersOfTheJudiciaryUrl);
                                if (lst != null)
                                {
                                    SPListItem Item = lst.GetItemById(id);

                                    obitem.Status = Convert.ToString(Item["Status"]);
                                    string DayEn = Convert.ToString(Item["Day_x003a_Day"]);
                                    string DayAr = Convert.ToString(Item["Day_x003a_DayAr"]);


                                    if (!string.IsNullOrEmpty(DayEn)) { 
                                    SPFieldLookupValue SingleValue = new SPFieldLookupValue(DayEn);
                                        obitem.DayEn = SingleValue.LookupValue;
                                    }
                                    if (!string.IsNullOrEmpty(DayAr))
                                    {
                                        SPFieldLookupValue SingleValueAr = new SPFieldLookupValue(DayAr);
                                        obitem.DayAr = SingleValueAr.LookupValue;
                                    }
                                    obitem.date = Convert.ToDateTime(Item["Date"]);
                                    obitem.RequestNumber = Convert.ToString(Item["Title"]);
                                    obitem.Status = Convert.ToString(Item["Status"]);                                  
                                    obitem.CreatedBy  = new SPFieldUserValue(oWeb, Convert.ToString(Item["Author"]));

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
