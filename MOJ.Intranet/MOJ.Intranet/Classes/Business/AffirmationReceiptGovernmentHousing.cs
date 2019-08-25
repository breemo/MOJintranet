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
    public class AffirmationReceiptGovernmentHousing
    {     

        public bool SaveUpdate(AffirmationReceiptGovernmentHousingEntity obj)
        {
            return new AffirmationReceiptGovernmentHousingDataManager().AddOrUpdate(obj);
        }       
        public AffirmationReceiptGovernmentHousingEntity GetByID(int id)
        {
            return new AffirmationReceiptGovernmentHousingDataManager().GetByID(id);
        }       
    }
}
