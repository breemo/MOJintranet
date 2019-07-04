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
        public List<NewsEntity> GetAllNews()
        {
            return new NewsDataManager().GetAllNewsData();
        }
        public List<NewsEntity> GetLast4News()
        {
            return new NewsDataManager().GetLast4NewsData();
        }
        public NewsEntity GetNews(int id)
        {
            return new NewsDataManager().GetNewsDataByID(id);
        }
        public List<NewsEntity> GetNews(string srch)
        {
            return new NewsDataManager().SrchNews(srch);
        }
    }
}
