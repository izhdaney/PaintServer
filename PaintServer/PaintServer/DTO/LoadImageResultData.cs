using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintServer.DTO
{
    public class LoadImageResultData
    {
        public string ImageData { get; set; }
        public string ImageType { get; set; }
        public bool LoadImageResult { get; set; }
        public string LoadImageResultMessage { get; set; }
    }
}
