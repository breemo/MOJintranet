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
                        if (Item.TravelCountry != "0") { 
                            item["TravelCountry"] = Item.TravelCountry;
                        }
                        else
                        {
                            item["TravelCountry"] = "";
                        }
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




        public CertificateToWhomItMayConcernEntity GetByID(int id)
        {
            CertificateToWhomItMayConcernEntity obitem = new CertificateToWhomItMayConcernEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CertificateToWhomItMayConcernUrl);
                                if (lst != null)
                                {
                                   
                                   

                                    SPListItem Item = lst.GetItemById(id);
                                    obitem.Title = Convert.ToString(Item["Title"]);
                                    obitem.ResponseMsgAR = Convert.ToString(Item["ResponseMsgAR"]);
                                    obitem.ResponseMsg = Convert.ToString(Item["ResponseMsg"]);
                                    if (Item["OrganizationType"] != null)
                                    {
                                        SPFieldLookupValue fieldLookupValue = new SPFieldLookupValue(Item["OrganizationType"].ToString());
                                        obitem.OrganizationType = Convert.ToString(fieldLookupValue.LookupId);

                                    }
                                    if (Item["RequestType"]!=null)
                                    {
                                        SPFieldLookupValue fieldLookupValue2 = new SPFieldLookupValue(Item["RequestType"].ToString());

                                        obitem.RequestType = Convert.ToString(fieldLookupValue2.LookupId);
                                    }
                                    if (Item["SpeechLanguage"] != null)
                                    {
                                        SPFieldLookupValue fieldLookupValue3 = new SPFieldLookupValue(Item["SpeechLanguage"].ToString());

                                        obitem.SpeechLanguage = Convert.ToString(fieldLookupValue3.LookupId);
                                    }
                                    if (Item["SpeechType"] != null)
                                    {
                                        SPFieldLookupValue fieldLookupValue4 = new SPFieldLookupValue(Item["SpeechType"].ToString());

                                        obitem.SpeechType = Convert.ToString(fieldLookupValue4.LookupId);
                                    }
                                    if (Item["TravelCountry"] != null)
                                    {

                                        SPFieldLookupValue fieldLookupValue5 = new SPFieldLookupValue(Item["TravelCountry"].ToString());

                                        obitem.TravelCountry = Convert.ToString(fieldLookupValue5.LookupId);

                                    }
                                    obitem.TheSpeechDirectedTo = Convert.ToString(Item["TheSpeechDirectedTo"]);
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
