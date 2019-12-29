using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class CouncilFeedback
    {
        public bool SaveUpdate(CouncilFeedbackEntity obj)
        {
            return new CouncilFeedbackDataManager().AddOrUpdateknowledgeCouncil(obj);
        }         

        public CouncilFeedbackEntity GetCouncilFeedback(CouncilFeedbackEntity obj)
        {
            return new CouncilFeedbackDataManager().GetPlannedCouncils(obj);
        }




    }
}
