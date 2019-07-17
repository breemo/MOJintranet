using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class liveEventsEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NAmeEn { get; set; }
        public DateTime Created { get; set; }
        public string VideoURL { get; set; }
        public string VideoThumbnailURL { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
    }
}



