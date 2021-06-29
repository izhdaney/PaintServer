using PaintServer.DAL;
using PaintServer.DTO;
using PaintServer.Exeptions;

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
            
            if (_operationDAL.IsImageExists(deleteImageInfo.ImageId))
            {
                if (_operationDAL.IsImageBelongs(deleteImageInfo.ImageId, deleteImageInfo.UserId))
                {

                }
                else
                {
                    throw new AccessLevelException("You are not owner of this image. Can't delete");
                }
            }
            else
            {
                throw new ParameterValidationException("Image with such id not found");
            }

            if (_operationDAL.DeleteImageStatistics(deleteImageInfo.ImageId))
            {
                DeleteImageResultData deleteImageResultData = _operationDAL.DeleteImage(deleteImageInfo.UserId, deleteImageInfo.ImageId);
                return deleteImageResultData;
            }

            return new DeleteImageResultData() { DeleteImageResult = false, DeleteImageResultMessage = "Error while deleting Image" };
            

            
        }
    }
}
