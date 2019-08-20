using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class ContactWithHR
    {
        public bool SaveUpdate(ContactWithHREntity obj)
        {
            return new ContactWithHRDataManager().AddOrUpdateContactWithHR(obj);
        }



        public ContactWithHREntity GetContactWithHR(int id)
        {
            return new ContactWithHRDataManager().GetContactWithHRByID(id);
        }

    }
}
