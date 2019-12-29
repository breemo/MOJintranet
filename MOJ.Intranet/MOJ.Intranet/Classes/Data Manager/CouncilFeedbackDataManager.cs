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
    public class CouncilFeedbackDataManager
    {
        public bool AddOrUpdateknowledgeCouncil(CouncilFeedbackEntity Item)
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
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.CouncilFeedbackUrl);
                        SPListItem item = null;
                        if (Item.ID > 0)
                        {
                            item = list.GetItemById(Item.ID);
                            isUpdate = true;
                        }
                        else
                        {
                            item = list.AddItem();
                        }
                       
                        item["DevelopmentProposalsForCouncil"] = Item.DevelopmentProposalsForCouncil;
                        item["knowledgeCouncilID"] = Item.knowledgeCouncilID;
                        item["loginName"] = Item.loginName;
                        item["SubjectCouncilCanBeDone"] = Item.SubjectCouncilCanBeDone;
                        item["TheBenefitFromTheCouncil"] = Item.TheBenefitFromTheCouncil;
                        
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


     
       public CouncilFeedbackEntity GetPlannedCouncils(CouncilFeedbackEntity obj)
        {
            CouncilFeedbackEntity itemis = new CouncilFeedbackEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.CouncilFeedbackUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><And>";                               
                                camlquery1 += "<Eq><FieldRef Name='loginName'></FieldRef><Value Type='Text'>" + obj.loginName + "</Value></Eq>";
                                
                                  camlquery1 += "<Eq><FieldRef Name ='knowledgeCouncilID'/><Value Type='Text'>" + obj.knowledgeCouncilID + "</Value></Eq></And>";
                                   camlquery1 += "</Where><OrderBy><FieldRef Name='ID' Ascending='false' /></OrderBy>";

                                qry1.Query = camlquery1;     
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.DevelopmentProposalsForCouncil = Convert.ToString(Item["DevelopmentProposalsForCouncil"]);
                                    itemis.knowledgeCouncilID = Convert.ToString(Item["knowledgeCouncilID"]);
                                    itemis.loginName = Convert.ToString(Item["loginName"]);
                                    itemis.SubjectCouncilCanBeDone = Convert.ToString(Item["SubjectCouncilCanBeDone"]);
                                    itemis.TheBenefitFromTheCouncil = Convert.ToString(Item["TheBenefitFromTheCouncil"]);
                                 
                                }

                            }
                        }

                    }
                }
            });
            return itemis;
        }


       


    }
}
