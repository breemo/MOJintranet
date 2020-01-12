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
    public class CertificateToWhomItMayConcernDataManager
    {

        public bool AddOrUpdate(CertificateToWhomItMayConcernEntity Item)
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
                       

                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.CertificateToWhomItMayConcernUrl);
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
                        item["OrganizationType"] = Item.OrganizationType;
                        item["RequestType"] = Item.RequestType;
                        item["SpeechLanguage"] = Item.SpeechLanguage;
                        item["SpeechType"] = Item.SpeechType;
                        item["TravelCountry"] = Item.TravelCountry;                       
                        item["TheSpeechDirectedTo"] = Item.TheSpeechDirectedTo;                       

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
