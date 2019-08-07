using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class RoomBooking
    {
        public bool SaveUpdate(RoomBookingEntity obj)
        {
            return new RoomBookingDataManager().AddOrUpdateHostingRequest(obj);
        }

        


             public RoomBookingEntity GetRoomBooking(int id)
        {
            return new RoomBookingDataManager().GetRoomBookingByID(id);
        }
    }
}
