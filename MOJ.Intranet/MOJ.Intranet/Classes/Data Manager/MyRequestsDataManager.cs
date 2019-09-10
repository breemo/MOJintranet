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
        public List<MyRequestsEntity> GetMyRequests(int intRowLimit, string languageCodes, string FilterRequestNumber, string FilterResult, string Filterfrom, string Filterto)
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
                                string camlquery1 = "<Where>";
                                if (FilterRequestNumber != "")
                                {
                                    camlquery1 += "<And>";

                                }
                                if (FilterResult != "")
                                {
                                    camlquery1 += "<And>";

                                }
                                if (Filterfrom != "")
                                {
                                    camlquery1 += "<And>";

                                }
                                if (Filterto != "")
                                {
                                    camlquery1 += "<And>";

                                }

                                camlquery1 += "<Eq><FieldRef Name='RequestBy' LookupId='TRUE' /><Value Type='User'>" + SPContext.Current.Web.CurrentUser.ID + "</Value> </Eq>";

                                if (FilterRequestNumber != "")
                                {
                                    camlquery1 += "<Contains><FieldRef Name='Title'/><Value Type='Text'>" + FilterRequestNumber + "</Value></Contains></And>";
                                }
                                if (FilterResult != "")
                                {

                                    if (languageCodes == "ar")
                                    {
                                        camlquery1 += "<Contains><FieldRef Name='StatusAr'/><Value Type='Text'>" + FilterResult + "</Value></Contains></And>";

                                    }
                                    else
                                    {
                                        camlquery1 += "<Contains><FieldRef Name='ServiceNameEn'/><Value Type='Text'>" + FilterResult + "</Value></Contains></And>";
                                        
                                    }
                                }
                                if (Filterfrom != "")
                                {///Filterfrom  format 2019-1-1
                                    camlquery1 += "<Geq><FieldRef Name ='Created'/><Value Type='DateTime'>"+ Filterfrom + "</Value></Geq></And>";

                                }
                                if (Filterto != "")
                                {
                                    camlquery1 += "<Leq><FieldRef Name ='Created'/><Value Type='DateTime'>" + Filterto + "</Value></Leq></And>";

                                }
                                camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";

                                qry1.Query = camlquery1;
                                if (intRowLimit != 0)
                                    qry1.RowLimit = (uint)intRowLimit;

                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    MyRequestsEntity itemis = new MyRequestsEntity();
                                    itemis.RequestNumber = Convert.ToString(Item["Title"]);
                                    itemis.id = Convert.ToInt32(Item["ID"]);
                                    itemis.ServiceName = Convert.ToString(Item["ServiceName"]);
                                    itemis.ServiceNameAr = Convert.ToString(Item["ServiceNameAr"]);

                                    if (languageCodes == "ar")
                                    {
                                        itemis.ServiceNameLG = Convert.ToString(Item["ServiceNameAr"]);
                                        itemis.StatusLG = Convert.ToString(Item["StatusAr"]);
                                    }
                                    else
                                    {
                                        itemis.ServiceNameLG = Convert.ToString(Item["ServiceNameEn"]);
                                        itemis.StatusLG = Convert.ToString(Item["StatusEn"]);
                                    }
                                    itemis.ServiceNameEn = Convert.ToString(Item["ServiceNameEn"]);
                                    itemis.StatusAr = Convert.ToString(Item["StatusAr"]);
                                    itemis.StatusEn = Convert.ToString(Item["StatusEn"]);
                                    itemis.Created = Convert.ToDateTime(Item["Created"]);
                                    itemis.RequestBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["RequestBy"]));
                                    itemis.RequestID = Convert.ToString(Item["RequestID"]);
                                    itemis.RequestURL = "ViewRequest.aspx?RID=" + Convert.ToInt32(Item["RequestID"]) + "&list=" + Convert.ToString(Item["ServiceName"]);

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
