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
        public bool SaveUpdateCouncilExaminers(CouncilExaminersEntity obj)
        {
            return new knowledgeCouncilDataManager().AddOrUpdateCouncilExaminers(obj);
        }
        public bool SaveUpdateCouncilExamAnswer(List<CouncilExamAnswerEntity> obj)
        {
            return new knowledgeCouncilDataManager().AddOrUpdateCouncilExamAnswer(obj);
        }

        public List<knowledgeCouncilEntity> GetknowledgeCouncil(int limit = 0, string CouncilTopicvalue = "", string CouncilNovalue = "", string CouncilDatevalue = "", string Departmentvalue = "")
        {
            return new knowledgeCouncilDataManager().GetknowledgeCouncil(limit, CouncilTopicvalue, CouncilNovalue, CouncilDatevalue, Departmentvalue);
        }

        public List<knowledgeCouncilEntity> GetPlannedCouncils( string username , string language , string curentDate )
        {
            return new knowledgeCouncilDataManager().GetPlannedCouncils(username, language, curentDate);
        }

        public List<CouncilExamEntity> GetCouncilExam(int ckID)
        {
            return new knowledgeCouncilDataManager().GetCouncilExam(ckID);
        }
        public CouncilExaminersEntity GeCouncilExaminersByID(int id ,string loginName)
        {
            return new knowledgeCouncilDataManager().GeCouncilExaminersByID(id, loginName);
        }
        public CouncilExamAnswerEntity GetCouncilExamAnswer(int id ,string loginName)
        {
            return new knowledgeCouncilDataManager().GetCouncilExamAnswer(id, loginName);
        }
        public CouncilExamEntity GetCouncilExamBYID(int id)
        {
            return new knowledgeCouncilDataManager().GeCouncilExamByID(id);
        }


        public knowledgeCouncilEntity GetknowledgeCouncilByID(int id)
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
