using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class DeleteImageService
    {
        public DeleteImageResultData DeleteImage(DeleteImageInfo deleteImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            IOperationDAL operationDAL = new OperationDALmsSQL();

            //LoadImageResultData loadImageResultData = operationDAL.LoadImage(loadImageInfo.UserId, loadImageInfo.ImageId);
            DeleteImageResultData deleteImageResultData = operationDAL.DeleteImage(deleteImageInfo.UserId, deleteImageInfo.ImageId);

            return deleteImageResultData;
        }
    }
}
