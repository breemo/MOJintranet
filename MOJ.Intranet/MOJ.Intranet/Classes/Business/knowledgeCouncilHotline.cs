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



        public knowledgeCouncilEntity GetHappinessHotline(int id)
        {
            return new knowledgeCouncilDataManager().GetknowledgeCouncilByID(id);
        }
        public DataTable GetCouncilType()
        {
            return new CouncilTypeDataManager().GetAll();
        }


    }
}
