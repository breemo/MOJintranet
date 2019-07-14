using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;

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
                                        occasions.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                        occasions.Description = Convert.ToString(lstItem[SharedConstants.Description]);
                                        occasions.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        occasions.TitleEn = Convert.ToString(lstItem[SharedConstants.Title_En]);
                                        occasions.DescriptionEn = Convert.ToString(lstItem[SharedConstants.DescriptionEn]);

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
                                        occasions.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                        occasions.Description = Convert.ToString(lstItem[SharedConstants.Description]);
                                        occasions.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        occasions.TitleEn = Convert.ToString(lstItem[SharedConstants.Title_En]);
                                        occasions.DescriptionEn = Convert.ToString(lstItem[SharedConstants.DescriptionEn]);

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
                                    OccasionItem.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                    OccasionItem.Description = Convert.ToString(lstItem[SharedConstants.Description]);
                                    OccasionItem.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                    OccasionItem.TitleEn = Convert.ToString(lstItem[SharedConstants.Title_En]);
                                    OccasionItem.DescriptionEn = Convert.ToString(lstItem[SharedConstants.DescriptionEn]);
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
        # endregion
    }
}
