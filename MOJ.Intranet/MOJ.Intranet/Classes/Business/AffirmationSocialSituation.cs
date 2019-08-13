using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class AffirmationSocialSituationB
    {
        public bool SaveUpdate(AffirmationSocialSituationEntity obj)
        {
            return new AffirmationSocialSituationDataManager().AddOrUpdateHostingRequest(obj);
        }
        
            public bool SaveUpdateChildren(List<SonsEntity> obj)
        {
            return new AffirmationSocialSituationDataManager().AddOrUpdateHostingChildren(obj);
        }
        
                public bool SaveUpdateHusbandORWife(List<HusbandORWifeEntity> obj)
        {
            return new AffirmationSocialSituationDataManager().AddOrUpdateHusbandORWife(obj);
        }

        //     public RoomBookingEntity GetRoomBooking(int id)
        //{
        //    return new RoomBookingDataManager().GetRoomBookingByID(id);
        //}
    }
}
