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
    public class RequestAVacation
    {
        public DataTable GetVacationsTypes()
        {
            return new VacationsTypesDataManager().GetAll();
        } public DataTable GetExitPermitReason()
        {
            return new ExitPermitReasonDataManager().GetAll();
        }
        public string GetTitleExitPermitReason(int id)
        {
            return new ExitPermitReasonDataManager().GetTitle(id);
        }
        public string GetVacationsTypesCode(int id)
        {
            return new VacationsTypesDataManager().GetCode(id);
        }
        public bool SaveUpdate(RequestAVacationEntity obj)
        {
            return new RequestAVacationDataManager().AddOrUpdate(obj);
        }
       

    }
}
