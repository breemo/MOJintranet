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
    public class AffirmationSocialSituationDataManager
    {
       
        public bool AddOrUpdateHostingRequest(AffirmationSocialSituationEntity HostingRequestItem)
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
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.AffirmationSocialSituationUrl);
                            SPListItem item = null;

                            if (HostingRequestItem.id > 0)
                            {
                                item = list.GetItemById(HostingRequestItem.id);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                        if (!string.IsNullOrEmpty(HostingRequestItem.ChangeDate))
                        {
                            DateTime ChangeDateV = DateTime.ParseExact(HostingRequestItem.ChangeDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            item["ChangeDate"] = SPUtility.CreateISO8601DateTimeFromSystemDateTime(ChangeDateV);

                        }
                        item["Name"] = HostingRequestItem.Name;
                            item["RelationshipType"] = HostingRequestItem.RelationshipType;
                            item["ChangeReason"] = HostingRequestItem.ChangeReason;
                            item["HusbandORWife"] = HostingRequestItem.HusbandORWife;                            
                            item["Title"] = HostingRequestItem.RequestNumber;
                         if(HostingRequestItem.fileName!=""&& HostingRequestItem.fileName != null)
                        {
                            SPAttachmentCollection attachments = item.Attachments;
                            attachments.Add(HostingRequestItem.fileName, HostingRequestItem.fileContents);
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


            public AffirmationSocialSituationEntity GetAffirmationSocialSituationByID(int id)
        {
            AffirmationSocialSituationEntity obitem = new AffirmationSocialSituationEntity();
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
                                SPList lstRoom = oWeb.GetListFromUrl(oSite.Url + SharedConstants.AffirmationSocialSituationUrl);
                                if (lstRoom != null)
                                {
                                    SPListItem Item = lstRoom.GetItemById(id);

                                 obitem.ChangeDate = Convert.ToDateTime(Item["ChangeDate"]).ToString();
                                    obitem.Name = Convert.ToString(Item["Name"]);
                                    obitem.RelationshipType = Convert.ToString(Item["RelationshipType"]);
                                    obitem.ChangeReason = Convert.ToString(Item["ChangeReason"]);
                                    obitem.HusbandORWife = Convert.ToString(Item["HusbandORWife"]);
                                    obitem.RequestNumber = Convert.ToString(Item["Title"]);
                                    obitem.Status = Convert.ToString(Item["Status"]);
                                    obitem.Created = Convert.ToDateTime(Item["Created"]);
                                    obitem.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["Author"]));
                                    obitem.AttachmentUrl = GetAttachmentUrls(Item);
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


        private string GetAttachmentUrls(SPListItem oItem)
        {

            string path = string.Empty;

            try

            {

                path = (from string file in oItem.Attachments
                        orderby file
                        select SPUrlUtility.CombineUrl(oItem.Attachments.UrlPrefix, file)).FirstOrDefault();
                return path;
            }
            catch
            {
                return string.Empty;
            }

        }

    }
}
