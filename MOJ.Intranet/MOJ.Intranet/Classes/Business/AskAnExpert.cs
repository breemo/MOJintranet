using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class AskAnExpert
    {
      

            public List<AskAnExpertEntity> GetAskAnExpert(int limit =0 ,string Departmentvalue = "" , string Titlevalue = "")
        {
            return new AskAnExpertDataManager().GetAskAnExpert(limit, Departmentvalue, Titlevalue);
        }
        public List<ExpertsEntity> GetExpertsFromTo( string Departmentvalue , string curentDate)
        {
            return new ExpertsDataManager().GetExpertsFromTo( Departmentvalue, curentDate);
        }
        public ExpertsEntity GetExpertsByID(int IDis)
        {
            return new ExpertsDataManager().GetExpertsByID(IDis);
        }
        public List<AskAnExpertAnswerEntity> GetAskAnExpertAnswerByID(int IDis )
        {
            return new AskAnExpertDataManager().GetAskAnExpertAnswerByID(IDis);
        }
         public bool AddOrUpdate(AskAnExpertEntity item )
        {
            return new AskAnExpertDataManager().AddOrUpdate(item);
        }

      

    }
}
