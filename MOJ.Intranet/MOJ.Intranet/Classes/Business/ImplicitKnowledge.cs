using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;
using MOJ.Entities.ImplicitKnowledge;

namespace MOJ.Business
{
    public class ImplicitKnowledge
    {
        public int SaveUpdate(ImplicitKnowledgeEntity obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateRequest(obj);
        }
        public bool SaveUpdateEmploymentHistory(List<EmploymentHistoryEntity> obj)
        {
           return new ImplicitKnowledgeDataManager().AddOrUpdateEmploymentHistory(obj);

        }
        public List<EmploymentHistoryEntity> GeteEmploymentHistory(string title)
        {
           return new ImplicitKnowledgeDataManager().GeteEmploymentHistory(title);

        }

        
  public ImplicitKnowledgeEntity GetImplicitKnowledge(string title)
        {
            return new ImplicitKnowledgeDataManager().GetImplicitKnowledge(title);

        }

        
            public bool DeleteEmploymentHistory( List<int> listsid)
        {
            return new ImplicitKnowledgeDataManager().DeleteEmploymentHistory( listsid);

        }

        //public AffirmationSocialSituationEntity GetAffirmationSocialSituation(int id)
        //{
        //    return new AffirmationSocialSituationDataManager().GetAffirmationSocialSituationByID(id);
        //}


        //    public List<HusbandORWifeEntity> GetHusbandORWife(string title)
        //{
        //    return new HusbandORWifeDataManager().GetHusbandORWife(title);
        //}

        // public List<SonsEntity> Getsons(string title)
        //{
        //    return new SonsDataManager().Getsons(title);
        //}


    }
}
