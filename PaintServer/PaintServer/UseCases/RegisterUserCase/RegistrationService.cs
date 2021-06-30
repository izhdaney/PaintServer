using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.Helpers;
using PaintServer.Exeptions;

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
            var validator = new Validation();

            var res = validator.NewUserValidation(userRegistrationData.FirstName,
                                                    userRegistrationData.LastName,
                                                      userRegistrationData.Login,
                                                       userRegistrationData.Password);
            if (res.BooleanValue==false)
            {
                throw new ParameterValidationException(res.StringValue);
            }

            RegistrationResultData registrationResultData = _autorizationDAL.Registration(userRegistrationData.Login, userRegistrationData.Password, userRegistrationData.FirstName, userRegistrationData.LastName);

            return registrationResultData;

        }
    }
}
