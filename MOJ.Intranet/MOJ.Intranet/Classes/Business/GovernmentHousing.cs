using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class GovernmentHousing
    {
        public bool SaveUpdate(GovernmentHousingEntity obj)
        {
            return new GovernmentHousingDataManager().AddOrUpdate(obj);
        }



        public GovernmentHousingEntity GetGovernmentHousing(int id)
        {
            return new GovernmentHousingDataManager().GetByID(id);
        }

    }
}
