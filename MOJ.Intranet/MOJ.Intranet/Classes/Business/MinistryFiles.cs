using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class MinistryFiles
    {
        public List<MinistryFilesEntity> GetMinistryFilesData()
        {
            return new MinistryFilesDataManager().GetMinistryFilesData();
        }

        public List<MinistryFilesEntity> GetMinistryFilesSearch(string BookName,string CreatedBy, string Category, string Author)
        {
            return new MinistryFilesDataManager().GetMinistryFilesSearch(BookName, CreatedBy, Category, Author);
        }
    }
}
