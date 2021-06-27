using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintServer.DTO
{
    public class SaveImageInfo
    {
        public string Name { get; set; }
        public string ImageType { get; set; }
      /*  public DateTime CreationDate { get; set; }*/
        public int FileSize { get; set; }
        public int UserId { get; set; }
        public string ImageData { get; set; }
    }
}
