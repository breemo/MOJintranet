using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class MinistryFilesEntity
    {
        public int ID { get; set; }
        public string BookTitle { get; set; }
        public string BookTitleEn { get; set; }
        public string BookDesc { get; set; }
        public string BookDescAr { get; set; }
        public string BookDescEn { get; set; }
        public string AttachmentsInfo { get; set; }
        public string AttachmentPicture { get; set; }
        public string CreatedBy { get; set; }

    }
}
