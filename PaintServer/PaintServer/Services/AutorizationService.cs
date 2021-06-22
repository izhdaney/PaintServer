using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.DTO;
using PaintServer.DAL;
using Microsoft.Extensions.Options;

namespace PaintServer.Services
{
    public class AutorizationService
    {
        public AutorizationResultData AutorizeUser(UserAutorizationData userAutorizationData)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            AutorizationDAL autorizationDAL = new AutorizationDAL();

            AutorizationResultData autorizationResultData = autorizationDAL.Autorization(userAutorizationData.Login, userAutorizationData.Password);

            return autorizationResultData;
        }
    }
}
