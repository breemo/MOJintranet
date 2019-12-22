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


        public List<EmploymentHistoryEntity> GeteEmploymentHistory(string title)
        {
            List<EmploymentHistoryEntity> ItemsCollection = new List<EmploymentHistoryEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.EmploymentHistoryUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    EmploymentHistoryEntity itemis = new EmploymentHistoryEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.OrganizationalUnit = Convert.ToString(Item["OrganizationalUnit"]);
                                    itemis.DateFrom = Convert.ToDateTime(Item["DateFrom"]);
                                    itemis.DateTo = Convert.ToDateTime(Item["DateTo"]);                                    
                                    itemis.PID = Convert.ToInt32(Item["PID"]);                                    
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }


        public ImplicitKnowledgeEntity GetImplicitKnowledge(string title)
        {
            ImplicitKnowledgeEntity itemis = new ImplicitKnowledgeEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {                
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ImplicitKnowledgeUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='UserName'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {                                   
                                    itemis.DateOfBirth = Convert.ToString(Item["DateOfBirth"]);
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.EmployeeNumber = Convert.ToString(Item["EmployeeNumber"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.MaritalStatus = Convert.ToString(Item["MaritalStatus"]);
                                    itemis.Name = Convert.ToString(Item["Title"]);
                                    itemis.Nationality = Convert.ToString(Item["Nationality"]);
                                    itemis.UserName = Convert.ToString(Item["UserName"]);
                                   
                                }

                            }
                        }

                    }
                }
            });
            return itemis;
        }


        public bool DeleteEmploymentHistory(List<int> listintID)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.EmploymentHistoryUrl);
                            if (lst != null)
                            {
                                foreach (int listItemId in listintID)
                                {
                                    oWeb.AllowUnsafeUpdates = true;
                                    // Delete List item
                                    SPListItem itemToDelete = lst.GetItemById(listItemId);
                                    itemToDelete.Delete();
                                    lst.Update();
                                    oWeb.AllowUnsafeUpdates = false;
                                }

                            }
                        }

                    }
                }
            });
            return true;
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
