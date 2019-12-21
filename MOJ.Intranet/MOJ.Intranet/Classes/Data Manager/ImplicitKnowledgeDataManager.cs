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
using MOJ.Entities.ImplicitKnowledge;

namespace MOJ.DataManager
{
    public class ImplicitKnowledgeDataManager
    {
        public int AddOrUpdateRequest(ImplicitKnowledgeEntity RequestItem)
        {
            int PID = 0;
                using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        try
                        {
                            SPUser currentUser = web.CurrentUser;
                            web.AllowUnsafeUpdates = true;
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.ImplicitKnowledgeUrl);
                            SPListItem item = null;
                            if (RequestItem.ID > 0)
                            {
                                item = list.GetItemById(RequestItem.ID);
                            PID = RequestItem.ID;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                             item["Title"] = RequestItem.Name;
                            item["EmployeeNumber"] = RequestItem.EmployeeNumber;
                            item["DateOfBirth"] = RequestItem.DateOfBirth;
                            item["Designation"] = RequestItem.Designation;                            
                            item["MaritalStatus"] = RequestItem.MaritalStatus;
                            item["Nationality"] = RequestItem.Nationality;
                            item["UserName"] = RequestItem.UserName;
                            item.Update();
                        PID = item.ID;
                    }
                        catch (Exception ex)
                        {
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
            return PID;
        }
        //AddOrUpdateEmploymentHistory


        public bool AddOrUpdateEmploymentHistory(List<EmploymentHistoryEntity> Items)
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
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.EmploymentHistoryUrl);
                        SPListItem item = null;
                        foreach (EmploymentHistoryEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["Designation"] = Item.Designation;
                            item["OrganizationalUnit"] = Item.OrganizationalUnit;
                            item["DateFrom"] = Item.DateFrom;
                            item["DateTo"] = Item.DateTo;
                            item["PID"] = Item.PID;
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
