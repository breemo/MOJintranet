using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOJ.Entities
{
    public class ServicesListEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PageName { get; set; }
        public DateTime Created { get; set; }
        public string Picture { get; set; }
        public int Order { get; set; }
        public bool isActive { get; set; }
    }
}
