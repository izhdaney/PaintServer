using PaintServer.DAL;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Services
{
    public class StatisticService:IStatisticService
    {
        private IStatisticDAL _statisticDAL;

        public StatisticService(IStatisticDAL statisticDAL)
        {
            _statisticDAL = statisticDAL;
        }
        public StatisticResultData GetUserStatistics(StatisticInfo statisticInfo)
        {



            StatisticResultData statisticResultData = _statisticDAL.GetUserStatistics(statisticInfo.UserId);

            return statisticResultData;
        }
    }
}
