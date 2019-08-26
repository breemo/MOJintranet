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
    public class DepartmentCircularsDataManager
    {
        public List<DepartmentCircularsEntity> GetDepartmentCirculars()
        {
            List<DepartmentCircularsEntity> DepartmentCircularslst = new List<DepartmentCircularsEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Web.Url))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {
                            if (oWeb != null)
                            {
                                SPList CurrentList = oWeb.Lists[SPUtility.GetLocalizedString("$Resources: DepartmentCircularsListName", "Resource", SPContext.Current.Web.Language)];
                                //SPList lstDepartmentCirculars = oWeb.GetListFromUrl("/Ar/MyDepartment/HR/Lists/DepartmentCirculars/AllItems.aspx");
                                if (CurrentList != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.DepartmentCircularsQuery;
                                    oQuery.ViewFields = SharedConstants.DepartmentCircularsfields;
                                    SPListItemCollection lstItems = CurrentList.GetItems(oQuery);

                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        DepartmentCircularsEntity Circulars = new DepartmentCircularsEntity();
                                        Circulars.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        Circulars.CircularTitle = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: CircularTitle", "Resource", SPContext.Current.Web.Language)]);
                                        Circulars.CircularDate = Convert.ToDateTime(lstItem[SPUtility.GetLocalizedString("$Resources: CircularDate", "Resource", SPContext.Current.Web.Language)]);
                                        Circulars.CircularBody = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: CircularBody", "Resource", SPContext.Current.Web.Language)]);

                                        DepartmentCircularslst.Add(Circulars);
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
            return DepartmentCircularslst;
        }
        public DepartmentCircularsEntity GetDepartmentCircularsByID(int id)
        {
            DepartmentCircularsEntity DepartmentCircularslst = new DepartmentCircularsEntity();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Web.Url))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {
                            if (oWeb != null)
                            {
                                SPList CurrentList = oWeb.Lists[SPUtility.GetLocalizedString("$Resources: DepartmentCircularsListName", "Resource", SPContext.Current.Web.Language)];
                                //SPList lstDepartmentCirculars = oWeb.GetListFromUrl("/Ar/MyDepartment/HR/Lists/DepartmentCirculars/AllItems.aspx");
                                if (CurrentList != null)
                                {
                                    SPListItem lstItem = CurrentList.GetItemById(id);
                                    //DepartmentCircularslst.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                    DepartmentCircularslst.CircularTitle = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: CircularTitle", "Resource", SPContext.Current.Web.Language)]);
                                    DepartmentCircularslst.CircularDate = Convert.ToDateTime(lstItem[SPUtility.GetLocalizedString("$Resources: CircularDate", "Resource", SPContext.Current.Web.Language)]);
                                    DepartmentCircularslst.CircularBody = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: CircularBody", "Resource", SPContext.Current.Web.Language)]);

                                   
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
            return DepartmentCircularslst;
        }
    }
}
