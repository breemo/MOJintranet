using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class PeriodicalFormForGovernmentHousing
    {
        public bool SaveUpdate(PeriodicalFormForGovernmentHousingEntity obj)
        {
            return new PeriodicalFormForGovernmentHousingDataManager().AddOrUpdate(obj);
        }
        
            public bool SaveUpdateChildren(List<SonsEntity> obj)
        {
            return new SonsDataManager().AddOrUpdateHostingChildren(obj);
        }
        
                public bool SaveUpdateHusbandORWife(List<HusbandORWifeEntity> obj)
        {
            return new HusbandORWifeDataManager().AddOrUpdateHusbandORWife(obj);
        }

        public PeriodicalFormForGovernmentHousingEntity GetAffirmationSocialSituation(int id)
        {
            return new PeriodicalFormForGovernmentHousingDataManager().GetByID(id);
        }
        

            public List<HusbandORWifeEntity> GetHusbandORWife(string title)
        {
            return new HusbandORWifeDataManager().GetHusbandORWife(title);
        }
        
         public List<SonsEntity> Getsons(string title)
        {
            return new SonsDataManager().Getsons(title);
        }

        
    }
}
