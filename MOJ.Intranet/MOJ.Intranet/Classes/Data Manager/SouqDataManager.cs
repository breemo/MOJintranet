﻿using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.DataManager
{
    public class SouqDataManager
    {
        public List<SouqEntity> GetSouqData()
        {
            List<SouqEntity> Souqlst = new List<SouqEntity>();
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
                                SPList lstMinistryFiles = oWeb.GetListFromUrl(oSite.Url + SharedConstants.SouqListUrl);
                                if (lstMinistryFiles != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.SouqQuery;
                                    SPListItemCollection lstItems = lstMinistryFiles.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        string CreatedUser = lstItem["Created By"].ToString().Split('#')[1].ToString();

                                        SouqEntity Souq = new SouqEntity();
                                        Souq.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        Souq.Title = Convert.ToString(lstItem["Title"]);
                                        Souq.Category = Convert.ToString(lstItem["Category"]);
                                        Souq.Description = Convert.ToString(lstItem["Description"]);
                                        Souq.ContactNumber = Convert.ToString(lstItem["Contact Number"]);
                                        Souq.Price = Convert.ToInt16(lstItem["Price"]);
                                        Souq.CreatedBy = CreatedUser;

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        Souq.AttachmentsInfo = FileUrl;

                                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                        Souq.AttachmentPicture = Methods.CheckFileType(ext);

                                        Souqlst.Add(Souq);
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
            return Souqlst;
        }
        public List<SouqEntity> GetSouqDataFromCategories(string Category1, string Category2, string Category3, string Category4)
        {
            List<SouqEntity> Souqlst = new List<SouqEntity>();

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
                                SPList lstSouq = oWeb.GetListFromUrl(oSite.Url + SharedConstants.SouqListUrl);
                                if (lstSouq != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = @"<Where><And><Eq><FieldRef Name='SouqAppr' /><Value Type='WorkflowStatus'>16</Value></Eq><Or><Eq><FieldRef Name='Category' /><Value Type='Choice'>" + Category1 + "</Value></Eq><Or><Eq><FieldRef Name='Category' /><Value Type='Choice'>" + Category2 + "</Value></Eq><Or><Eq><FieldRef Name='Category' /><Value Type='Choice'>" + Category3 + "</Value></Eq><Eq><FieldRef Name='Category' /><Value Type='Choice'>" + Category4 + "</Value></Eq></Or></Or></Or></And></Where>" + SharedConstants.SouqQuery;
                                    SPListItemCollection lstItems = lstSouq.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        string CreatedUser = lstItem["Created By"].ToString().Split('#')[1].ToString();
                                        SouqEntity Souq = new SouqEntity();
                                        Souq.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        Souq.Title = Convert.ToString(lstItem["Title"]);
                                        Souq.Category = Convert.ToString(lstItem["Category"]);
                                        Souq.Description = Convert.ToString(lstItem["Description"]);
                                        Souq.ContactNumber = Convert.ToString(lstItem["Contact Number"]);
                                        Souq.Price = Convert.ToInt16(lstItem["Price"]);
                                        Souq.CreatedBy = CreatedUser;

                                        string FileUrl = Methods.ReturnAttachmentFile(oWeb, lstItem);
                                        Souq.AttachmentsInfo = FileUrl;

                                        string ext = FileUrl.Split('.')[FileUrl.Split('.').Length - 1];
                                        Souq.AttachmentPicture = Methods.CheckFileType(ext);

                                        Souqlst.Add(Souq);
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
            return Souqlst;
        }
    }
}