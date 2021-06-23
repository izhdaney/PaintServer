using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
   public interface IOperationDAL
    {
        SaveImageResultData SaveImage(string name,int size,string imageType, int userId, DateTime dateTime, string ImageData);
    }
}
