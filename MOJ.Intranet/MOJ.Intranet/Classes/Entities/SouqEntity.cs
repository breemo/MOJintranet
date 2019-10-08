using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class SouqEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ContactNumber { get; set; }
        public string AttachmentsInfo { get; set; }
        public string AttachmentPicture { get; set; }
        public string CreatedBy { get; set; }
        public Stream Photo { get; set; }
        public string PhotoPath { get; set; }


    }
}
