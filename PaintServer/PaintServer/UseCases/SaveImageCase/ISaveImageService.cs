using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.DTO;

namespace PaintServer.Services
{
   public interface ISaveImageService
    {
        SaveImageResultData SaveImage(SaveImageInfo saveImageInfo);
    }
}
