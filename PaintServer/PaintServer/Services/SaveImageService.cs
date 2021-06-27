using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_Project_Paint.Class.OperationWithFigures;
using Team_Project_Paint.PaintEnum;

namespace PaintServer.Services
{
    public class SaveImageService
    {
        public SaveImageResultData SaveImage(SaveImageInfo saveImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            OperationDAL operationDAL = new OperationDAL();
            StatisticDAL statisticDAL = new StatisticDAL();

            SaveImageResultData saveImageResultData = operationDAL.SaveImage(saveImageInfo.Name, saveImageInfo.FileSize, saveImageInfo.ImageType, saveImageInfo.UserId, DateTime.Now,saveImageInfo.ImageData);

            int lastImageId = operationDAL.GetImageId(saveImageInfo.Name, saveImageInfo.UserId);

            if (saveImageInfo.ImageType == "json" && lastImageId != 0)
            {
                var jl = new JsonLogic();
                jl.JsonDeserialize(saveImageInfo.ImageData);
                var list = jl.JsonList;

                //string resultTest = "";

                int[] mass = new int[9];

                foreach (var f in list)
                {
                    if (f.Name != EShapeType.Curve || (f.Name == EShapeType.Curve && f.ShapePoints.Count != 0))
                    {
                        mass[(int)(f.Name)]++;
                    }
                }

                for (int i = 1; i <= 8; i++)
                {
                    //resultTest += $"{mass[i].ToString()} {((EShapeType)i).ToString()}\n";
                    statisticDAL.AddFigureRow(lastImageId, i, mass[i]);

                }
            }

            return saveImageResultData;

        }
    }
}
