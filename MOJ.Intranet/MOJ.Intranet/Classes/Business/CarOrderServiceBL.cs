using Microsoft.SharePoint;
using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class CarOrderServiceBL
    {
        public bool AddCarOrderServic(SPUser _CureentUser, string _RequestNumber, string _TravelNeeds,
            string _TravelTo, string _NameOfPassengers, string _TravelReason, string _CarPlace, DateTime _TravelDate, string _Duration)
        {
            return new CarOrderServiceDataManager().InsertCarOrderRequest(_CureentUser, _RequestNumber, _TravelNeeds, _TravelTo, _NameOfPassengers, _TravelReason, _CarPlace, _TravelDate, _Duration);
        }

        public CarOrderServiceEntity GetCarOrderServiceByID(int id)
        {

            return new CarOrderServiceDataManager().GetCarOrderServiceByID(id);
        }
    }
}
