using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOJ.Entities
{
    public class NewsEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime Date { get; set; }
        public string Picture { get; set; }
    }
}
