using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class MyRequestsB
    {
      

            public List<MyRequestsEntity> GetMyRequests(int limit =0 ,string languageCode="en")
        {
            return new MyRequestsDataManager().GetMyRequests(limit, languageCode);
        }

      

    }
}
