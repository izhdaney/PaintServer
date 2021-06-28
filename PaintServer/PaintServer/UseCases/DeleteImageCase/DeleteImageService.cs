using PaintServer.DAL;
using PaintServer.DTO;

namespace PaintServer.Services
{
    public class DeleteImageService : IDeleteImageService
    {
        private IOperationDAL _operationDAL;
        public DeleteImageService(IOperationDAL operationDAL)
        {
            _operationDAL = operationDAL;
        }
        public DeleteImageResultData DeleteImage(DeleteImageInfo deleteImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            //IOperationDAL operationDAL = new OperationDALmsSQL();

            //LoadImageResultData loadImageResultData = operationDAL.LoadImage(loadImageInfo.UserId, loadImageInfo.ImageId);
            if (_operationDAL.DeleteImageStatistics(deleteImageInfo.ImageId))
            {
                DeleteImageResultData deleteImageResultData = _operationDAL.DeleteImage(deleteImageInfo.UserId, deleteImageInfo.ImageId);
                return deleteImageResultData;
            }

            return new DeleteImageResultData() { DeleteImageResult = false, DeleteImageResultMessage = "Error while deleting Image" };
            

            
        }
    }
}
