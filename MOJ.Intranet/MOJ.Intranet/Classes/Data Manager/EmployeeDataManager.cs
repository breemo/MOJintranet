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
    public class EmployeeDataManager
    {
        #region Employee
        public bool AddOrUpdate(EmployeeEntity EItem)
        {
            bool isFormSaved = false;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        try
                        {                 
                            web.AllowUnsafeUpdates = true;
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.EmployeeUrl);
                        if (list != null)
                        {
                            SPQuery qry1 = new SPQuery();
                            string camlquery1 = "<Where><Eq><FieldRef Name='Title'/> <Value Type='Text'>" + EItem.AccountName + "</Value></Eq></Where>";
                            qry1.Query = camlquery1;
                            SPListItemCollection listItemsCollection1 = list.GetItems(qry1);
                                SPListItem item = null;
                            if (listItemsCollection1.Count > 0) { 
                            SPListItem Item = listItemsCollection1[0];
                                item = list.GetItemById(Convert.ToInt32(Item["ID"]));
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            //item["Created By"] = SPContext.Current.Web.CurrentUser;
                            //item["Modified By"] = SPContext.Current.Web.CurrentUser;
                            item["Title"] = EItem.AccountName;
                            item["mangerID"] = EItem.mangerID;
                            item["mangerName"] = EItem.mangerName;
                            item["mangerEmail"] = EItem.mangerEmail;
                            item.Update();
                          
                            isFormSaved = true;
                        }               

                          
                        }
                        catch (Exception ex)
                        {
                            isFormSaved = false;
                            LoggingService.LogError("WebParts", ex.Message);
                            throw ex;
                        }
                        finally
                        {
                            web.AllowUnsafeUpdates = false;
                        }
                    }
                }
            });
            return isFormSaved;
        }
               
        #endregion
    }
}
