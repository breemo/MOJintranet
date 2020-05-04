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
    public class ReturnFromLeaveDataManager
    {

        public bool AddOrUpdate(ReturnFromLeaveEntity Item)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ReturnFromLeaveUrl);
                        SPListItem item = null;
                        if (Item.ID > 0)
                        {
                            item = list.GetItemById(Item.ID);
                            
                        }
                        else
                        {
                            item = list.AddItem();
                        }                   
                       
                        item["AbsenceID"] = Item.AbsenceID;
                        item["Description"] = Item.Description;
                        item["ReturnDateFromVacation"] = Item.ReturnDateFromVacation;
                        item["RreasonForTheDelay"] = Item.RreasonForTheDelay;
                        item["ResponseMsg"] = Item.ResponseMsg;
                        item["ResponseMsgAR"] = Item.ResponseMsgAR;
                      
                       
                        item["Title"] = Item.Title;
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


      


        public ReturnFromLeaveEntity GetByID(int id)
        {
            ReturnFromLeaveEntity obitem = new ReturnFromLeaveEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ReturnFromLeaveUrl);
                                if (lst != null)
                                {
                                    SPListItem Item = lst.GetItemById(id);                                                       
                                    obitem.Title = Convert.ToString(Item["Title"]);
                                    obitem.AbsenceID = Convert.ToString(Item["AbsenceID"]);
                                    obitem.Description = Convert.ToString(Item["Description"]);
                                    obitem.ReturnDateFromVacation = Convert.ToDateTime(Item["ReturnDateFromVacation"]);
                                    obitem.RreasonForTheDelay = Convert.ToString(Item["RreasonForTheDelay"]);
                                    obitem.ResponseMsg = Convert.ToString(Item["ResponseMsg"]);
                                    obitem.ResponseMsgAR = Convert.ToString(Item["ResponseMsgAR"]);
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




    }
}
