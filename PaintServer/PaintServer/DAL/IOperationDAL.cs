﻿using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
   public interface IOperationDAL
    {
        SaveImageResultData SaveImage(string name,int size,string imageType, int userId, DateTime dateTime, string ImageData);

        LoadImageResultData LoadImage(int userId, int imageId);

        DeleteImageResultData DeleteImage(int userId, int imageId);

        int GetImageId(string name, int userId, DateTime dateTime);

        GetFilesListResultData GetFilesList(int UserId);

        bool DeleteImageStatistics(int imageId);

    }
}
