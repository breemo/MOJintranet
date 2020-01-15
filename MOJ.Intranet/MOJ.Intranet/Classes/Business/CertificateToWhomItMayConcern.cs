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
        public string GetOrganizationTypeCode(int id)
        {
            return new OrganizationTypeDataManager().GetCode(id);
        }
        public DataTable GetRequestType()
        {
            return new RequestTypeDataManager().GetAll();
        }
        public string GetRequestTypeCode(int id)
        {
            return new RequestTypeDataManager().GetCode(id);
        }
        public DataTable GetSpeechLanguage()
        {
            return new SpeechLanguageDataManager().GetAll();
        }
        public string GetSpeechLanguageCode(int id)
        {
            return new SpeechLanguageDataManager().GetCode(id);
        }
        public DataTable GetSpeechType()
        {
            return new SpeechTypeDataManager().GetAll();
        }
        public string GetSpeechTypeCode(int id)
        {
            return new SpeechTypeDataManager().GetCode(id);
        }
        public DataTable GetTravelCountry()
        {
            return new CountrysDataManager().GetAll();
        }
        public string GetTravelCountryCode(int id)
        {
            return new CountrysDataManager().GetCode(id);
        }
        public bool SaveUpdate(CertificateToWhomItMayConcernEntity obj)
        {
            return new CertificateToWhomItMayConcernDataManager().AddOrUpdate(obj);
        }
       

    }
}
