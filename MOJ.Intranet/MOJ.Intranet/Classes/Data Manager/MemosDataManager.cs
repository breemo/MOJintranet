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
    public class MemosDataManager
    {
        # region Memos
        public List<MemosEntity> GetMemosDataHome()
        {
            List<MemosEntity> memosLst = new List<MemosEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Site.Url))
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lstMemos = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.MemosListUrl);
                                //SPList lstMemos = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MemosListUrl);
                                if (lstMemos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.MemosQuery;
                                    oQuery.ViewFields = SharedConstants.MemosViewfields;

                                    oQuery.RowLimit = 2;

                                    SPListItemCollection lstItems = lstMemos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        MemosEntity memos = new MemosEntity();
                                        memos.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        memos.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        memos.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                        memos.MemoNumber = Convert.ToString(lstItem[SharedConstants.MemoNumber]);
                                        memos.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        memos.Body = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        memos.AttachmentsInfo = FileUrl;

                                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                        memos.AttachmentPicture = Methods.CheckFileType(ext);

                                        memosLst.Add(memos);
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
        public List<MemosEntity> GetMemosData()
        {
            List<MemosEntity> memosLst = new List<MemosEntity>();
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
                                SPList lstMemos = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MemosListUrl);
                                if (lstMemos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.MemosQuery;
                                    oQuery.ViewFields = SharedConstants.MemosViewfields;

                                    //oQuery.RowLimit = 3;

                                    SPListItemCollection lstItems = lstMemos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        MemosEntity memos = new MemosEntity();
                                        memos.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        memos.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        memos.Body = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);
                                        memos.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        memos.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                        memos.MemoNumber = Convert.ToString(lstItem[SharedConstants.MemoNumber]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        memos.AttachmentsInfo = FileUrl;

                                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                        memos.AttachmentPicture = Methods.CheckFileType(ext);

                                        memosLst.Add(memos);
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
        public MemosEntity GetMemosDataByID(int id)
        {
            MemosEntity memos = new MemosEntity();
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
                                SPList lstMemos = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.MemosListUrl);
                                if (lstMemos != null)
                                {
                                    SPListItem MemosItem = lstMemos.GetItemById(id);

                                    memos.ID = Convert.ToInt16(MemosItem[SharedConstants.ID]);
                                    memos.Created = Convert.ToDateTime(MemosItem[SharedConstants.Created]);
                                    memos.Date = Convert.ToDateTime(MemosItem[SharedConstants.Date]);
                                    memos.MemoNumber = Convert.ToString(MemosItem[SharedConstants.MemoNumber]);
                                    memos.Title = Convert.ToString(MemosItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                    memos.Body = Convert.ToString(MemosItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                    string FileUrl = Methods.ReturnAttachmentFile(oWeb, MemosItem);
                                    memos.AttachmentsInfo = FileUrl;

                                    string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                    memos.AttachmentPicture = Methods.CheckFileType(ext);
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
            return memos;
        }
        public List<MemosEntity> GetMemosData(string srch, string number)
        {
            List<MemosEntity> memosLst = new List<MemosEntity>();
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
                                SPList lstMemos = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MemosListUrl);
                                if (lstMemos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = 
                                        "<Where>" +
                                        "<Or>" +
                                            "<Contains>" +
                                                "<FieldRef Name='Title' /><Value Type='Text'>" + srch + @"</Value>
                                            </Contains>" +
                                            "<Contains>" +
                                                "<FieldRef Name='Title' /><Value Type='MemoNumber'>" + number + @"</Value>
                                            </Contains>
                                        </Or>
                                        </Where>" + SharedConstants.MemosQuery;

                                    oQuery.ViewFields = SharedConstants.MemosViewfields;

                                    SPListItemCollection lstItems = lstMemos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        MemosEntity memos = new MemosEntity();
                                        memos.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        memos.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        memos.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                        memos.MemoNumber = Convert.ToString(lstItem[SharedConstants.MemoNumber]);
                                        memos.Title = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colTitle", "Resource", SPContext.Current.Web.Language)]);
                                        memos.Body = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: colBody", "Resource", SPContext.Current.Web.Language)]);

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        memos.AttachmentsInfo = FileUrl;

                                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                        memos.AttachmentPicture = Methods.CheckFileType(ext);

                                        memosLst.Add(memos);
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
        # endregion
    }
}
