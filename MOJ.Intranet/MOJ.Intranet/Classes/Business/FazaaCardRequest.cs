using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class FazaaCardRequest
    {
        public bool SaveUpdate(FazaaCardRequestEntity obj)
        {
            return new FazaaCardRequestDataManager().AddOrUpdate(obj);
        }



        public FazaaCardRequestEntity GetFazaaCardRequest(int id)
        {
            return new FazaaCardRequestDataManager().GetFazaaCardRequestByID(id);
        }

    }
}
