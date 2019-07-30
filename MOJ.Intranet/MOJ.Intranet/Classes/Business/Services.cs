using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class Services
    {
        public List<ServicesListEntity> GetAllActiveServices()
        {
            return new ServicesListManager().GetAllActiveServicesListData();
        }
    }
}
