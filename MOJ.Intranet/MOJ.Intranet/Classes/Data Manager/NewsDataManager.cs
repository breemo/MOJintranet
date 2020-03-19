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
    public class NewsDataManager
    {
        #region News
        public List<NewsEntity> GetAllNewsData()
        {
            List<NewsEntity> newsLst = new List<NewsEntity>();
            try
            {
                //SPSecurity.RunWithElevatedPrivileges(delegate ()
                //{
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                //SPList lstNews = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.NewsListUrl);
                                SPList lstNews = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MemosListUrl);
                                if (lstNews != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    SPUser currentUser = oWeb.CurrentUser;

                                if (!string.IsNullOrEmpty(Methods.GetEmployeeDepartment(currentUser)))
                                {
                                    //string newsQuery = @"<Where>
                                    //                      <Contains>
                                    //                         <FieldRef Name='Department' />
                                    //                         <Value Type='LookupMulti'>" + Methods.GetEmployeeDepartment(currentUser) + @"</Value>
                                    //                      </Contains>
                                    //                   </Where>";

                                    string newsQuery = @"<Where>
                                                              <And>
                                                                 <Contains>
                                                                     <FieldRef Name='Department' />
                                                                     <Value Type='LookupMulti'>" + Methods.GetEmployeeDepartment(currentUser) + @"</Value>
                                                                 </Contains>
                                                                 <Eq>
                                                                    <FieldRef Name='NewsAppr' />
                                                                    <Value Type='WorkflowStatus'>16</Value>
                                                                 </Eq>
                                                              </And>
                                                           </Where>";

                                    oQuery.Query = newsQuery + SharedConstants.NewsQuery;
                                }
                                else
                                { oQuery.Query = SharedConstants.NewsQuery; }

                                    oQuery.ViewFields = SharedConstants.NewsViewfields;
                                    SPListItemCollection lstItems = lstNews.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        NewsEntity news = new NewsEntity();
                                        news.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        news.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        news.Body = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                        news.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        news.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        news.Picture = FileUrl;

                                        //try
                                        //{ news.Picture = oWeb.Url + "/" + lstItem.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[lstItem.ID.ToString()].Files[0].Url; }
                                        //catch
                                        //{
                                        //    news.Picture = SharedConstants.URL_NO_IMAGE;
                                        //    // "../../../_layouts/YSA.SP.Portal/en/images/No-attachment-1.png";
                                        //}

                                        newsLst.Add(news);
                                    }
                                }
                            }
                        }
                    }
                //});

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return newsLst;
        }
        public List<NewsEntity> GetLast4NewsData()
        {
            List<NewsEntity> newsLst = new List<NewsEntity>();
            try
            {
                //SPSecurity.RunWithElevatedPrivileges(delegate()
                //{

                    //using (SPSite oSite = new SPSite(web.Site.ID))
                    //{
                    //    using (SPWeb elevatedWeb = elevatedSite.RootWeb)

                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstNews = oWeb.GetListFromUrl(oSite.Url + SharedConstants.NewsListUrl);
                                if (lstNews != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    SPUser currentUser = oWeb.CurrentUser;

                                if (!string.IsNullOrEmpty(Methods.GetEmployeeDepartment(currentUser)))
                                {
                                    //string newsQuery = @"<Where>
                                    //                      <Contains>
                                    //                         <FieldRef Name='Department' />
                                    //                         <Value Type='LookupMulti'>" + Methods.GetEmployeeDepartment(currentUser) + @"</Value>
                                    //                      </Contains>
                                    //                   </Where>";

                                    string newsQuery = @"<Where>
                                                              <And>
                                                                 <Contains>
                                                                     <FieldRef Name='Department' />
                                                                     <Value Type='LookupMulti'>" + Methods.GetEmployeeDepartment(currentUser) + @"</Value>
                                                                 </Contains>
                                                                 <Eq>
                                                                    <FieldRef Name='NewsAppr' />
                                                                    <Value Type='WorkflowStatus'>16</Value>
                                                                 </Eq>
                                                              </And>
                                                           </Where>";

                                    oQuery.Query = newsQuery + SharedConstants.NewsQuery;
                                }
                                else
                                { oQuery.Query = SharedConstants.NewsQuery; }

                                    
                                    oQuery.ViewFields = SharedConstants.NewsViewfields;
                                    oQuery.RowLimit = 4;

                                    SPListItemCollection lstItems = lstNews.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        NewsEntity news = new NewsEntity();
                                        news.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        news.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        news.Body = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                        news.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        news.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        news.Picture = FileUrl;

                                        //try
                                        //{news.Picture = oWeb.Url + "/" + lstItem.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[lstItem.ID.ToString()].Files[0].Url;}
                                        //catch { news.Picture = SharedConstants.URL_NO_IMAGE;
                                        //    // "../../../_layouts/YSA.SP.Portal/en/images/No-attachment-1.png";
                                        //}

                                        newsLst.Add(news);
                                    }
                                }
                            }
                        }
                    }
                //});

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
                //SPSecurity.RunWithElevatedPrivileges(delegate()
                //{
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lstNews = oWeb.GetListFromUrl(oSite.Url + SharedConstants.NewsListUrl);
                            if (lstNews != null)
                            {
                                SPListItem NewsItem = lstNews.GetItemById(id);

                                news.ID = Convert.ToInt16(NewsItem[SharedConstants.ID]);
                                news.Title = Convert.ToString(NewsItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                news.Body = Convert.ToString(NewsItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                news.Created = Convert.ToDateTime(NewsItem[SharedConstants.Created]);
                                news.Date = Convert.ToDateTime(NewsItem[SharedConstants.Date]);

                                string FileUrl = Methods.ReturnAttachmentFile(oWeb, NewsItem);
                                news.Picture = FileUrl;

                                //try
                                //{ news.Picture = oWeb.Url + "/" + NewsItem.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[NewsItem.ID.ToString()].Files[0].Url; }
                                //catch
                                //{
                                //    news.Picture = SharedConstants.URL_NO_IMAGE;
                                //    // "../../../_layouts/YSA.SP.Portal/en/images/No-attachment-1.png";
                                //}
                            }
                        }
                    }
                }
                //}
            //);
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return news;
        }
        public List<NewsEntity> SrchNews(string srch)
        {
            List<NewsEntity> newsLst = new List<NewsEntity>();
            try
            {
                //SPSecurity.RunWithElevatedPrivileges(delegate ()
                //{
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstNews = oWeb.GetListFromUrl(oSite.Url + SharedConstants.NewsListUrl);
                                if (lstNews != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    SPUser currentUser = oWeb.CurrentUser;

                                    if (!string.IsNullOrEmpty(Methods.GetEmployeeDepartment(currentUser)))
                                    {
                                        string newsQuery = @"<Where>
                                                              <And>
                                                                 <Contains>
                                                                    <FieldRef Name='Department' />
                                                                    <Value Type='LookupMulti'>" + Methods.GetEmployeeDepartment(currentUser) + @"</Value>
                                                                 </Contains>
                                                                 <Contains>
                                                                    <FieldRef Name='Title' />
                                                                    <Value Type='Text'> " + srch + @"</Value>
                                                                 </Contains>
                                                              </And>
                                                        </Where>";

                                        oQuery.Query = newsQuery + SharedConstants.NewsQuery;
                                    }
                                    else
                                    { oQuery.Query = "<Where><Contains><FieldRef Name='Title' /><Value Type='Text'>" + srch + @"</Value></Contains></Where>" + SharedConstants.NewsQuery; }
                                    
                                    oQuery.ViewFields = SharedConstants.MemosViewfields;

                                    SPListItemCollection lstItems = lstNews.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        NewsEntity news = new NewsEntity();
                                        news.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        news.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        news.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                        news.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        news.Body = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        news.Picture = FileUrl;

                                        //try
                                        //{ news.Picture = oWeb.Url + "/" + lstItem.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[lstItem.ID.ToString()].Files[0].Url; }
                                        //catch
                                        //{
                                        //    news.Picture = SharedConstants.URL_NO_IMAGE;
                                        //}

                                        newsLst.Add(news);
                                    }
                                }
                            }
                        }
                    }
                //});
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return newsLst;
        }
        public List<NewsEntity> SrchNews(string year, string Smonth, string Emonth, string Sday, string Eday)
        {
            List<NewsEntity> newsLst = new List<NewsEntity>();
            try
            {
                //SPSecurity.RunWithElevatedPrivileges(delegate ()
                //{
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstNews = oWeb.GetListFromUrl(oSite.Url + SharedConstants.NewsListUrl);
                                if (lstNews != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    SPUser currentUser = oWeb.CurrentUser;

                                if (!string.IsNullOrEmpty(Methods.GetEmployeeDepartment(currentUser)))
                                {
                                    if (year != "0")
                                    {
                                        oQuery.Query = @"<Where>
                                          <And>
                                             <Contains>
                                                <FieldRef Name='Department' />
                                                <Value Type='LookupMulti'>" + Methods.GetEmployeeDepartment(currentUser) + @"</Value>
                                             </Contains>
                                             <And>
                                                <Geq>
                                                    <FieldRef Name='Created' />
                                                    <Value IncludeTimeValue='TRUE' Type='DateTime'>" + year + "-" + Smonth + "-" + Sday + @"-T12:00:00Z</Value>
                                                </Geq>
                                                <Leq>
                                                    <FieldRef Name='Created' />
                                                    <Value IncludeTimeValue='TRUE' Type='DateTime'>" + year + "-" + Emonth + "-" + Eday + @"-T12:00:00Z</Value>
                                                </Leq>
                                            </And>
                                          </And>
                                       </Where>";
                                    }
                                    else
                                    {
                                        oQuery.Query = @"<Where>
                                             <Contains>
                                                <FieldRef Name='Department' />
                                                <Value Type='LookupMulti'>" + Methods.GetEmployeeDepartment(currentUser) + @"</Value>
                                             </Contains>
                                       </Where>";
                                    }
                                }
                                else
                                {
                                    if (year != "0")
                                    {
                                        oQuery.Query = @" <Where>
                                                      <And>
                                                         <Geq>
                                                            <FieldRef Name='Created' />
                                                            <Value IncludeTimeValue='TRUE' Type='DateTime'>" + year + "-" + Smonth + "-" + Sday + @"-T12:00:00Z</Value>
                                                         </Geq>
                                                         <Leq>
                                                            <FieldRef Name='Created' />
                                                            <Value IncludeTimeValue='TRUE' Type='DateTime'>" + year + "-" + Emonth + "-" + Eday + @"-T12:00:00Z</Value>
                                                         </Leq>
                                                      </And>
                                                   </Where>";
                                    }
                                    else
                                    {
                                        oQuery.Query = "";
                                    }
                                }
                                    
                                    oQuery.ViewFields = SharedConstants.MemosViewfields;

                                    SPListItemCollection lstItems = lstNews.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        NewsEntity news = new NewsEntity();
                                        news.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        news.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        news.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                        news.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        news.Body = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        news.Picture = FileUrl;

                                        newsLst.Add(news);
                                    }
                                }
                            }
                        }
                    }
                //});
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return newsLst;
        }

        # endregion
    }
}
