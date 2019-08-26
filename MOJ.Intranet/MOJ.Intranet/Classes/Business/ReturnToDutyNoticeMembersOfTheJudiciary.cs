using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business
{
    public class ReturnToDutyNoticeMembersOfTheJudiciary
    {
        public DataTable GetDays()
        {
            return new DaysDataManager().GetAll();
        }
        public bool SaveUpdate(ReturnToDutyNoticeMembersOfTheJudiciaryEntity obj)
        {
            return new ReturnToDutyNoticeMembersOfTheJudiciaryDataManager().AddOrUpdate(obj);
        }
        public ReturnToDutyNoticeMembersOfTheJudiciaryEntity GetByID(int id)
        {
            return new ReturnToDutyNoticeMembersOfTheJudiciaryDataManager().GetByID(id);
        }

    }
}
