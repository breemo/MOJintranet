using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class knowledgeCouncil
    {
        public bool SaveUpdate(knowledgeCouncilEntity obj)
        {
            return new knowledgeCouncilDataManager().AddOrUpdateknowledgeCouncil(obj);
        }
                                                      
        public List<knowledgeCouncilEntity> GetknowledgeCouncil(int limit = 0, string CouncilTopicvalue = "", string CouncilNovalue = "", string CouncilDatevalue = "", string Departmentvalue = "")
        {
            return new knowledgeCouncilDataManager().GetknowledgeCouncil(limit, CouncilTopicvalue, CouncilNovalue, CouncilDatevalue, Departmentvalue);
        }
 



        public knowledgeCouncilEntity GetHappinessHotline(int id)
        {
            return new knowledgeCouncilDataManager().GetknowledgeCouncilByID(id);
        }
        public DataTable GetCouncilType()
        {
            return new CouncilTypeDataManager().GetAll();
        }
        public string GetCouncilTypeByid(int id ,string language)
        {
            return new CouncilTypeDataManager().GetByID(id, language);
        }

    }
}
