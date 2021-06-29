using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
    public interface IStatisticDAL
    {
        void AddFigureRow(int imageId, int figureId, int figureCount);
        StatisticResultData GetUserStatistics(int userId);

    }
}
