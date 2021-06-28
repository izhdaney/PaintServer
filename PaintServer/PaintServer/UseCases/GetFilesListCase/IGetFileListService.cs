using PaintServer.DTO;


namespace PaintServer.Services
{
    public interface IGetFileListService
    {
        public GetFilesListResultData GetFilesList(GetFilesListInfo getFilesListInfo);
    }
}
