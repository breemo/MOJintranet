using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class DepartmentCircularsEntity
    {
        public int ID { get; set; }
        public string CircularTitle { get; set; }
        public DateTime CircularDate { get; set; }
        public string CircularBody { get; set; }
    }
}
