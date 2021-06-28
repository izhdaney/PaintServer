using PaintServer.DTO;

namespace PaintServer.Services
{
    public interface ILoadImageService
    {
        LoadImageResultData LoadImage(LoadImageInfo loadImageInfo);
    }
}
