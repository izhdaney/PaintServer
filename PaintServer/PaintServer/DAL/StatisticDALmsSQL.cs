using Microsoft.Data.SqlClient;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
    public class StatisticDALmsSQL : IStatisticDAL
    {
        private string _connectionString = "Server=localhost;Database=PaintDB;User Id=paint;password=paint;Trusted_Connection=False;MultipleActiveResultSets=true;";
        public void AddFigureRow(int imageId, int figureId, int figureCount)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var queryString = $"INSERT INTO dbo.ImageFiguresCount (ImageID, TypeID, FiguresCount) VALUES ('{imageId}','{figureId}','{figureCount}')";
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public StatisticResultData GetUserStatistics(int userId)
        {
            StatisticResultData statisticResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var queryString = $"SELECT [N],[R],[C]FROM[dbo].[VW_UserStatistics] ORDER BY R";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    statisticResultData = new StatisticResultData();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        var statisticItem = new StatisticItem()
                        {
                           StatisticName=reader["N"].ToString(),
                           StatisticValue=reader["C"].ToString()
                         };

                        statisticResultData.StatisticItems.Add(statisticItem);
                    }

                    statisticResultData.StatisticResultMessage = "Get statistic list - OK";
                    statisticResultData.StatisticResult = true;

                    return statisticResultData;
                }
            }
        }
    }
}
