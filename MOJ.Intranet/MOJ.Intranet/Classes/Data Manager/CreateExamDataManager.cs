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
using MOJ.Entities.ImplicitKnowledge;

namespace MOJ.DataManager
{
    public class CreateExamDataManager
    {

    
        public bool AddOrUpdate(List<CouncilExamEntity> Items)
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
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.CouncilExamUrl);
                        SPListItem item = null;
                        foreach (CouncilExamEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);                               
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["knowledgeCouncilID"] = Item.knowledgeCouncilID;
                            item["Answer"] = Item.Answer;
                            item["Question"] = Item.Question;
                            item["possibility1"] = Item.possibility1; 
                            item["possibility2"] = Item.possibility2; 
                            item["possibility3"] = Item.possibility3; 
                            item["possibility4"] = Item.possibility4;                             
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
 
    }
}
