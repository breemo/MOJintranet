using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Collections;
using MOJ.Business;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;


namespace MOJ.DataManager
{
    public class TaskDataManager
    {
        #region HostingRequest
        public bool AddOrUpdateHostingRequest(TaskEntity HostingRequestItem)
        {           
            bool isUpdate = false;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        try
                        {
                            web.AllowUnsafeUpdates = true;
                            SPList list = web.GetListFromUrl(web.Url + HostingRequestItem.RequestURL);
                            SPListItem item = null;                            
                                item = list.GetItemById(Convert.ToInt32(HostingRequestItem.RequestID));
                            SPWorkflowTask taskedit = null;
                            SPWorkflowTaskCollection taskCollection = new SPWorkflowTaskCollection(item, new SPWorkflowFilter());
                            foreach (SPWorkflowTask task in taskCollection)
                            {
                                if (task[task.Fields["Status"].InternalName].ToString() != "Completed")
                                {
                                        taskedit = task;
                                        Hashtable ht = new Hashtable();
                                        ht["Completed"] = "true";
                                        ht["Status"] = "Completed";
                                        ht["PercentComplete"] = 1.0f;
                                        ht["TaskStatus"] = HostingRequestItem.WorkflowOutcome;
                                        ht["Comment"] = HostingRequestItem.Comment;
                                    ht["AnswerBy"] = SPContext.Current.Web.CurrentUser;
                                    SPWorkflowTask.AlterTask((taskedit as SPListItem), ht, true);

                                }
                            }
                            web.AllowUnsafeUpdates = true;
                            isUpdate = true;
                        }
                        catch (Exception ex)
                        {
                            isUpdate = false;
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
            return isUpdate;
        }

        public TaskEntity GetTaskByID(int id)
        {
            TaskEntity task = new TaskEntity();
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
                                SPList lsttask = oWeb.GetListFromUrl(oSite.Url + SharedConstants.WorkflowTasksUrl);
                                if (lsttask != null)
                                {
                                    SPListItem Item = lsttask.GetItemById(id);
                                    task.Title = Convert.ToString(Item["Title"]);
                                    task.id = id;
                                    task.WorkflowOutcome = Convert.ToString(Item["WorkflowOutcome"]);
                                    SPFieldUrlValue spfvRequest = new SPFieldUrlValue(Item["WorkflowLink"].ToString());
                                    String Requestlink = Convert.ToString(spfvRequest.Url);
                                    string[] Request = Requestlink.Split(new string[] { "ID=" }, StringSplitOptions.None);
                                    task.RequestID = Convert.ToString(Request[1]);
                                    task.WorkflowName = Convert.ToString(Item["WorkflowName"]);
                                    task.Status = Convert.ToString(Item["Status"]);
                                    task.PercentComplete = Convert.ToString(Item["PercentComplete"]);
                                    task.Comment = Convert.ToString(Item["Comment"]);                                  
                                    SPFieldUserValueCollection itemAssignedTo = new SPFieldUserValueCollection(Item.Web.Site.RootWeb, Item["AssignedTo"].ToString());
                                    task.AssignedTo = itemAssignedTo;
                                    //add if add new workflow in new list
                                    if (Convert.ToString(Item["WorkflowName"])== "RoomBooking")
                                    {
                                        task.RequestURL = SharedConstants.RoomBookingUrl;
                                    }
                                    if (Convert.ToString(Item["WorkflowName"]) == "AffirmationSocialSituationWF")
                                    {
                                        task.RequestURL = SharedConstants.AffirmationSocialSituationUrl;
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
            return task;
        }
        public List<TaskEntity> GetMyTask()
        {
           
            List<TaskEntity> TaskCollection = new List<TaskEntity>();
           
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {

                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lsttask = oWeb.GetListFromUrl(oSite.Url + SharedConstants.WorkflowTasksUrl);//oWeb.Lists["Workflow Tasks"];//
                                if (lsttask != null)
                                {
                                    SPQuery qry1 = new SPQuery();
                                    string camlquery1 = "<Where></Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";
                                    qry1.Query = camlquery1;
                                    SPListItemCollection listItemsCollection1 = lsttask.GetItems(qry1);
                                    foreach (SPListItem Item in listItemsCollection1)
                                    {
                                        SPFieldUserValueCollection itemAssignedTo = new SPFieldUserValueCollection(Item.Web.Site.RootWeb, Item["AssignedTo"].ToString());
                                        foreach (SPFieldUserValue singlevalue in itemAssignedTo)
                                        {
                                            if (singlevalue.User == null) // value is a SharePoint group if User is null
                                            {
                                                SPGroup group = oWeb.Groups[singlevalue.LookupValue];
                                                SPUser user = SPContext.Current.Web.CurrentUser;
                                                bool userExsists = user.Groups.Cast<SPGroup>().Any(g => g.Name.ToLower() == group.Name.ToLower());
                                                if (userExsists)
                                                {
                                                    TaskEntity task = new TaskEntity();
                                                    task.Title = Convert.ToString(Item["Title"]);
                                                    task.id = Convert.ToInt32(Item["ID"]);
                                                    task.WorkflowOutcome = Convert.ToString(Item["WorkflowOutcome"]);
                                                    task.WorkflowName = Convert.ToString(Item["WorkflowName"]);
                                                    task.Status = Convert.ToString(Item["Status"]);
                                                    task.Comment = Convert.ToString(Item["Comment"]);
                                                    task.Created = Convert.ToDateTime(Item["Created"]);                                                 
                                                    SPFieldUrlValue spfvRequest = new SPFieldUrlValue(Item["WorkflowLink"].ToString());
                                                    String Requestlink = Convert.ToString(spfvRequest.Url);
                                                    string[] Request = Requestlink.Split(new string[] { "ID=" }, StringSplitOptions.None);
                                                    task.RequestID = Convert.ToString(Request[1]);
                                                    task.RequestName = Convert.ToString(spfvRequest.Description);
                                                    task.TaskURL = "ViewTask.aspx?TID=" + Convert.ToInt32(Item["ID"]);
                                                    TaskCollection.Add(task);
                                                }
                                            }
                                            else
                                            {
                                                string currentUser = SPContext.Current.Web.CurrentUser.Name.ToLower();
                                                string singlevalueis = singlevalue.User.Name.ToLower();
                                                if (singlevalueis.Equals(currentUser))
                                                {
                                                    TaskEntity task = new TaskEntity();
                                                    task.Title = Convert.ToString(Item["Title"]);
                                                    task.id = Convert.ToInt32(Item["ID"]);
                                                    task.WorkflowOutcome = Convert.ToString(Item["WorkflowOutcome"]);
                                                    task.WorkflowName = Convert.ToString(Item["WorkflowName"]);
                                                    task.Status = Convert.ToString(Item["Status"]);
                                                    task.Comment = Convert.ToString(Item["Comment"]);
                                                    task.Created = Convert.ToDateTime(Item["Created"]);
                                                    SPFieldUrlValue spfvRequest = new SPFieldUrlValue(Item["WorkflowLink"].ToString());
                                                    String Requestlink = Convert.ToString(spfvRequest.Url);
                                                    string[] Request = Requestlink.Split(new string[] { "ID=" }, StringSplitOptions.None);
                                                    task.RequestID = Convert.ToString(Request[1]);
                                                    task.RequestName = Convert.ToString(spfvRequest.Description);
                                                    task.TaskURL = "ViewTask.aspx?TID=" + Convert.ToInt32(Item["ID"]);
                                                    TaskCollection.Add(task);

                                                }

                                            }

                                        }

                                    }

                                }
                            }

                        }
                    }
                });
                     return TaskCollection;
        }
        public bool TaskPermission(int Tid)
        {
            bool Result = false;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lsttask = oWeb.GetListFromUrl(oSite.Url + SharedConstants.WorkflowTasksUrl);//oWeb.Lists["Workflow Tasks"];//
                            if (lsttask != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='ID'/> <Value Type='Counter'>"+ Tid + "</Value></Eq></Where>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lsttask.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    SPFieldUserValueCollection itemAssignedTo = new SPFieldUserValueCollection(Item.Web.Site.RootWeb, Item["AssignedTo"].ToString());
                                    foreach (SPFieldUserValue singlevalue in itemAssignedTo)
                                    {
                                        if (singlevalue.User == null) // value is a SharePoint group if User is null
                                        {
                                            SPGroup group = oWeb.Groups[singlevalue.LookupValue];
                                            SPUser user = SPContext.Current.Web.CurrentUser;
                                            bool userExsists = user.Groups.Cast<SPGroup>().Any(g => g.Name.ToLower() == group.Name.ToLower());
                                            if (userExsists)
                                            {
                                                Result = true;
                                            }
                                        }
                                        else
                                        {
                                            string currentUser = SPContext.Current.Web.CurrentUser.Name.ToLower();
                                            string singlevalueis = singlevalue.User.Name.ToLower();
                                            if (singlevalueis.Equals(currentUser))
                                            {
                                                
                                                Result = true;

                                            }

                                        }

                                    }

                                }

                            }
                        }

                    }
                }
            });
            return Result;
        }
        #endregion
    }
}
