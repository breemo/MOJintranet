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
        public bool UpdatePassPercentage(knowledgeCouncilEntity knowledgeCouncilItem)
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
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.knowledgeCouncilUrl);
                        SPListItem item = null;                        
                            item = list.GetItemById(knowledgeCouncilItem.ID);                 
                       
                        item["PassPercentage"] = knowledgeCouncilItem.PassPercentage;                        
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


        public bool AddOrUpdateCouncilExamAnswer(List<CouncilExamAnswerEntity> lItemsList)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.CouncilExamAnswerUrl);
                        foreach (CouncilExamAnswerEntity lItems in lItemsList) { 
                            SPListItem item = null;
                        if (lItems.ID > 0)
                        {
                            item = list.GetItemById(lItems.ID);
                            isUpdate = true;
                        }
                        else
                        {
                            item = list.AddItem();
                        }

                        item["Answer"] = lItems.Answer;
                        item["AnswerID"] = lItems.AnswerID;
                        item["ExamID"] = lItems.ExamID;
                        item["knowledgeCouncilID"] = lItems.knowledgeCouncilID;
                        item["loginName"] = lItems.loginName;
                        item["Question"] = lItems.Question;
                        item["Result"] = lItems.Result;

                        item.Update();
                    }

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

          public bool AddOrUpdateCouncilExaminers(CouncilExaminersEntity Items)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.CouncilExaminersUrl);
                        SPListItem item = null;
                        if (Items.ID > 0)
                        {
                            item = list.GetItemById(Items.ID);
                            isUpdate = true;
                        }
                        else
                        {
                            item = list.AddItem();
                        }
                       
                        item["knowledgeCouncilID"] = Items.knowledgeCouncilID;
                        item["knowledgeCouncil"] = Items.knowledgeCouncil;
                        item["loginName"] = Items.loginName;
                        item["percentage"] = Items.percentage;
                        item["Resalt"] = Items.Resalt;
                        //item["Resalt"] = Items.;
                       
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

        public bool DeleteitemsFromSublist(string listname, List<int> listsid)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        oWeb.AllowUnsafeUpdates = true;
                        SPList lst = oWeb.GetListFromUrl(oSite.Url + "/Lists/" + listname + "/AllItems.aspx");
                        foreach (int listItemId in listsid)
                        {
                            SPListItem itemToDelete = lst.GetItemById(listItemId);
                            itemToDelete.Delete();
                        }
                        oWeb.AllowUnsafeUpdates = false;
                    }
                }
            });
            return true;
        }
        public bool SaveUpdateParticipantsCouncil(List<ParticipantsCouncilEntity> Items)
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
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ParticipantsCouncilUrl);
                        SPListItem item = null;
                        foreach (ParticipantsCouncilEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["JobTitle"] = Item.JobTitle;
                            item["JobTitleEN"] = Item.JobTitleEN;
                            item["knowledgeCouncil"] = Item.knowledgeCouncil;
                            item["Name"] = Item.Name;
                            item["NameEN"] = Item.NameEN;
                            item["Role"] = Item.Role;
                            item["RoleEN"] = Item.RoleEN;
                            item.Update();
                        }
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




        public int AddOrUpdateknowledgeCouncil(knowledgeCouncilEntity knowledgeCouncilItem)
        {
            int itemID = 0;
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
                        item["CouncilDescription"] = knowledgeCouncilItem.CouncilDescription;
                        item["CouncilDescriptionEN"] = knowledgeCouncilItem.CouncilDescriptionEN;
                        item["CouncilGoals"] = knowledgeCouncilItem.CouncilGoals;
                        item["CouncilGoalsEN"] = knowledgeCouncilItem.CouncilGoalsEN;
                        item["CouncilType"] = knowledgeCouncilItem.CouncilType;
                        item["Department"] = knowledgeCouncilItem.Department;                       
                        item["DirectManager"] = knowledgeCouncilItem.DirectManager;
                        item["TargetGroup"] = knowledgeCouncilItem.TargetGroup;
                        item["EmployeeName"] = knowledgeCouncilItem.EmployeeName;
                        item["EmployeeNumber"] = knowledgeCouncilItem.EmployeeNumber;
                        item["JoiningConditions"] = knowledgeCouncilItem.JoiningConditions;
                        item["Designation"] = knowledgeCouncilItem.Designation;
                        item["Lecturer"] = knowledgeCouncilItem.Lecturer;
                        item["LecturerEN"] = knowledgeCouncilItem.LecturerEN;
                        item.Update();
                         itemID= item.ID;
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
            return itemID;
        }


        public CouncilExaminersEntity GeCouncilExaminersByID(int id , string loginname)
        {
            CouncilExaminersEntity itemis = new CouncilExaminersEntity();
            itemis.ID = 0;
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CouncilExaminersUrl);
                                if (lst != null)
                                {

                                    SPQuery qry1 = new SPQuery();
                                    string camlquery1 = "<Where><And>";
                                    camlquery1 += "<Eq><FieldRef Name='loginName'/><Value Type='Text'>" + loginname + "</Value></Eq>";
                                    camlquery1 += "<Eq><FieldRef Name='knowledgeCouncilID'/><Value Type='Text'>" + id + "</Value></Eq></And>";
                                    camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";

                                    qry1.Query = camlquery1;
                                    SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                    foreach (SPListItem Item in listItemsCollection1)
                                    {
                                        itemis.ID = Convert.ToInt32(Item["ID"]);
                                        itemis.knowledgeCouncilID = Convert.ToInt32(Item["knowledgeCouncilID"]);
                                        itemis.loginName = Convert.ToString(Item["loginName"]);
                                        itemis.percentage = Convert.ToString(Item["percentage"]);
                                        itemis.Resalt = Convert.ToString(Item["Resalt"]);

                                        SPFieldLookupValue fieldLookupValue = new SPFieldLookupValue(Item["knowledgeCouncilID"].ToString());
                                        int lookupID = fieldLookupValue.LookupId;
                                        itemis.knowledgeCouncil = lookupID;
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
            return itemis;
        }
        public CouncilExamEntity GeCouncilExamByID(int id)
        {
            CouncilExamEntity itemis = new CouncilExamEntity();
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CouncilExamUrl);
                                if (lst != null)
                                {                                  

                                    SPListItem Item = lst.GetItemById(id);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.Answer = Convert.ToInt32(Item["Answer"]);
                                    itemis.possibility1 = Convert.ToString(Item["possibility1"]);
                                    itemis.possibility2 = Convert.ToString(Item["possibility2"]);
                                    itemis.possibility3 = Convert.ToString(Item["possibility3"]);
                                    itemis.possibility4 = Convert.ToString(Item["possibility4"]);
                                    itemis.Question = Convert.ToString(Item["Question"]);
                                    itemis.QuestionEN = Convert.ToString(Item["QuestionEN"]);
                                    itemis.possibilityEN1 = Convert.ToString(Item["possibilityEN1"]);
                                    itemis.possibilityEN2 = Convert.ToString(Item["possibilityEN2"]);
                                    itemis.possibilityEN3 = Convert.ToString(Item["possibilityEN3"]);
                                    itemis.possibilityEN4 = Convert.ToString(Item["possibilityEN4"]);
                                    SPFieldLookupValue fieldLookupValue = new SPFieldLookupValue(Item["knowledgeCouncilID"].ToString());
                                    int lookupID = fieldLookupValue.LookupId;
                                    itemis.knowledgeCouncilID = lookupID;
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
            return itemis;
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
                                     obitem.CouncilDescription = Convert.ToString(item["CouncilDescription"]);
                                     obitem.CouncilDescriptionEN = Convert.ToString(item["CouncilDescriptionEN"]);
                                     obitem.CouncilGoals = Convert.ToString(item["CouncilGoals"]);
                                     obitem.CouncilGoalsEN = Convert.ToString(item["CouncilGoalsEN"]);
                                     obitem.CouncilType = Convert.ToString(item["CouncilType"]);
                                     obitem.Department= Convert.ToString(item["Department"]);                                    
                                    obitem.DirectManager = Convert.ToString(item["DirectManager"]);
                                    obitem.TargetGroup = Convert.ToString(item["TargetGroup"]);
                                     obitem.EmployeeName= Convert.ToString(item["EmployeeName"]);
                                     obitem.EmployeeNumber= Convert.ToString(item["EmployeeNumber"]);
                                     obitem.JoiningConditions= Convert.ToString(item["JoiningConditions"]);
                                     obitem.Designation = Convert.ToString(item["Designation"]);
                                     obitem.Lecturer = Convert.ToString(item["Lecturer"]);
                                     obitem.LecturerEN = Convert.ToString(item["LecturerEN"]);
                                     obitem.Status = Convert.ToString(item["Status"]);
                                     obitem.CouncilNo = Convert.ToInt32(item["CouncilNo"]);

                                    if (!string.IsNullOrEmpty(Convert.ToString(item["PassPercentage"])))
                                    {
                                        obitem.PassPercentage = Convert.ToInt32(item["PassPercentage"]);
                                    }
                                    else
                                    {
                                        obitem.PassPercentage = 50;
                                    }

                                    SPAttachmentCollection attchmentcollection = item.Attachments;
                                    string URLatt = "";
                                    int conter = 0;
                                    foreach (var itematt in attchmentcollection)
                                    {
                                        if (conter == attchmentcollection.Count - 1)
                                        {
                                            URLatt += attchmentcollection.UrlPrefix + itematt;
                                            
                                        }
                                        else
                                        {
                                            URLatt += attchmentcollection.UrlPrefix + itematt + "#";
                                        }
                                        conter++;
                                    }
                                    
                                    obitem.URLAttachments = URLatt;
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


        public List<ParticipantsCouncilEntity> GetParticipants(string title)
        {
            List<ParticipantsCouncilEntity> ItemsCollection = new List<ParticipantsCouncilEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ParticipantsCouncilUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='knowledgeCouncil'  LookupId='TRUE' /> <Value Type='Lookup'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    ParticipantsCouncilEntity itemis = new ParticipantsCouncilEntity();                                    
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.knowledgeCouncil = Convert.ToInt32(title);
                                    itemis.JobTitle = Convert.ToString(Item["JobTitle"]); ;
                                    itemis.JobTitleEN = Convert.ToString(Item["JobTitleEN"]);
                                    itemis.Name = Convert.ToString(Item["Name"]);
                                    itemis.NameEN = Convert.ToString(Item["NameEN"]);
                                    itemis.Role = Convert.ToString(Item["Role"]);
                                    itemis.RoleEN = Convert.ToString(Item["RoleEN"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }


        public CouncilExamAnswerEntity GetCouncilExamAnswer(int ckID ,string loginName)
        {
            CouncilExamAnswerEntity ItemsCollection = new CouncilExamAnswerEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CouncilExamAnswerUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where>";
                                camlquery1 += "<And><Eq><FieldRef Name='loginName' ></FieldRef><Value Type='Text'>" + loginName + "</Value></Eq>";

                                camlquery1 += "<Eq><FieldRef Name='ExamID' ></FieldRef><Value Type='Text'>" + ckID + "</Value></Eq>";
                                camlquery1 += "</And></Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    ItemsCollection.ID = Convert.ToInt32(Item["ID"]);
                                    ItemsCollection.Answer = Convert.ToString(Item["Answer"]);
                                    ItemsCollection.AnswerID = Convert.ToString(Item["AnswerID"]);
                                    ItemsCollection.ExamID = Convert.ToString(Item["ExamID"]);
                                    ItemsCollection.knowledgeCouncilID = Convert.ToString(Item["knowledgeCouncilID"]);
                                    ItemsCollection.loginName = Convert.ToString(Item["loginName"]);
                                    ItemsCollection.Question = Convert.ToString(Item["Question"]);
                                    ItemsCollection.Result = Convert.ToInt32(Item["Result"]);
                                }
                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

         public List<CouncilExamEntity> GetCouncilExam(int ckID)
        {
            List<CouncilExamEntity> ItemsCollection = new List<CouncilExamEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CouncilExamUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where>";                               
                                camlquery1 += "<Eq><FieldRef Name='knowledgeCouncilID' LookupId='TRUE'></FieldRef><Value Type='Lookup'>" + ckID + "</Value></Eq>";                                
                                  camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                qry1.Query = camlquery1;  
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    CouncilExamEntity itemis = new CouncilExamEntity();
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.knowledgeCouncilID = ckID;
                                    itemis.Answer = Convert.ToInt32(Item["Answer"]);
                                    itemis.possibility1 = Convert.ToString(Item["possibility1"]);
                                    itemis.possibility2 = Convert.ToString(Item["possibility2"]);
                                    itemis.possibility3 = Convert.ToString(Item["possibility3"]);
                                    itemis.possibility4 = Convert.ToString(Item["possibility4"]);
                                    itemis.Question = Convert.ToString(Item["Question"]);
                                    itemis.QuestionEN = Convert.ToString(Item["QuestionEN"]);
                                    itemis.possibilityEN1 = Convert.ToString(Item["possibilityEN1"]);
                                    itemis.possibilityEN2 = Convert.ToString(Item["possibilityEN2"]);
                                    itemis.possibilityEN3 = Convert.ToString(Item["possibilityEN3"]);
                                    itemis.possibilityEN4 = Convert.ToString(Item["possibilityEN4"]);

                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
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
                                    itemis.CouncilDescription = Convert.ToString(Item["CouncilDescription"]);
                                    itemis.CouncilDescriptionEN = Convert.ToString(Item["CouncilDescriptionEN"]);
                                    itemis.CouncilGoals = Convert.ToString(Item["CouncilGoals"]);
                                    itemis.CouncilGoalsEN = Convert.ToString(Item["CouncilGoalsEN"]);
                                    itemis.CouncilType = Convert.ToString(Item["CouncilType"]);
                                    itemis.Department = Convert.ToString(Item["Department"]);                                  
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.DirectManager = Convert.ToString(Item["DirectManager"]);
                                    itemis.TargetGroup = Convert.ToString(Item["TargetGroup"]);
                                    itemis.EmployeeName = Convert.ToString(Item["EmployeeName"]);
                                    itemis.EmployeeNumber = Convert.ToString(Item["EmployeeNumber"]);
                                    itemis.JoiningConditions = Convert.ToString(Item["JoiningConditions"]);
                                    itemis.Lecturer = Convert.ToString(Item["Lecturer"]);
                                    itemis.LecturerEN = Convert.ToString(Item["LecturerEN"]);
                                    CouncilMembersEntity Citem = new CouncilMembers().GetMemberID(Convert.ToInt32(Item["ID"]), username);
                                    itemis.Status = "join";
                                    itemis.RequestURL = "href='CouncilMembers.aspx?TID=" + Convert.ToInt32(Item["ID"]) + "&Title=" + Convert.ToString(Item["CouncilTopic"]) + "'";

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
                                               // itemis.Status = "موافق";
                                                itemis.Status = "شارك";
                                                itemis.RequestURL = "";


                                            }
                                            if (Citem.Status == "Rejected")
                                            {
                                                //  itemis.Status = "مرفوض";
                                                itemis.Status = "شارك";
                                                itemis.RequestURL = "";

                                            }
                                            if (Citem.Status == "Pending")
                                            {
                                                // itemis.Status = "معلق";
                                                itemis.Status = "شارك";
                                                itemis.RequestURL = "";

                                            }

                                        }


                                    }
                                    else
                                    {
                                        if (Citem.ID != 0)
                                        {
                                            if (Citem.Status == "Approved")
                                            {
                                                // itemis.Status = "موافق";
                                                itemis.Status = "Participated";
                                                itemis.RequestURL = "";

                                            }
                                            if (Citem.Status == "Rejected")
                                            {
                                                //  itemis.Status = "مرفوض";
                                                itemis.Status = "Participated";
                                                itemis.RequestURL = "";

                                            }
                                            if (Citem.Status == "Pending")
                                            {
                                                // itemis.Status = "معلق";
                                                itemis.Status = "Participated";
                                                itemis.RequestURL = "";

                                            }

                                        }


                                    }

                                   
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
                                    itemis.CouncilDescription = Convert.ToString(Item["CouncilDescription"]);
                                    itemis.CouncilDescriptionEN = Convert.ToString(Item["CouncilDescriptionEN"]);
                                    itemis.CouncilGoals = Convert.ToString(Item["CouncilGoals"]);
                                    itemis.CouncilGoalsEN = Convert.ToString(Item["CouncilGoalsEN"]);
                                    itemis.CouncilType = Convert.ToString(Item["CouncilType"]);
                                    itemis.Department = Convert.ToString(Item["Department"]);                                   
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.DirectManager = Convert.ToString(Item["DirectManager"]);
                                    itemis.TargetGroup = Convert.ToString(Item["TargetGroup"]);
                                    itemis.EmployeeName = Convert.ToString(Item["EmployeeName"]);
                                    itemis.EmployeeNumber = Convert.ToString(Item["EmployeeNumber"]);
                                    itemis.JoiningConditions = Convert.ToString(Item["JoiningConditions"]);
                                    itemis.Lecturer = Convert.ToString(Item["Lecturer"]);
                                    itemis.LecturerEN = Convert.ToString(Item["LecturerEN"]);
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
