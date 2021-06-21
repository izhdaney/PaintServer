using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
    public class AutorizationDAL : IAutorizationDAL
    {
        public AutorizationResultData Autorization(string login, string password)
        {
            AutorizationResultData autorizationResultData = new AutorizationResultData()
            {
                UserId = 100,
                FirstName = "Ilya",
                LastName = "Zhdaney",
                Login = "zhdaney@gmail.com",
                //AutorizationResultCode = 200,
                AutorizationResultMessage = ""

            };

            return autorizationResultData;
            //throw new NotImplementedException();
        }
    }
}
