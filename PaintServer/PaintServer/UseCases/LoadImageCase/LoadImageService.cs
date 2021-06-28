using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class LoadImageService:ILoadImageService
    {
        private IOperationDAL _operationDAL;
        public LoadImageService(IOperationDAL operationDAL)
        {
            _operationDAL = operationDAL;
        }
        public LoadImageResultData LoadImage(LoadImageInfo loadImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            //IOperationDAL operationDAL = new OperationDALmsSQL();

            LoadImageResultData loadImageResultData = _operationDAL.LoadImage(loadImageInfo.UserId, loadImageInfo.ImageId);

            return loadImageResultData;
        }
    }
}
