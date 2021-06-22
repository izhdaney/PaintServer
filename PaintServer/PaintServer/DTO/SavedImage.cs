using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintServer.DTO
{
    public class SavedImage : SaveImageInfo
    {
        public string ImageData { get; set; }
    }
}
