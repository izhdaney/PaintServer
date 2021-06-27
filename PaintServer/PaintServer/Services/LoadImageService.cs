using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class LoadImageService
    {
        public LoadImageResultData LoadImage(LoadImageInfo loadImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            OperationDAL operationDAL = new OperationDAL();

            LoadImageResultData loadImageResultData = operationDAL.LoadImage(loadImageInfo.UserId, loadImageInfo.ImageId);

            return loadImageResultData;
        }
    }
}
