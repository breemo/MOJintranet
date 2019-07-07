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
                        using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            if (oWeb != null)
                            {
                                SPList lstMemos = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.MemosListUrl);
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
                                        memos.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                        memos.Body = Convert.ToString(lstItem[SharedConstants.Body]);
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

        public List<MemosEntity> GetMemosData()
        {
            List<MemosEntity> memosLst = new List<MemosEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            if (oWeb != null)
                            {
                                SPList lstMemos = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.MemosListUrl);
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
                                        memos.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                        memos.Body = Convert.ToString(lstItem[SharedConstants.Body]);
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
            //try
            //{
            //    SPSecurity.RunWithElevatedPrivileges(delegate ()
            //    {
            //        using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
            //        {
            //            using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
            //            {
            //                if (oWeb != null)
            //                {
            //                    SPList lstMemos = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.MemosListUrl);
            //                    if (lstMemos != null)
            //                    {
            //                        SPListItem MemosItem = lstMemos.GetItemById(id);

            //                        memos.ID = Convert.ToInt16(MemosItem[SharedConstants.ID]);
            //                        memos.Title = Convert.ToString(MemosItem[SharedConstants.Title]);
            //                        memos.Body = Convert.ToString(MemosItem[SharedConstants.Body]);
            //                        memos.Created = Convert.ToDateTime(MemosItem[SharedConstants.Created]);
            //                        memos.Date = Convert.ToDateTime(MemosItem[SharedConstants.Date]);
            //                        memos.MemoNumber = Convert.ToString(lstItem[SharedConstants.MemoNumber]);

            //                        string FileUrl = SP.Common.Methods.ReturnAttachmentFile(oWeb, MemosItem);
            //                        memos.AttachmentsInfo = FileUrl;

            //                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
            //                        memos.AttachmentPicture = SP.Common.Methods.CheckFileType(ext);
            //                    }
            //                }
            //            }
            //        }
            //    });

            //}
            //catch (Exception ex)
            //{
            //    LoggingService.LogError("WebParts", ex.Message);
            //}
            return memos;
        }

        public List<MemosEntity> GetMemosData(string srch)
        {
            List<MemosEntity> memosLst = new List<MemosEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        {
                            if (oWeb != null)
                            {
                                SPList lstMemos = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.MemosListUrl);
                                if (lstMemos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = "<Where><Contains><FieldRef Name='Title' /><Value Type='Text'>" + srch + @"</Value></Contains></Where>" + SharedConstants.MemosQuery;
                                    oQuery.ViewFields = SharedConstants.MemosViewfields;

                                    //oQuery.RowLimit = 3;

                                    SPListItemCollection lstItems = lstMemos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        MemosEntity memos = new MemosEntity();
                                        memos.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        memos.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                        memos.Body = Convert.ToString(lstItem[SharedConstants.Body]);
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

        

        # endregion
    }
}
