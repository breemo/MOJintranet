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
    public class CouncilMembersDataManager
    {
        public bool AddOrUpdate(CouncilMembersEntity Item)
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
                        SPUser currentUser = web.CurrentUser;
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.CouncilMembersUrl);
                        SPListItem item = null;
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
                        item["CouncilTopic"] = Item.CouncilTopic;
                        item["knowledgeCouncilID"] = Item.knowledgeCouncilID;
                        item["loginName"] = Item.loginName;
                        item["UserName"] = Item.UserName;
                        item["Department"] = Item.Department;
                        if (!string.IsNullOrEmpty(Item.Status))
                        {
                            item["Status"] = Item.Status;
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
       public CouncilMembersEntity GetMemberID( int knowledgeCouncilID, string loginName)
        {
            CouncilMembersEntity items = new CouncilMembersEntity();
           items.ID = 0;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CouncilMembersUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><And>";                                
                                camlquery1 += "<Eq><FieldRef Name='knowledgeCouncilID'></FieldRef><Value Type='number'>" + knowledgeCouncilID + "</Value></Eq>";                                
                                    camlquery1 += "<Eq><FieldRef Name='loginName'/><Value Type='Text'>" + loginName + "</Value></Eq></And>";                                
                            camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    items.ID = Convert.ToInt32(Item["ID"]);                                  
                                    items.Status = Convert.ToString(Item["Status"]);                                  
                                    items.Title = Convert.ToString(Item["Title"]);                                  
                                    items.knowledgeCouncilID = Convert.ToInt32(Item["knowledgeCouncilID"]);                                  
                                    items.loginName = Convert.ToString(Item["loginName"]);                                  
                                   
                                }

                            }
                        }

                    }
                }
            });
            return items;
        }

        public CouncilMembersEntity GetCouncilMembersByID(int id)
        {
            CouncilMembersEntity obitem = new CouncilMembersEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CouncilMembersUrl);
                                if (lst != null)
                                {

                                    SPListItem item = lst.GetItemById(id);
                                    obitem.Title = Convert.ToString(item["Title"]);                                   
                                    obitem.CouncilTopic = Convert.ToString(item["CouncilTopic"]);                                   
                                    obitem.Department = Convert.ToString(item["Department"]);                                   
                                    obitem.Status = Convert.ToString(item["Status"]);
                                    obitem.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(item["Author"]));
                                    obitem.Created = Convert.ToDateTime(item["Created"]);
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
