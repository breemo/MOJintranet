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
        }
        public bool SaveUpdate(RequestAVacationEntity obj)
        {
            return new RequestAVacationDataManager().AddOrUpdate(obj);
        }
       

    }
}
