using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class News
    {
        public List<NewsEntity> GetNews()
        {
            return new NewsDataManager().GetNewsData();
        }
        public NewsEntity GetNews(int id)
        {
            return new NewsDataManager().GetNewsDataByID(id);
        }
    }
}
