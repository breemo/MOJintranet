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
    public class DepartmentProceduresDataManager
    {
        public List<DepartmentProceduresEntity> GetDepartmentProcedures()
        {
            List<DepartmentProceduresEntity> DepartmentProcedureslst = new List<DepartmentProceduresEntity>();
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
                                SPList CurrentList = oWeb.Lists[SPUtility.GetLocalizedString("$Resources: DepartmentProceduresListName", "Resource", SPContext.Current.Web.Language)];
                                //SPList lstDepartmentCirculars = oWeb.GetListFromUrl("/Ar/MyDepartment/HR/Lists/DepartmentCirculars/AllItems.aspx");
                                if (CurrentList != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.DepartmentProceduresQuery;
                                    oQuery.ViewFields = SharedConstants.DepartmentProceduresfields;
                                    SPListItemCollection lstItems = CurrentList.GetItems(oQuery);

                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        DepartmentProceduresEntity Procedures = new DepartmentProceduresEntity();
                                        Procedures.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        Procedures.ProcedureTitle = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: ProcedureTitle", "Resource", SPContext.Current.Web.Language)]);
                                        Procedures.ProcedureDate = Convert.ToDateTime(lstItem[SPUtility.GetLocalizedString("$Resources: ProcedureDate", "Resource", SPContext.Current.Web.Language)]);
                                        Procedures.ProcedureBody = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: ProcedureBody", "Resource", SPContext.Current.Web.Language)]);

                                        DepartmentProcedureslst.Add(Procedures);
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
            return DepartmentProcedureslst;
        }
        public DepartmentProceduresEntity GetDepartmentProceduresByID(int id)
        {
            DepartmentProceduresEntity DepartmentProcedureslst = new DepartmentProceduresEntity();
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
                                SPList CurrentList = oWeb.Lists[SPUtility.GetLocalizedString("$Resources: DepartmentProceduresListName", "Resource", SPContext.Current.Web.Language)];
                                //SPList lstDepartmentCirculars = oWeb.GetListFromUrl("/Ar/MyDepartment/HR/Lists/DepartmentCirculars/AllItems.aspx");
                                if (CurrentList != null)
                                {
                                    SPListItem lstItem = CurrentList.GetItemById(id);
                                    //DepartmentProcedureslst.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                    DepartmentProcedureslst.ProcedureTitle = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: ProcedureTitle", "Resource", SPContext.Current.Web.Language)]);
                                    DepartmentProcedureslst.ProcedureDate = Convert.ToDateTime(lstItem[SPUtility.GetLocalizedString("$Resources: ProcedureDate", "Resource", SPContext.Current.Web.Language)]);
                                    DepartmentProcedureslst.ProcedureBody = Convert.ToString(lstItem[SPUtility.GetLocalizedString("$Resources: ProcedureBody", "Resource", SPContext.Current.Web.Language)]);

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
            return DepartmentProcedureslst;
        }
    }
}
