﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOJ.Entities
{
    public class OccasionsEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public DateTime Created { get; set; }
    }
}