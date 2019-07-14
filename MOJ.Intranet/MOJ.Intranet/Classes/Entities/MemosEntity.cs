using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class MemosEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string TitleEn { get; set; }
        public string BodyEn { get; set; }
        public DateTime Created { get; set; }
        public DateTime Date { get; set; }
        public string AttachmentsInfo { get; set; }
        public string AttachmentPicture { get; set; }
        public string MemoNumber { get; set; }
    }
}



