

using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Globalization;
using System.Data;

namespace MOJ.DataManager
{
    public class ExpertsDataManager
    {


        public List<ExpertsEntity> GetExpertsFromTo(string Department, string curentdate)
        {
            List<ExpertsEntity> coolection = new List<ExpertsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ExpertsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where>";
                                if (Department != "")
                                {
                                    camlquery1 += "<And>";
                                }
                                // ///Filterfrom  format 2019-1-1
                                camlquery1 += "<And><Geq><FieldRef Name ='To'/><Value Type='DateTime'>" + curentdate + "</Value></Geq>";
                                camlquery1 += "<Leq><FieldRef Name ='From'/><Value Type='DateTime'>" + curentdate + "</Value></Leq></And>";
                                if (Department != "")
                                {
                                    camlquery1 += "<Eq><FieldRef Name ='Department'/><Value Type='Text'>" + Department + "</Value></Eq></And>";

                                }
                                camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    ExpertsEntity dr = new ExpertsEntity();
                                     dr.ID = Convert.ToInt32(Item["ID"]);
                                    dr.Title = Convert.ToString(Item["Title"]);
                                    dr.Department= Convert.ToString(Item["Department"]);
                                    dr.ExpertLoginName = new SPFieldUserValue(oWeb, Convert.ToString(Item["ExpertLoginName"]));

                                    dr.ExpertName= Convert.ToString(Item["ExpertName"]);
                                    dr.From= Convert.ToDateTime(Item["From"]);
                                    dr.To= Convert.ToDateTime(Item["To"]);
                                    coolection.Add(dr);
                                }
                            }
                        }
                    }
                }
            });
            return coolection;
        }
        public ExpertsEntity GetExpertsByID(int id)
        {
            ExpertsEntity obitem = new ExpertsEntity();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ExpertsUrl);
                                if (lst != null)
                                {
                                    SPListItem Item = lst.GetItemById(id);
                                    obitem.Department = Convert.ToString(Item["Department"]);
                                    obitem.ExpertLoginName = new SPFieldUserValue(oWeb, Convert.ToString(Item["ExpertLoginName"]));
                                    obitem.ExpertName = Convert.ToString(Item["ExpertName"]);
                                    obitem.ExpertPosition = Convert.ToString(Item["ExpertPosition"]);
                                    obitem.From = Convert.ToDateTime(Item["From"]);
                                    obitem.To = Convert.ToDateTime(Item["To"]);
                                  
                                    obitem.Created = Convert.ToDateTime(Item["Created"]);
                                    obitem.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["Author"]));

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
            return obitem;
        }



    }
}