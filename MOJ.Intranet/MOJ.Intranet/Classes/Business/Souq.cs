using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class Souq
    {
        public List<SouqEntity> GetSouqData()
        {
            return new SouqDataManager().GetSouqData();
        }
        public List<SouqEntity> GetSouqDataFromCategories(string Category1, string Category2, string Category3, string Category4)
        {
            return new SouqDataManager().GetSouqDataFromCategories(Category1, Category2, Category3, Category4);
        }
        public bool SaveUpdate(SouqEntity obj)
        {
            return new SouqDataManager().AddOrUpdate(obj);
        }
    }
}
