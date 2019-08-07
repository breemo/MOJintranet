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
            bool isFormSaved = false;
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
                            SPList list = web.GetListFromUrl(web.Url + SharedConstants.WorkflowTasksUrl);
                            SPListItem item = null;

                            //if (HostingRequestItem.Id > 0)
                            //{
                                item = list.GetItemById(10);
                                isUpdate = true;
                            //}
                            //else
                            //{
                            //    item = list.AddItem();
                            //}
                            
                           SPWorkflowTask taskedit = null;
                           SPWorkflowTask task = item.Tasks[Convert.ToInt32(HostingRequestItem.Id)];
                           taskedit = task;                             
                           if (taskedit == null)   // no matching task
                              return;                              
                           // alter the task
                           Hashtable ht = new Hashtable();
                           ht["TaskStatus"] = "#";    // Mark the entry as approved
                           SPWorkflowTask.AlterTask((taskedit as SPListItem), ht, true);




                            //item["Comment"] = HostingRequestItem.Comment;                          
                            //item["WorkflowOutcome"] = HostingRequestItem.WorkflowOutcome;
                            //item["Status"] = HostingRequestItem.Status;
                            //item.Update();
                            
                            //list.Update();
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
            });
            return isFormSaved;
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
                        //using (SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl))
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lsttask = oWeb.GetListFromUrl(oSite.Url + SharedConstants.WorkflowTasksUrl);
                                if (lsttask != null)
                                {
                                    SPListItem Item = lsttask.GetItemById(id);
                                    task.Title = Convert.ToString(Item["Title"]);
                                    task.Id = id;
                                    task.WorkflowOutcome = Convert.ToString(Item["WorkflowOutcome"]);
                                    SPFieldUrlValue spfvRequest = new SPFieldUrlValue(Item["WorkflowLink"].ToString()); String Requestlink = Convert.ToString(spfvRequest.Url);
                                    string[] Request = Requestlink.Split(new string[] { "ID=" }, StringSplitOptions.None);task.RequestID = Convert.ToString(Request[1]);
                                    task.WorkflowName = Convert.ToString(Item["WorkflowName"]);
                                    task.Status = Convert.ToString(Item["Status"]);
                                    task.PercentComplete = Convert.ToString(Item["PercentComplete"]);
                                    task.Comment = Convert.ToString(Item["Comment"]);

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



        //public void AddAttendees(RoomBookingEntity HostingRequestItem, bool isUpdate, SPWeb web)
        //{
        //    //SPList formFAuditTeam = web.Lists[ListTitles.FormFAuditTeam];
        //    //SPList formFComponents = web.Lists[ListTitles.FormFComponents];
        //    SPList list = web.GetListFromUrl(web.Url + SharedConstants.HostingRequestUrl);

        //    if (isUpdate)
        //    {
        //        if (formFAuditTeam != null)
        //        {
        //            List<Guid> result = (from SPListItem item in formFAuditTeam.Items
        //                                 where new SPFieldLookupValue(Convert.ToString(item["FormFID"])).LookupId.Equals(formF.Id)
        //                                 select item.UniqueId).ToList();

        //            foreach (Guid deleteItemId in result)
        //                formFAuditTeam.GetItemByUniqueId(deleteItemId).Delete();

        //            formFAuditTeam.Update();
        //        }

        //        if (formFComponents != null)
        //        {
        //            List<Guid> result = (from SPListItem item in formFComponents.Items
        //                                 where new SPFieldLookupValue(Convert.ToString(item["FormFID"])).LookupId.Equals(formF.Id)
        //                                 select item.UniqueId).ToList();

        //            foreach (Guid deleteItemId in result)
        //                formFComponents.GetItemByUniqueId(deleteItemId).Delete();

        //            formFComponents.Update();
        //        }
        //    }

        //    foreach (AuditMember member in formF.AuditTeam)
        //    {
        //        SPListItem teamItem = formFAuditTeam.AddItem();
        //        teamItem["Title"] = member.MemberName;
        //        teamItem["RegistrationNumber"] = member.MemberRegNo; //formF.Id;                
        //        teamItem["FormFID"] = formF.Id + ";#" + formF.Id;
        //        teamItem.Update();
        //    }

        //    foreach (FormFComponent comp in formF.Components)
        //    {
        //        SPListItem component = formFComponents.AddItem();
        //        component["Major"] = comp.MajorCount;
        //        component["Minor"] = comp.MinorCount;
        //        component["ComponentID"] = comp.Id;
        //        component["FormFID"] = formF.Id + ";#" + formF.Id;
        //        component.Update();
        //    }

        //    isUpdateComplete = true;
        //    return isUpdateComplete;
        //}
        #endregion
    }
}
