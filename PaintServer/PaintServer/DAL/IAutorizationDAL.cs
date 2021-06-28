using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.DTO;

namespace PaintServer.DAL
{
    public interface IAutorizationDAL
    {
        AutorizationResultData Autorization(string login, string password);

        RegistrationResultData Registration(string login, string password, string firstName, string lastName);

    }
}
