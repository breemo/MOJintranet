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
    public class StickyNotesDataManager
    {
        public List<StickyNotesEntities> GetStickyNotesDataHome()
        {
            List<StickyNotesEntities> StickyNoteLst = new List<StickyNotesEntities>();
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
                                SPList lstStickyNote = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.StickyNotesListUrl);
                                if (lstStickyNote != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.StickyNotesQuery;
                                    oQuery.ViewFields = SharedConstants.StickyNotesViewfields;

                                    oQuery.RowLimit = 6;

                                    SPListItemCollection lstItems = lstStickyNote.GetItems(oQuery);

                                    string userName = "";
                                    string CurrentUser = "";
                                    string CurrentUserWithoutDot = "";
                                    SPContext currentContext;
                                    currentContext = SPContext.Current;


                                    if (currentContext != null && currentContext.Web.CurrentUser != null)
                                    {
                                        userName = SPContext.Current.Web.CurrentUser.LoginName.Split('\\')[1].ToLower();
                                        CurrentUserWithoutDot = userName.Contains(".") ? userName.Replace(".", null).ToLower() : userName.ToLower();
                                    }


                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        CurrentUser = lstItem["Created By"].ToString().Split('#')[1].ToString().Trim().Contains(" ") ? lstItem["Created By"].ToString().Split('#')[1].ToString().Trim().Replace(" ", null).ToLower() : lstItem["Created By"].ToString().Split('#')[1].ToString().Trim().ToLower();
                                        if (lstItem["IsDeleted"].ToString() == "False" && CurrentUser == CurrentUserWithoutDot)
                                        {
                                            StickyNotesEntities sticky = new StickyNotesEntities();
                                            //sticky.TitleAr = Convert.ToString(lstItem[SharedConstants.TitleAr]);
                                            //sticky.TitleEn = Convert.ToString(lstItem[SharedConstants.TitleEn]);
                                            sticky.TitleAr = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: Titlebilingual", "Resource", SPContext.Current.Web.Language)]);
                                            sticky.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                            sticky.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);

                                            StickyNoteLst.Add(sticky);
                                        }

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
            return StickyNoteLst;
        }
    }
}
