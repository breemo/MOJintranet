using MOJ.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class CarOrderServiceBL
    {
        public bool AddCarOrderServic(string _RequestNumber, string _TravelNeeds,
            string _TravelTo, string _NameOfPassengers, string _TravelReason, string _CarPlace, DateTime _TravelDate, string _Duration)
        {
            return new CarOrderServiceDataManager().InsertCarOrderRequest(_RequestNumber, _TravelNeeds, _TravelTo, _NameOfPassengers, _TravelReason, _CarPlace, _TravelDate, _Duration);
        }
    }
}
