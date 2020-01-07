using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class CreateExam
    {
        public bool SaveUpdate(List<CouncilExamEntity> obj)
        {
            return new CreateExamDataManager().AddOrUpdate(obj);
        }
        public bool UpdatePassPercentage(knowledgeCouncilEntity obj)
        {
            return new knowledgeCouncilDataManager().UpdatePassPercentage(obj);
        }
    }
}
