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
    public class CountrysDataManager
    {


        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("TitleEN", typeof(string));
            DataRow Firstdr = dt.NewRow();
            Firstdr["ID"] = "0";
            Firstdr["Title"] = "الرجاء الاختيار";
            Firstdr["TitleEN"] = "Please choose";
            dt.Rows.Add(Firstdr);

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CountrysUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where></Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    DataRow dr = dt.NewRow();
                                    dr["ID"] = Convert.ToInt32(Item["ID"]);
                                    dr["Title"] = Convert.ToString(Item["Title"]);
                                    dr["TitleEN"] = Convert.ToString(Item["TitleEN"]);
                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
            });
            return dt;
        }


        public string GetCode(int id)
        {
            string Code = "";
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CountrysUrl);
                                if (lst != null)
                                {
                                    SPListItem Item = lst.GetItemById(id);
                                    Code = Convert.ToString(Item["Code"]);
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
            return Code;
        }
        public string GetTitle(int id,string lang="ar")
        {
            string Titleis = "";
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CountrysUrl);
                                if (lst != null)
                                {
                                    SPListItem Item = lst.GetItemById(id);
                                    if (lang == "ar")
                                    {
                                        Titleis = Convert.ToString(Item["Title"]);
                                    }
                                    else
                                    {
                                        Titleis = Convert.ToString(Item["TitleEN"]);
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
            return Titleis;
        }
    }
}