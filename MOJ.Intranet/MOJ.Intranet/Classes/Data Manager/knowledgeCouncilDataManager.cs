using Microsoft.SharePoint;
using MOJ.Entities;
using MOJ.Business;
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
    public class knowledgeCouncilDataManager
    {
        public bool AddOrUpdateknowledgeCouncil(knowledgeCouncilEntity knowledgeCouncilItem)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        SPUser currentUser = web.CurrentUser;
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.knowledgeCouncilUrl);
                        SPListItem item = null;
                        if (knowledgeCouncilItem.ID > 0)
                        {
                            item = list.GetItemById(knowledgeCouncilItem.ID);
                            isUpdate = true;
                        }
                        else
                        {
                            item = list.AddItem();
                        }
                       
                        item["Title"] = knowledgeCouncilItem.Title;
                        item["CouncilDate"] = knowledgeCouncilItem.CouncilDate;
                        item["CouncilTarget"] = knowledgeCouncilItem.CouncilTarget;
                        item["CouncilTopic"] = knowledgeCouncilItem.CouncilTopic;
                        item["CouncilType"] = knowledgeCouncilItem.CouncilType;
                        item["Department"] = knowledgeCouncilItem.Department;
                        item["DirectManager"] = knowledgeCouncilItem.DirectManager;
                        item["EmployeeName"] = knowledgeCouncilItem.EmployeeName;
                        item["EmployeeNumber"] = knowledgeCouncilItem.EmployeeNumber;
                        item["JoiningConditions"] = knowledgeCouncilItem.JoiningConditions;
                        item["Designation"] = knowledgeCouncilItem.Designation;
                        item["Lecturer"] = knowledgeCouncilItem.Lecturer;
                        item.Update();

                        isFormSaved = true;
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
            //});
            return isFormSaved;
        }


        public knowledgeCouncilEntity GetknowledgeCouncilByID(int id)
        {
            knowledgeCouncilEntity obitem = new knowledgeCouncilEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.knowledgeCouncilUrl);
                                if (lst != null)
                                {                                  

                                    SPListItem item = lst.GetItemById(id);
                                    obitem.Title = Convert.ToString(item["Title"]);
                                     obitem.CouncilDate= Convert.ToDateTime(item["CouncilDate"] );
                                    obitem.CouncilTarget = Convert.ToString(item["CouncilTarget"] );
                                     obitem.CouncilTopic = Convert.ToString(item["CouncilTopic"]);
                                     obitem.CouncilType = Convert.ToString(item["CouncilType"]);
                                     obitem.Department= Convert.ToString(item["Department"]);
                                    obitem.DirectManager = Convert.ToString(item["DirectManager"]);
                                     obitem.EmployeeName= Convert.ToString(item["EmployeeName"]);
                                     obitem.EmployeeNumber= Convert.ToString(item["EmployeeNumber"]);
                                     obitem.JoiningConditions= Convert.ToString(item["JoiningConditions"]);
                                     obitem.Designation = Convert.ToString(item["Designation"]);
                                     obitem.Lecturer = Convert.ToString(item["Lecturer"]);
                                     obitem.Status = Convert.ToString(item["Status"]);
                                     obitem.CouncilNo = Convert.ToInt32(item["CouncilNo"]);

                                    obitem.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(item["Author"]));
                                    obitem.Created = Convert.ToDateTime(item["Created"]);
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

       public List<knowledgeCouncilEntity> GetPlannedCouncils(string username, string language, string curentDate)
        {
            List<knowledgeCouncilEntity> ItemsCollection = new List<knowledgeCouncilEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.knowledgeCouncilUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><And>";                               
                                camlquery1 += "<Eq><FieldRef Name='Status'></FieldRef><Value Type='Text'>Approved</Value></Eq>";
                                ///Filterfrom  format 2019-1-1
                                  camlquery1 += "<Geq><FieldRef Name ='CouncilDate'/><Value Type='DateTime'>" + curentDate + "</Value></Geq></And>";
                                   camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";

                                qry1.Query = camlquery1;
                                

                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    knowledgeCouncilEntity itemis = new knowledgeCouncilEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.CouncilDate = Convert.ToDateTime(Item["CouncilDate"]);
                                    itemis.CouncilNo = Convert.ToInt32(Item["CouncilNo"]);
                                    itemis.CouncilTarget = Convert.ToString(Item["CouncilTarget"]);
                                    itemis.CouncilTopic = Convert.ToString(Item["CouncilTopic"]);
                                    itemis.CouncilType = Convert.ToString(Item["CouncilType"]);
                                    itemis.Department = Convert.ToString(Item["Department"]);
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.DirectManager = Convert.ToString(Item["DirectManager"]);
                                    itemis.EmployeeName = Convert.ToString(Item["EmployeeName"]);
                                    itemis.EmployeeNumber = Convert.ToString(Item["EmployeeNumber"]);
                                    itemis.JoiningConditions = Convert.ToString(Item["JoiningConditions"]);
                                    itemis.Lecturer = Convert.ToString(Item["Lecturer"]);
                                    CouncilMembersEntity Citem = new CouncilMembers().GetMemberID(Convert.ToInt32(Item["ID"]), username);
                                    itemis.Status = "join";

                                    if (Citem.ID != 0)
                                    {
                                        itemis.Status = Citem.Status;
                                    }
                                    if (language == "ar")
                                    {
                                        itemis.Status = "انضم";
                                        if (Citem.ID != 0)
                                        {
                                            if (Citem.Status == "Approved")
                                            {
                                                itemis.Status = "موافق";

                                            }
                                            if (Citem.Status == "Rejected")
                                            {
                                                itemis.Status = "مرفوض";

                                            }
                                            if (Citem.Status == "Pending")
                                            {
                                                itemis.Status = "معلق";

                                            }

                                        }


                                    }

                                    itemis.RequestURL = "CouncilMembers.aspx?TID=" + Convert.ToInt32(Item["ID"])+"&Title="+ Convert.ToString(Item["CouncilTopic"]) ;

                                    ItemsCollection.Add(itemis);


                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

         public List<knowledgeCouncilEntity> GetknowledgeCouncil(int intRowLimit, string CouncilTopicvalue, string CouncilNovalue, string CouncilDatevalue, string Departmentvalue)
        {
            List<knowledgeCouncilEntity> ItemsCollection = new List<knowledgeCouncilEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.knowledgeCouncilUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where>";
                                if (CouncilTopicvalue != "")
                                {
                                    camlquery1 += "<And>";
                                }
                                if (CouncilNovalue != "")
                                {
                                    camlquery1 += "<And>";
                                }
                                if (CouncilDatevalue != "")
                                {
                                    camlquery1 += "<And>";
                                }if (Departmentvalue != "")
                                {
                                    camlquery1 += "<And>";
                                }
                                camlquery1 += "<Eq><FieldRef Name='Status'></FieldRef><Value Type='Text'>Approved</Value></Eq>";

                                if (CouncilTopicvalue != "")
                                {
                                    camlquery1 += "<Eq><FieldRef Name='CouncilTopic'/><Value Type='Text'>" + CouncilTopicvalue + "</Value></Eq></And>";
                                }
                                if (CouncilNovalue != "")
                                {
                                    camlquery1 += "<Eq><FieldRef Name='CouncilNo'/><Value Type='number'>" + CouncilNovalue + "</Value></Eq></And>";
                                }                               
                                
                                if (CouncilDatevalue != "")
                                {///Filterfrom  format 2019-1-1
                                    camlquery1 += "<Eq><FieldRef Name ='CouncilDate'/><Value Type='DateTime'>" + CouncilDatevalue + "</Value></Eq></And>";

                                }
                            if (Departmentvalue != "")
                            {
                                camlquery1 += "<Eq><FieldRef Name='Department'/><Value Type='Text'>" + Departmentvalue + "</Value></Eq></And>";
                            }

                            camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";

                                qry1.Query = camlquery1;
                                if (intRowLimit != 0)
                                    qry1.RowLimit = (uint)intRowLimit;

                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    knowledgeCouncilEntity itemis = new knowledgeCouncilEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.CouncilDate = Convert.ToDateTime(Item["CouncilDate"]);
                                    itemis.CouncilNo = Convert.ToInt32(Item["CouncilNo"]);
                                    itemis.CouncilTarget = Convert.ToString(Item["CouncilTarget"]);
                                    itemis.CouncilTopic = Convert.ToString(Item["CouncilTopic"]);
                                    itemis.CouncilType = Convert.ToString(Item["CouncilType"]);
                                    itemis.Department = Convert.ToString(Item["Department"]);
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.DirectManager = Convert.ToString(Item["DirectManager"]);
                                    itemis.EmployeeName = Convert.ToString(Item["EmployeeName"]);
                                    itemis.EmployeeNumber = Convert.ToString(Item["EmployeeNumber"]);
                                    itemis.JoiningConditions = Convert.ToString(Item["JoiningConditions"]);
                                    itemis.Lecturer = Convert.ToString(Item["Lecturer"]);
                                    itemis.Status = Convert.ToString(Item["Status"]);
                                    itemis.RequestURL = "HeldCouncilsDetail.aspx?RID=" + Convert.ToInt32(Item["ID"]) ;

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
