using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MOJ.Entities;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;

namespace MOJ.DataManager
{
    public class liveEventsDataManager
    {
        #region liveEvents
        public List<liveEventsEntity> GetLatestHomeliveVideosItems()
        {
            List<liveEventsEntity> liveEventsLst = new List<liveEventsEntity>();
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
                                SPList lstVideos = oWeb.Lists["liveEvents"];
                                if (lstVideos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.LiveEventsQuery;
                                    oQuery.RowLimit = 1;

                                    SPListItemCollection lstItems = lstVideos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        liveEventsEntity liveVideo = new liveEventsEntity();
                                        liveVideo.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        liveVideo.Name = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colName", "Resource", SPContext.Current.Web.Language)]);
                                        liveVideo.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colLiveDescription", "Resource", SPContext.Current.Web.Language)]);
                                        liveVideo.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        //liveVideo.VideoThumbnailURL = Convert.ToString(lstItem["Thumbnail URL"]);
                                        liveVideo.VideoThumbnailURL = Convert.ToString(lstItem["AlternateThumbnailUrl"]);
                                        //liveVideo.VideoThumbnailURL = Convert.ToString(lstItem["ThumbnailOnForm"]);

                                        liveVideo.VideoURL = Convert.ToString(lstItem["VideoSetEmbedCode"]);

                                        liveEventsLst.Add(liveVideo);
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
            return liveEventsLst;
        }

        # endregion
    }
}
