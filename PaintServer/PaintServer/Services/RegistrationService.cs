using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class RegistrationService
    {
        public RegistrationResultData RegisterUser(UserRegistrationData userRegistrationData)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            AutorizationDAL autorizationDAL = new AutorizationDAL();

            RegistrationResultData registrationResultData = autorizationDAL.Registration(userRegistrationData.Login, userRegistrationData.Password, userRegistrationData.FirstName, userRegistrationData.LastName);

            return registrationResultData;

        }
    }
}
