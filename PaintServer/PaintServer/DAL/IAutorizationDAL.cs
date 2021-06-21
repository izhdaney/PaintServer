using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.DTO;

namespace PaintServer.DAL
{
    interface IAutorizationDAL
    {
        AutorizationResultData Autorization(string login, string password);

        //void Registration();



    }
}
