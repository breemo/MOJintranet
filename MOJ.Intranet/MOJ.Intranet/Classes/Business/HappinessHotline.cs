using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class HappinessHotline
    {
        public bool SaveUpdate(HappinessHotlineEntity obj)
        {
            return new HappinessHotlineDataManager().AddOrUpdateHappinessHotline(obj);
        }



        public HappinessHotlineEntity GetHappinessHotline(int id)
        {
            return new HappinessHotlineDataManager().GetHappinessHotlineByID(id);
        }

    }
}
