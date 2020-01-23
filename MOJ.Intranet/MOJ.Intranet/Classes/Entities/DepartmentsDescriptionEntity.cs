using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class DepartmentsDescriptionEntity
    {
        public int ID { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }       
        public string TitleEN { get; set; }   
        public string Description { get; set; }
        public string DescriptionEN { get; set; }
     
    }
}
