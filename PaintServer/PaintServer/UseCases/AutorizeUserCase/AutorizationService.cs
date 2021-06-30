using PaintServer.DAL;
using PaintServer.DTO;

namespace PaintServer.Services
{
    public class AutorizationService: IAutorizationService
    {
        private IAutorizationDAL _autorizationDAL;
        public AutorizationService(IAutorizationDAL autorizationDAL)
        {
            _autorizationDAL = autorizationDAL;
        }

        public AutorizationResultData AutorizeUser(UserAutorizationData userAutorizationData)
        {
   
            AutorizationResultData autorizationResultData = _autorizationDAL.Autorization(userAutorizationData.Login, userAutorizationData.Password);

            return autorizationResultData;
        }
    }
}
