using CommonLibrary;
using Microsoft.SharePoint;
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
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        StickyNotesEntities sticky = new StickyNotesEntities();
                                        sticky.TitleAr = Convert.ToString(lstItem[SharedConstants.TitleAr]);
                                        sticky.TitleEn = Convert.ToString(lstItem[SharedConstants.TitleEn]);
                                        sticky.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);

                                        StickyNoteLst.Add(sticky);
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
