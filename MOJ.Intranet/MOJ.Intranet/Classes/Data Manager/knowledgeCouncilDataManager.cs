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
                                     obitem.Status = Convert.ToString(item["Status"]);

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



    }
}
