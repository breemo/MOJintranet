using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Globalization;

namespace MOJ.DataManager
{
    public class DepartmentsDataManager
    {
      
        public DepartmentsEntity GetbyDepartments(string Departmentvalue)
        {
            DepartmentsEntity ItemsCollection = new DepartmentsEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.DepartmentsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where>";
                               
                                camlquery1 += "<Eq><FieldRef Name='Title' /><Value Type='Text'>" + Departmentvalue + "</Value> </Eq>";

                                               
                                camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    
                                    ItemsCollection.ID = Convert.ToInt32(Item["ID"]);
                                    ItemsCollection.Title = Convert.ToString(Item["Title"]);
                                    ItemsCollection.DepartmentAdmin = new SPFieldUserValue(oWeb, Convert.ToString(Item["DepartmentAdmin"]));                                   


                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

     




    }
}
