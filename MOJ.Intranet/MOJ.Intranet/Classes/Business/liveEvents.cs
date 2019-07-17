using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class liveEvents
    {
        public List<liveEventsEntity> GetLatestHomeliveVideosItems()
        {
            return new liveEventsDataManager().GetLatestHomeliveVideosItems();
        }
    }
}
