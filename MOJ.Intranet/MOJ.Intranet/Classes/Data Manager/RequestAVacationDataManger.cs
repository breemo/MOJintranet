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
    public class RequestAVacationDataManager
    {

        public bool AddOrUpdate(RequestAVacationEntity Item)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.RequestAVacationUrl);
                        SPListItem item = null;
                        if (Item.ID > 0)
                        {
                            item = list.GetItemById(Item.ID);
                            
                        }
                        else
                        {
                            item = list.AddItem();
                        }                   
                        item["Title"] = Item.Title;
                        item["ResponseMsgAR"] = Item.ResponseMsgAR;
                        item["ResponseMsg"] = Item.ResponseMsg;
                        item["FromDate"] = Item.FromDate; 
                        item["ToDate"] = Item.ToDate; 
                        item["Comments"] = Item.Comments;
                        item["SubstituteEmployee"] = Item.SubstituteEmployee;
                        item["VacationType"] = Item.VacationType;
                        if(Item.fileName!=""&& Item.fileName != null)
                        {
                            SPAttachmentCollection attachments = item.Attachments;
                            attachments.Add(Item.fileName, Item.fileContents);
                        }
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


      

       



    }
}
