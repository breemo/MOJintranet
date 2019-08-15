using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class MyRequests
    {
      

            public List<MyRequestsEntity> GetMyRequests()
        {
            return new MyRequestsDataManager().GetMyRequests();
        }
        
        

        
    }
}
