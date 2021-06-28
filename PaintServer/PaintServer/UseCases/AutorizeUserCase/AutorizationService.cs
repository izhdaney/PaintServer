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
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            

            AutorizationResultData autorizationResultData = _autorizationDAL.Autorization(userAutorizationData.Login, userAutorizationData.Password);

            return autorizationResultData;
        }
    }
}
