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
    public class ReturnFromLeave
    {     

        public bool SaveUpdate(ReturnFromLeaveEntity obj)
        {
            return new ReturnFromLeaveDataManager().AddOrUpdate(obj);
        }       
        public ReturnFromLeaveEntity GetByID(int id)
        {
            return new ReturnFromLeaveDataManager().GetByID(id);
        }       
    }
}
