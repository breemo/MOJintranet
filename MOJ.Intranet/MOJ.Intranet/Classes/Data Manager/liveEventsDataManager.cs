using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MOJ.Entities;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Text.RegularExpressions;

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

                                        string refs= Convert.ToString(lstItem["VideoSetEmbedCode"]);
                                        var regex = new Regex("<iframe [^>]*src=(?:'(?<src>.*?)')|(?:\"(?<src>.*?)\")", RegexOptions.IgnoreCase);
                                        var urls = regex.Matches(refs).OfType<Match>().Select(m => m.Groups["src"].Value).SingleOrDefault();
                                        string videoId = urls.Split('/')[urls.Split('/').Length - 1];

                                        //liveVideo.VideoThumbnailURL = Convert.ToString(lstItem["AlternateThumbnailUrl"]);
                                        liveVideo.VideoThumbnailURL = videoId;
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

        public List<liveEventsEntity> GetCurrentMonthLiveVideosItems()
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
                                    DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                    String stringQuery =
                                    String.Format(@"<And>
                                                      <Geq>
                                                       <FieldRef Name='Date' />
                                                       <Value Type='DateTime'>{0}</Value>
                                                     </Geq>
                                                     <Leq>
                                                      <FieldRef Name='Date' />
                                                      <Value Type='DateTime'>{1}</Value>
                                                     </Leq>
                                                    </And>",
                                                    SPUtility.CreateISO8601DateTimeFromSystemDateTime(firstDay),
                                                    SPUtility.CreateISO8601DateTimeFromSystemDateTime(firstDay.AddMonths(1)));



                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = stringQuery;
                                    //oQuery.RowLimit = 1;

                                    SPListItemCollection lstItems = lstVideos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        liveEventsEntity liveVideo = new liveEventsEntity();
                                        liveVideo.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        liveVideo.Name = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colName", "Resource", SPContext.Current.Web.Language)]);
                                        liveVideo.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colLiveDescription", "Resource", SPContext.Current.Web.Language)]);
                                        liveVideo.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);

                                        string refs = Convert.ToString(lstItem["VideoSetEmbedCode"]);
                                        var regex = new Regex("<iframe [^>]*src=(?:'(?<src>.*?)')|(?:\"(?<src>.*?)\")", RegexOptions.IgnoreCase);
                                        var urls = regex.Matches(refs).OfType<Match>().Select(m => m.Groups["src"].Value).SingleOrDefault();
                                        string videoId = urls.Split('/')[urls.Split('/').Length - 1];

                                        //liveVideo.VideoThumbnailURL = Convert.ToString(lstItem["AlternateThumbnailUrl"]);
                                        liveVideo.VideoThumbnailURL = videoId;
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
        public List<liveEventsEntity> GetArchiveLiveVideosItems()
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
                                    DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                    String stringQuery =
                                    String.Format(@"<And>
                                                      <Geq>
                                                       <FieldRef Name='Date' />
                                                       <Value Type='DateTime'>{0}</Value>
                                                     </Geq>
                                                     <Leq>
                                                      <FieldRef Name='Date' />
                                                      <Value Type='DateTime'>{1}</Value>
                                                     </Leq>
                                                    </And>",
                                                    SPUtility.CreateISO8601DateTimeFromSystemDateTime(firstDay),
                                                    SPUtility.CreateISO8601DateTimeFromSystemDateTime(firstDay.AddMonths(1)));



                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = stringQuery;
                                    //oQuery.RowLimit = 1;

                                    SPListItemCollection lstItems = lstVideos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        liveEventsEntity liveVideo = new liveEventsEntity();
                                        liveVideo.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        liveVideo.Name = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colName", "Resource", SPContext.Current.Web.Language)]);
                                        liveVideo.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colLiveDescription", "Resource", SPContext.Current.Web.Language)]);
                                        liveVideo.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);

                                        string refs = Convert.ToString(lstItem["VideoSetEmbedCode"]);
                                        var regex = new Regex("<iframe [^>]*src=(?:'(?<src>.*?)')|(?:\"(?<src>.*?)\")", RegexOptions.IgnoreCase);
                                        var urls = regex.Matches(refs).OfType<Match>().Select(m => m.Groups["src"].Value).SingleOrDefault();
                                        string videoId = urls.Split('/')[urls.Split('/').Length - 1];

                                        //liveVideo.VideoThumbnailURL = Convert.ToString(lstItem["AlternateThumbnailUrl"]);
                                        liveVideo.VideoThumbnailURL = videoId;
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
