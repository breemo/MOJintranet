using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SharePoint;
using MOJ.Entities;
using SP.Common;

namespace MOJ.DataManager
{
    public class NewsDataManager
    {

        # region Announcement
        public List<NewsEntity> GetNewsData()
        {
            List<NewsEntity> newsLst = new List<NewsEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            if (oWeb != null)
                            {
                                SPList lstNews = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.NewsListUrl);
                                if (lstNews != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.NewsQuery;
                                    oQuery.ViewFields = SharedConstants.NewsViewfields;

                                    oQuery.RowLimit = 2;

                                    SPListItemCollection lstItems = lstNews.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        NewsEntity news = new NewsEntity();
                                        news.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        news.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                        news.Body = Convert.ToString(lstItem[SharedConstants.Description]);
                                        news.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        news.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                        
                                        try
                                        {news.Picture = oWeb.Url + "/" + lstItem.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[lstItem.ID.ToString()].Files[0].Url;}
                                        catch { news.Picture = "../../../_layouts/YSA.SP.Portal/en/images/No-attachment-1.png"; }

                                        newsLst.Add(news);
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
            return newsLst;
        }

        public NewsEntity GetNewsDataByID(int id)
        {
            NewsEntity news = new NewsEntity();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            if (oWeb != null)
                            {
                                SPList lstNews = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.NewsListUrl);
                                if (lstNews != null)
                                {
                                    SPListItem NewsItem = lstNews.GetItemById(id);

                                    news.ID = Convert.ToInt16(NewsItem[SharedConstants.ID]);
                                    news.Title = Convert.ToString(NewsItem[SharedConstants.Title]);
                                    news.Body = Convert.ToString(NewsItem[SharedConstants.Description]);
                                    news.Created = Convert.ToDateTime(NewsItem[SharedConstants.Created]);
                                    news.Date = Convert.ToDateTime(NewsItem[SharedConstants.Date]);
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
            return news;
        }
        # endregion
    }
}
