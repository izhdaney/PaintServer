using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class RegistrationService: IRegistrationService
    {
        private IAutorizationDAL _autorizationDAL;
        public RegistrationService(IAutorizationDAL autorizationDAL)
        {
            _autorizationDAL = autorizationDAL;
        }

        public RegistrationResultData RegisterUser(UserRegistrationData userRegistrationData)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            //IAutorizationDAL autorizationDAL = new AutorizationDALmsSQL();

            RegistrationResultData registrationResultData = _autorizationDAL.Registration(userRegistrationData.Login, userRegistrationData.Password, userRegistrationData.FirstName, userRegistrationData.LastName);

            return registrationResultData;

        }
    }
}
