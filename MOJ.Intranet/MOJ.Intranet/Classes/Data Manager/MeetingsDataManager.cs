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
    public class MeetingsDataManager
    {
        public List<MeetingsEntity> GetMeetingsDataHome()
        {
            List<MeetingsEntity> MeetingsLst = new List<MeetingsEntity>();
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
                                SPList lstMeetings = oWeb.GetListFromUrl(oWeb.Url + SharedConstants.MeetingsListUrl);
                                if (lstMeetings != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = @"
                                       <Where>
                                          <Eq>
                                             <FieldRef Name='Author' />
                                             <Value Type='User'> "+ currentContext.Web.CurrentUser.Name + @" </Value>
                                          </Eq>
                                       </Where>
                                       <OrderBy>
                                          <FieldRef Name='Created' Ascending='False' />
                                       </OrderBy>";

                                    //oQuery.Query = SharedConstants.MeetingsQuery;
                                    oQuery.ViewFields = SharedConstants.MeetingsViewfields;

                                    oQuery.RowLimit = 2;

                                    SPListItemCollection lstItems = lstMeetings.GetItems(oQuery);

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
                                        if (CurrentUser == CurrentUserWithoutDot)
                                        {
                                            MeetingsEntity Meeting = new MeetingsEntity();
                                            Meeting.Title = Convert.ToString(lstItem[SharedConstants.Title]);
                                            Meeting.StartTime = Convert.ToDateTime(lstItem["Start Time"]);
                                            Meeting.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);

                                            MeetingsLst.Add(Meeting);
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
            return MeetingsLst;
        }
    }
}
