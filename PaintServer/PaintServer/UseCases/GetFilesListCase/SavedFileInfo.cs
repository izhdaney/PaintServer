using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintServer.DTO
{
    public class SavedFileInfo
    {
        public int ImageId { get; set; }

        public string ImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public int FileSize { get; set; }
        public string ImageType { get; set; }
    }
}
