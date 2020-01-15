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
    public class CertificateToWhomItMayConcern
    {
        public DataTable GetOrganizationType()
        {
            return new OrganizationTypeDataManager().GetAll();
        }
        public DataTable GetRequestType()
        {
            return new RequestTypeDataManager().GetAll();
        }
        public DataTable GetSpeechLanguage()
        {
            return new SpeechLanguageDataManager().GetAll();
        }
        public DataTable GetSpeechType()
        {
            return new SpeechTypeDataManager().GetAll();
        }
        public DataTable GetTravelCountry()
        {
            return new CountrysDataManager().GetAll();
        }
        public bool SaveUpdate(CertificateToWhomItMayConcernEntity obj)
        {
            return new CertificateToWhomItMayConcernDataManager().AddOrUpdate(obj);
        }
       

    }
}
