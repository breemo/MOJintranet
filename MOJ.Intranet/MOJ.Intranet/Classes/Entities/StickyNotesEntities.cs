using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class StickyNotesEntities
    {
        public int ID { get; set; }
        public string Title { get; set; }
        //public string TitleAr { get; set; }
        //public string TitleEn { get; set; }
        public DateTime Date { get; set; }
        public bool isDeleted { get; set; }
    }
}
