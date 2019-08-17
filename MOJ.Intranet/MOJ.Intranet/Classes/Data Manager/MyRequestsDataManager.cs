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
    public class MyRequestsDataManager
    {
        public List<MyRequestsEntity> GetMyRequests()
        {
            List<MyRequestsEntity> ItemsCollection = new List<MyRequestsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MyRequestsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='RequestBy' LookupId='TRUE' /><Value Type='User'>"+ SPContext.Current.Web.CurrentUser.ID + "</Value> </Eq></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {

                                    MyRequestsEntity itemis = new MyRequestsEntity();
                                    itemis.RequestNumber = Convert.ToString(Item["Title"]);
                                    itemis.id = Convert.ToInt32(Item["ID"]);
                                    itemis.ServiceName = Convert.ToString(Item["ServiceName"]);
                                    itemis.ServiceNameAr = Convert.ToString(Item["ServiceNameAr"]);
                                    itemis.ServiceNameEn = Convert.ToString(Item["ServiceNameEn"]);
                                    itemis.StatusAr = Convert.ToString(Item["StatusAr"]);
                                    itemis.StatusEn = Convert.ToString(Item["StatusEn"]);
                                    itemis.Created = Convert.ToDateTime(Item["Created"]);
                                    itemis.RequestBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["RequestBy"]));
                                    itemis.RequestID = Convert.ToString(Item["RequestID"]);
                                    itemis.RequestURL = "ViewRequest.aspx?RID=" + Convert.ToInt32(Item["RequestID"])+"&list="+Convert.ToString(Item["ServiceName"]);

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
