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
    public class ServicesListManager
    {
        #region ServicesList
        public List<ServicesListEntity> GetAllActiveServicesListData()
        {
            List<ServicesListEntity> ServicesLst = new List<ServicesListEntity>();
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
                                //SPList lstNews = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.NewsListUrl);
                                SPList lstServices = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ServicesListUrl);
                                if (lstServices != null)
                                {
                                    SPQuery oQuery = new SPQuery();

                                    oQuery.Query = SharedConstants.ServicesQuery;
                                    //oQuery.ViewFields = SharedConstants.NewsViewfields;

                                    SPListItemCollection lstItems = lstServices.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        ServicesListEntity services = new ServicesListEntity();
                                        services.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        services.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        services.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colDescription", "Resource", SPContext.Current.Web.Language)]);
                                        services.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        services.PageName = Convert.ToString(lstItem[SharedConstants.PageName]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        if (FileUrl != "#")
                                            services.Picture = FileUrl;
                                        else
                                            services.Picture = SharedConstants.URL_NO_IMAGE;

                                        ServicesLst.Add(services);
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
            return ServicesLst;
        }
        
        //public NewsEntity GetServicesListDataByID(int id)
        //{
        //    NewsEntity news = new NewsEntity();
        //    try
        //    {
        //        SPSecurity.RunWithElevatedPrivileges(delegate()
        //        {
        //            using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
        //            {
        //                //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
        //                using (SPWeb oWeb = oSite.RootWeb)
        //                {
        //                    if (oWeb != null)
        //                    {
        //                        SPList lstNews = oWeb.GetListFromUrl(oSite.Url + SharedConstants.NewsListUrl);
        //                        if (lstNews != null)
        //                        {
        //                            SPListItem NewsItem = lstNews.GetItemById(id);

        //                            news.ID = Convert.ToInt16(NewsItem[SharedConstants.ID]);
        //                            news.Title = Convert.ToString(NewsItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
        //                            news.Body = Convert.ToString(NewsItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

        //                            news.Created = Convert.ToDateTime(NewsItem[SharedConstants.Created]);
        //                            news.Date = Convert.ToDateTime(NewsItem[SharedConstants.Date]);

        //                            string FileUrl = Methods.ReturnAttachmentFile(oWeb, NewsItem);
        //                            news.Picture = FileUrl;

        //                            //try
        //                            //{ news.Picture = oWeb.Url + "/" + NewsItem.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[NewsItem.ID.ToString()].Files[0].Url; }
        //                            //catch
        //                            //{
        //                            //    news.Picture = SharedConstants.URL_NO_IMAGE;
        //                            //    // "../../../_layouts/YSA.SP.Portal/en/images/No-attachment-1.png";
        //                            //}
        //                        }
        //                    }
        //                }
        //            }
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        LoggingService.LogError("WebParts", ex.Message);
        //    }
        //    return news;
        //}
        # endregion
    }

    public class ExternalLinksManager
    {
        #region ServicesList
        public List<ExternalLinkEntity> GetAllActiveExternalLinksData(string srvsType)
        {
            List<ExternalLinkEntity> ExternalLinksLst = new List<ExternalLinkEntity>();
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
                                SPList lstExternalLinks = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ExternalLinksListUrl);
                                if (lstExternalLinks != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = @"<Where>
                                                          <And>
                                                             <Eq>
                                                                <FieldRef Name='IsActive' />
                                                                <Value Type='Boolean'>1</Value>
                                                             </Eq>
                                                             <Eq>
                                                                <FieldRef Name='SericeType' />
                                                                <Value Type='Choice'>"+ srvsType + @"</Value>
                                                             </Eq>
                                                          </And>
                                                    </Where><OrderBy><FieldRef Name='Order0' Ascending='True' /></OrderBy>"; ;

                                    SPListItemCollection lstItems = lstExternalLinks.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        ExternalLinkEntity externalLinks = new ExternalLinkEntity();
                                        externalLinks.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        externalLinks.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        //externalLinks.Description = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colDescription", "Resource", SPContext.Current.Web.Language)]);
                                        externalLinks.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        externalLinks.URL = Convert.ToString(lstItem["ServiceURL"]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        if (FileUrl != "#")
                                            externalLinks.Picture = FileUrl;
                                        else
                                            externalLinks.Picture = SharedConstants.URL_NO_IMAGE;

                                        ExternalLinksLst.Add(externalLinks);
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
            return ExternalLinksLst;
        }
        #endregion
    }
}
