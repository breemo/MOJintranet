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
    public class ReserveHotel
    {
        public DataTable GetEmirates()
        {
            return new EmiratesDataManager().GetAll();
        }

        public bool SaveUpdate(ReserveHotelEntity obj)
        {
            return new ReserveHotelDataManager().AddOrUpdate(obj);
        }

        public bool SaveUpdateReserveHotelPeople(List<ReserveHotelPeopleEntity> obj)
        {
            return new ReserveHotelDataManager().AddOrUpdateReserveHotelPeople(obj);
        }
        public ReserveHotelEntity GetByID(int id)
        {
            return new ReserveHotelDataManager().GetByID(id);
        }

        public List<ReserveHotelPeopleEntity> GetReserveHotelPeople(string title)
        {
            return new ReserveHotelDataManager().GetReserveHotelPeople(title);
        }
    }
}
