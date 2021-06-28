using PaintServer.DTO;
namespace PaintServer.Services
{
    public interface IAutorizationService
    {
        AutorizationResultData AutorizeUser(UserAutorizationData userAutorizationData);
    }
}
