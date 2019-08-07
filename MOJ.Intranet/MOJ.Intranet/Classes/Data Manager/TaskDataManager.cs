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
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.RoomBookingUrl);
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
                                    SPFieldUrlValue spfvRequest = new SPFieldUrlValue(Item["WorkflowLink"].ToString()); String Requestlink = Convert.ToString(spfvRequest.Url);
                                    string[] Request = Requestlink.Split(new string[] { "ID=" }, StringSplitOptions.None);task.RequestID = Convert.ToString(Request[1]);
                                    task.WorkflowName = Convert.ToString(Item["WorkflowName"]);                                    
                                    task.Status = Convert.ToString(Item["Status"]);
                                    task.PercentComplete = Convert.ToString(Item["PercentComplete"]);
                                    task.Comment = Convert.ToString(Item["Comment"]);
                                    task.AssignedTo= (SPFieldUserValueCollection)Item["AssignedTo"];
                                  
                                    //add if add new workflow in new list
                                    if (Convert.ToString(Item["WorkflowName"])== "RoomBooking")
                                    {
                                        task.RequestURL = SharedConstants.RoomBookingUrl;
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


        #endregion
    }
}
