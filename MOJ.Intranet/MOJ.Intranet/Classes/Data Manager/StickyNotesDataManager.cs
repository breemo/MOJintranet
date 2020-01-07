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
                //SPSecurity.RunWithElevatedPrivileges(delegate ()
                //{
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lstStickyNote = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.StickyNotesListUrl);
                            if (lstStickyNote != null)
                            {
                                var userId = SPContext.Current.Web.CurrentUser.ID;
                                SPQuery oQuery = new SPQuery();
                                oQuery.Query = @"<Query><Where>
                                                          <And>
                                                             <Neq>
                                                                <FieldRef Name='IsDeleted' />
                                                                <Value Type='Boolean'>False</Value>
                                                             </Neq>
                                                             <Eq>
                                                                <FieldRef Name='Author' LookupId='True' />
                                                                <Value Type='User'>" + userId + @"</Value>
                                                             </Eq>
                                                          </And>
                                                       </Where>
                                                   <OrderBy>
                                                      <FieldRef Name = 'Created' Ascending='False' />
                                                   </OrderBy>
                                                </Query>";
                                oQuery.ViewFields = SharedConstants.StickyNotesViewfields;

                                //oQuery.RowLimit = 6;

                                SPListItemCollection lstItems = lstStickyNote.GetItems(oQuery);

                                //string userName = "";
                                //string CurrentUser = "";
                                //string CurrentUserWithoutDot = "";
                                //SPContext currentContext;
                                //currentContext = SPContext.Current;

                                //var userId = SPContext.Current.Web.CurrentUser.ID;

                                //if (currentContext != null && currentContext.Web.CurrentUser != null)
                                //{
                                //    userName = SPContext.Current.Web.CurrentUser.LoginName.Split('\\')[1].ToLower();
                                //    CurrentUserWithoutDot = userName.Contains(".") ? userName.Replace(".", null).ToLower() : userName.ToLower();
                                //}


                                foreach (SPListItem lstItem in lstItems)
                                {
                                    //
                                    string[] CurrentUserNumber = lstItem["Author"].ToString().Split(';');

                                    //CurrentUser = lstItem["Created By"].ToString().Split('#')[1].ToString().Trim().Contains(" ") ? lstItem["Created By"].ToString().Split('#')[1].ToString().Trim().Replace(" ", null).ToLower() : lstItem["Created By"].ToString().Split('#')[1].ToString().Trim().ToLower();
                                    //if (lstItem["IsDeleted"].ToString() == "False" && CurrentUser == CurrentUserWithoutDot)
                                    if (lstItem["IsDeleted"].ToString() == "False" && CurrentUserNumber[0] == userId.ToString())
                                    {
                                        StickyNotesEntities sticky = new StickyNotesEntities();
                                        //sticky.TitleAr = Convert.ToString(lstItem[SharedConstants.TitleAr]);
                                        //sticky.TitleEn = Convert.ToString(lstItem[SharedConstants.TitleEn]);
                                        //sticky.TitleAr = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: Titlebilingual", "Resource", SPContext.Current.Web.Language)]);
                                        sticky.Title = Convert.ToString(lstItem["Title"]);
                                        sticky.Date = Convert.ToDateTime(lstItem[SharedConstants.Date]);
                                        sticky.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);

                                        StickyNoteLst.Add(sticky);
                                    }

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
            return StickyNoteLst;
        }
        public bool AddOrUpdate(StickyNotesEntities Stickyitem)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        SPUser currentUser = web.CurrentUser;
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.StickyNotesListUrl);
                        SPListItem item = null;
                        if (Stickyitem.ID > 0)
                        {
                            item = list.GetItemById(Stickyitem.ID);
                            isUpdate = true;
                        }
                        else
                        {
                            item = list.AddItem();
                        }

                        item["Title"] = Stickyitem.Title;
                        //item["Title En"] = Stickyitem.TitleEn;
                        item["Date"] = Stickyitem.Date;

                        item.Update();
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            return isFormSaved;
        }
    }
}
