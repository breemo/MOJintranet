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
    public class AskAnExpertDataManager
    {
        public AskAnExpertEntity GetAskAnExpertbyid(int id)
        {
            AskAnExpertEntity itemis = new AskAnExpertEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.AskAnExpertUrl);
                            if (lst != null)
                            {
                                SPListItem Item = lst.GetItemById(id);
                                itemis.Title = Convert.ToString(Item["Title"]);
                                itemis.QuestionTitle = Convert.ToString(Item["QuestionTitle"]);
                                itemis.ID = Convert.ToInt32(Item["ID"]);
                                itemis.Department = Convert.ToString(Item["Department"]);
                                itemis.ExpertID = Convert.ToString(Item["ExpertID"]);
                                itemis.QuestionDetails = Convert.ToString(Item["QuestionDetails"]);
                                itemis.loginName = Convert.ToString(Item["loginName"]);
                                itemis.Status = Convert.ToString(Item["Status"]);
                                itemis.CloseTheQuestion = Convert.ToString(Item["CloseTheQuestion"]);
                                itemis.EmployeeName = Convert.ToString(Item["EmployeeName"]);
                                itemis.EmployeePosition = Convert.ToString(Item["EmployeePosition"]);
                                itemis.EmployeeLoginName = new SPFieldUserValue(oWeb, Convert.ToString(Item["EmployeeLoginName"]));
                                itemis.Created = Convert.ToDateTime(Item["Created"]);
                                itemis.CreatedBy = new SPFieldUserValue(oWeb, Convert.ToString(Item["Author"]));


                            }
                        }

                    }
                }
            });
            return itemis;
        }

        public List<AskAnExpertEntity> GetAskAnExpert(int intRowLimit, string Departmentvalue, string Titlevalue)
        {
            List<AskAnExpertEntity> ItemsCollection = new List<AskAnExpertEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.AskAnExpertUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where>";
                                if (Departmentvalue != "")
                                {
                                    camlquery1 += "<And>";
                                }
                                if (Titlevalue != "")
                                {
                                    camlquery1 += "<And>";
                                }   
                                camlquery1 += "<Geq><FieldRef Name='ID' /><Value Type='Number'>0</Value> </Geq>";

                                if (Departmentvalue != "")
                                {
                                    camlquery1 += "<Contains><FieldRef Name='Department'/><Value Type='Text'>" + Departmentvalue + "</Value></Contains></And>";
                                }
                                if (Titlevalue != "")
                                {
                                    camlquery1 += "<Contains><FieldRef Name='QuestionTitle'/><Value Type='Text'>" + Titlevalue + "</Value></Contains></And>";
                                }
                                camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;
                                if (intRowLimit != 0)
                                    qry1.RowLimit = (uint)intRowLimit;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    AskAnExpertEntity itemis = new AskAnExpertEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.QuestionTitle = Convert.ToString(Item["QuestionTitle"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.Department = Convert.ToString(Item["Department"]);
                                    itemis.ExpertID = Convert.ToString(Item["ExpertID"]);

                                    itemis.QuestionDetails = Convert.ToString(Item["QuestionDetails"]);
                                    itemis.loginName = Convert.ToString(Item["loginName"]);
                                    itemis.Status = Convert.ToString(Item["Status"]);
                                                                    
                                  itemis.EmployeeName = Convert.ToString(Item["EmployeeName"]);
                                    itemis.EmployeePosition = Convert.ToString(Item["EmployeePosition"]);
                                     itemis.EmployeeLoginName = new SPFieldUserValue(oWeb, Convert.ToString(Item["EmployeeLoginName"]));
                                    itemis.Created = Convert.ToDateTime(Item["Created"]);
                                    ItemsCollection.Add(itemis);


                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

        public List<AskAnExpertAnswerEntity> GetAskAnExpertAnswerByID(int AskAnExpertID)
        {
            List<AskAnExpertAnswerEntity> ItemsCollection = new List<AskAnExpertAnswerEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.AskAnExpertAnswerUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where>";                                
                                camlquery1 += "<Eq><FieldRef Name='AskAnExpertID' /><Value Type='Text'>" + AskAnExpertID + "</Value> </Eq>";
                                camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                qry1.Query = camlquery1;                               
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    AskAnExpertAnswerEntity itemis = new AskAnExpertAnswerEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.Answer = Convert.ToString(Item["Answer"]);
                                    itemis.AskAnExpertID = Convert.ToString(Item["AskAnExpertID"]);
                                    itemis.ExpertName = Convert.ToString(Item["ExpertName"]);
                                    itemis.ExpertLoginName = Convert.ToString(Item["ExpertLoginName"]);
                                    itemis.ExpertPosition = Convert.ToString(Item["ExpertPosition"]);
                                    itemis.Created = Convert.ToDateTime(Item["Created"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

        public bool Resend(int id)
        {
            bool isFormSaved = false;
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.AskAnExpertUrl);
                        SPListItem item = null;                      
                            item = list.GetItemById(id);                     
                        item["StartWF"] ="1";
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
        public bool CloseTheQuestion(int id)
        {
            bool isFormSaved = false;
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.AskAnExpertUrl);
                        SPListItem item = null;                      
                            item = list.GetItemById(id);                     
                        item["CloseTheQuestion"] ="1";
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

          public bool AddOrUpdate(AskAnExpertEntity Item)
        {
            bool isFormSaved = false;

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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.AskAnExpertUrl);
                        SPListItem item = null;
                        if (Item.ID > 0)
                        {
                            item = list.GetItemById(Item.ID);

                        }
                        else
                        {
                            item = list.AddItem();
                        }
                        item["Department"] = Item.Department;

                        item["EmployeeLoginName"] = currentUser;
                        item["EmployeeName"] = Item.EmployeeName;
                        item["EmployeePosition"] = Item.EmployeePosition;
                        item["ExpertID"] = Item.ExpertID;
                        item["loginName"] = Item.loginName;
                        item["QuestionDetails"] = Item.QuestionDetails;
                        item["Title"] = Item.Title;
                        item["StartWF"] = Item.StartWF;
                        item["QuestionTitle"] = Item.QuestionTitle;
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

        public bool AddOrUpdateAskAnExpertAnswer(AskAnExpertAnswerEntity Item)
        {
            bool isFormSaved = false;

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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.AskAnExpertAnswerUrl);
                        SPListItem item = null;
                        if (Item.ID > 0)
                        {
                            item = list.GetItemById(Item.ID);

                        }
                        else
                        {
                            item = list.AddItem();
                        }
                        item["Answer"] = Item.Answer;
                        item["AskAnExpertID"] = Item.AskAnExpertID;
                        item["ExpertLoginName"] = Item.ExpertLoginName;
                        item["ExpertName"] = Item.ExpertName;
                        item["ExpertPosition"] = Item.ExpertPosition;
                        item["Title"] = Item.Title;
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





    }
}
