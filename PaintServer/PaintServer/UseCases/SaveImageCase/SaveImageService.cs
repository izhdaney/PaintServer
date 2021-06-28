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
    public class SaveImageService: ISaveImageService
    {
        private IOperationDAL _operationDAL;
        private IStatisticDAL _statisticDAL;

        public SaveImageService(IOperationDAL operationDAL, IStatisticDAL statisticDAL)
        {
            _operationDAL = operationDAL;
            _statisticDAL = statisticDAL;
        }
        public SaveImageResultData SaveImage(SaveImageInfo saveImageInfo)
        {
            //1  Ilya Zhdaney  zhdaney@gmail.com QWE123qazQQ

            //IOperationDAL operationDAL = new OperationDALmsSQL();
            //IStatisticDAL statisticDAL = new StatisticDALmsSQL();
            DateTime dateTime = DateTime.Now;

            SaveImageResultData saveImageResultData = _operationDAL.SaveImage(saveImageInfo.Name, saveImageInfo.FileSize, saveImageInfo.ImageType, saveImageInfo.UserId, dateTime,saveImageInfo.ImageData);

            int lastImageId = _operationDAL.GetImageId(saveImageInfo.Name, saveImageInfo.UserId, dateTime);

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
                    _statisticDAL.AddFigureRow(lastImageId, i, mass[i]);

                }
            }

            return saveImageResultData;

        }
    }
}
