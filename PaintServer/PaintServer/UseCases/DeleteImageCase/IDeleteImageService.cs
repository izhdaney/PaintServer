
using PaintServer.DTO;

namespace PaintServer.Services
{
    public interface IDeleteImageService
    {
        DeleteImageResultData DeleteImage(DeleteImageInfo deleteImageInfo);
    }
}
