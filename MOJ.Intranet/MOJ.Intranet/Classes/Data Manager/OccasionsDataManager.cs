using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;

namespace MOJ.DataManager
{
    public class OccasionsDataManager
    {
        # region Memos
        public List<OccasionsEntity> GetOccasionsDataHome()
        {
            List<OccasionsEntity> memosLst = new List<OccasionsEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstOccasions = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.OccasionsListUrl);
                                if (lstOccasions != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.OccasionsQuery;
                                    oQuery.ViewFields = SharedConstants.OccasionsViewfields;

                                    oQuery.RowLimit = 3;

                                    SPListItemCollection lstItems = lstOccasions.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        OccasionsEntity occasions = new OccasionsEntity();
                                        occasions.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        occasions.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        occasions.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        occasions.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colDescription", "Resource", SPContext.Current.Web.Language)]);

                                        memosLst.Add(occasions);
                                    }
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
            return memosLst;
        }
        public List<OccasionsEntity> GetAllOccasionsData()
        {
            List<OccasionsEntity> memosLst = new List<OccasionsEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstOccasions = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.OccasionsListUrl);
                                if (lstOccasions != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.OccasionsQuery;
                                    oQuery.ViewFields = SharedConstants.OccasionsViewfields;

                                    SPListItemCollection lstItems = lstOccasions.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        OccasionsEntity occasions = new OccasionsEntity();
                                        occasions.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        occasions.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        occasions.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        occasions.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colDescription", "Resource", SPContext.Current.Web.Language)]);

                                        memosLst.Add(occasions);
                                    }
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
            return memosLst;
        }
        public OccasionsEntity GetOccasionByID(int id)
        {
            OccasionsEntity OccasionItem = new OccasionsEntity();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstOccasions = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.OccasionsListUrl);
                                if (lstOccasions != null)
                                {
                                    SPListItem lstItem = lstOccasions.GetItemById(id);

                                    OccasionItem.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                    OccasionItem.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                    OccasionItem.CreatedBy = Convert.ToString(lstItem["Author"]);
                                    OccasionItem.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                    OccasionItem.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colDescription", "Resource", SPContext.Current.Web.Language)]);
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
            return OccasionItem;
        }

        public bool Add(OccasionsEntity Item)
        {
            bool isFormSaved = false;
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        SPUser currentUser = web.CurrentUser;

                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.OccasionsListUrl);
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
                        item["TitleEn"] = Item.TitleEn;
                        item["Description"] = Item.Description;
                        item["DescriptionEn"] = Item.DescriptionEn;
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
            return isFormSaved;
        }
        # endregion
    }

    public class OccasionCommentsDataManager
    {
        public bool AddOrUpdate(OccasionCommentsEntity Item)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.OccasionCommentsListUrl);
                        SPListItem item = null;
                        if (Item.ID > 0)
                        {
                            item = list.GetItemById(Item.ID);
                        }
                        else
                        {
                            item = list.AddItem();
                        }
                        item["OccasionID"] = Item.OccasionID;
                        item["Description"] = Item.Description;
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

        public List<OccasionCommentsEntity> GetOccasionCommentsByOccasionID(int OccasionId)
        {
            List<OccasionCommentsEntity> OccasionCommentsItems = new List<OccasionCommentsEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstOccasionComments = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.OccasionCommentsListUrl);
                                if (lstOccasionComments != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = @"<Where>
                                                        <Eq>
	                                                        <FieldRef Name='OccasionID_x003a_ID' />
	                                                        <Value Type='Lookup'>" + OccasionId + @"</Value>
                                                        </Eq>
                                                    </Where><OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";

                                    SPListItemCollection lstItems = lstOccasionComments.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        OccasionCommentsEntity comments = new OccasionCommentsEntity();
                                        comments.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        comments.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        //comments.OccasionID = Convert.ToInt16(lstItem["OccasionID_x003a_ID"]);
                                        comments.Description = Convert.ToString(lstItem[SharedConstants.Description]);
                                        comments.CreatedBy = Convert.ToString(lstItem["Author"]);

                                        OccasionCommentsItems.Add(comments);
                                    }
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
            return OccasionCommentsItems;
        }
    }
}
