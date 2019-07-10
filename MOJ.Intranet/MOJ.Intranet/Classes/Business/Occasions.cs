using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business
{
    public class Occasions
    {
        public List<OccasionsEntity> GetOccasionsHome()
        {
            return new OccasionsDataManager().GetOccasionsDataHome();
        }
        public List<OccasionsEntity> GetAllOccasions()
        {
            return new OccasionsDataManager().GetAllOccasionsData();
        }
    }
}
