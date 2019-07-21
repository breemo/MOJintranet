using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.DataManager
{
    public class MinistryFilesDataManager
    {
        public List<MinistryFilesEntity> GetMinistryFilesData()
        {
            List<MinistryFilesEntity> Fileslst = new List<MinistryFilesEntity>();
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
                                SPList lstMinistryFiles = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MinistryFilesListUrl);
                                if (lstMinistryFiles != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.MinistryFilesQuery;
                                    oQuery.ViewFields = SharedConstants.MinistryFilesViewfields;

                                    SPListItemCollection lstItems = lstMinistryFiles.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        string BookImgURL = Convert.ToString(lstItem["Book Image"]).Split(',')[0];
                                        string CreatedUser = lstItem["Created By"].ToString().Split('#')[1].ToString();
                                        MinistryFilesEntity Books = new MinistryFilesEntity();
                                        Books.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        Books.BookTitle = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: MinistryFilesBookTitle", "Resource", SPContext.Current.Web.Language)]);
                                        Books.BookDescAr = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: MinistryFilesBookDesc", "Resource", SPContext.Current.Web.Language)]);
                                        Books.BookImage = BookImgURL;
                                        Books.CreatedBy = CreatedUser;

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        Books.AttachmentsInfo = FileUrl;

                                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                        Books.AttachmentPicture = Methods.CheckFileType(ext);

                                        Fileslst.Add(Books);
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
            return Fileslst;
        }

        public List<MinistryFilesEntity> GetMinistryFilesSearch(string BookName, string CreatedBy)
        {
            if (BookName == "")
                BookName = " ";

            if (CreatedBy == "")
                CreatedBy = " ";

            List<MinistryFilesEntity> Fileslst = new List<MinistryFilesEntity>();
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
                                SPList lstMinistryFiles = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MinistryFilesListUrl);
                                if (lstMinistryFiles != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query =

                                           "<Where>" +
                                              "<Or>" +
                                                 "<Contains>" +
                                                    "<FieldRef Name='Author'/>" +
                                                     "<Value Type='User'>" + CreatedBy + @"</Value>" +
                                                       "</Contains>" +
                                                       "<Contains>" +
                                                     "<FieldRef Name='Title'/>" +
                                                           "<Value Type='Text'>" + BookName + @"</Value>" +
                                                       "</Contains>" +
                                                          "</Or>" +
                                                       "</Where>" + SharedConstants.MinistryFilesQuery;

                                    oQuery.ViewFields = SharedConstants.MinistryFilesViewfields;

                                    SPListItemCollection lstItems = lstMinistryFiles.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        string BookImgURL = Convert.ToString(lstItem["Book Image"]).Split(',')[0];
                                        string CreatedUser = lstItem["Created By"].ToString().Split('#')[1].ToString();
                                        MinistryFilesEntity Books = new MinistryFilesEntity();
                                        Books.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        Books.BookTitle = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: MinistryFilesBookTitle", "Resource", SPContext.Current.Web.Language)]);
                                        Books.BookDescAr = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: MinistryFilesBookDesc", "Resource", SPContext.Current.Web.Language)]);
                                        Books.BookImage = BookImgURL;
                                        Books.CreatedBy = CreatedUser;

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        Books.AttachmentsInfo = FileUrl;

                                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                        Books.AttachmentPicture = Methods.CheckFileType(ext);

                                        Fileslst.Add(Books);
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
            return Fileslst;
        }
    }
}
