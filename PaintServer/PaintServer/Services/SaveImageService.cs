using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class SaveImageService
    {
        public SaveImageResultData SaveImage(SaveImageInfo saveImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            OperationDAL operationDAL = new OperationDAL();

            SaveImageResultData saveImageResultData = operationDAL.SaveImage(saveImageInfo.Name, saveImageInfo.FileSize, saveImageInfo.ImageType, saveImageInfo.UserId, DateTime.Now,saveImageInfo.ImageData);

            return saveImageResultData;

        }
    }
}
