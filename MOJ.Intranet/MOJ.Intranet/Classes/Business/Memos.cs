using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business
{
    public class Memos
    {
        public List<MemosEntity> GetMemosHome()
        {
            return new MemosDataManager().GetMemosDataHome();
        }
        public List<MemosEntity> GetMemos()
        {
            return new MemosDataManager().GetMemosData();
        }
        public List<MemosEntity> GetMemos(string srch)
        {
            return new MemosDataManager().GetMemosData(srch);
        }
        public MemosEntity GetMemos(int id)
        {
            return new MemosDataManager().GetMemosDataByID(id);
        }
    }
}
