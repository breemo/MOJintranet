using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class DepartmentsEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public SPFieldUserValue DepartmentAdmin { get; set; }        
           

    }
}
