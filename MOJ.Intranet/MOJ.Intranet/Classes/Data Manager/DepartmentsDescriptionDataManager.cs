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
    public class DepartmentsDescriptionDataManager
    {
     
        public List<DepartmentsDescriptionEntity> GetDepartmentsDescription(string Departmentvalue)
        {
            List<DepartmentsDescriptionEntity> ItemsCollection = new List<DepartmentsDescriptionEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.DepartmentsDescriptionUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Department'/><Value Type='Lookup'>" + Departmentvalue + "</Value></Eq>";
                               
                                camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                               
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    DepartmentsDescriptionEntity itemis = new DepartmentsDescriptionEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);                                  
                                    itemis.TitleEN = Convert.ToString(Item["TitleEN"]);                                  
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.Department = Departmentvalue;
                                    itemis.Description = Convert.ToString(Item["Description"]);
                                    itemis.DescriptionEN = Convert.ToString(Item["DescriptionEN"]);
                                    ItemsCollection.Add(itemis);


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
