using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class GetFilesListService
    {
        public GetFilesListResultData GetFilesList(GetFilesListInfo getFilesListInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            IOperationDAL operationDAL = new OperationDALmsSQL();

            GetFilesListResultData getFilesListResultData = operationDAL.GetFilesList(getFilesListInfo.UserId);

            return getFilesListResultData;
        }
    }
}
