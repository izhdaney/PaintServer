using Microsoft.Data.SqlClient;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
    public class OperationDAL : IOperationDAL

    {
        private SaveImageResultData _saveImageResultData;
        private string _connectionString = "Server=localhost;Database=PaintDB;User Id=paint;password=paint;Trusted_Connection=False;MultipleActiveResultSets=true;";
        public SaveImageResultData SaveImage(string name, int size, string imageType, int userId, DateTime dateTime, string imageData)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var queryString = $"INSERT INTO dbo.SavedImages (UserId, ImageName, CreateDate, FileSize,ImageType,ImageData) VALUES ('{userId}','{name}','{dateTime}','{size}','{imageType}','{imageData}')";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        _saveImageResultData = new SaveImageResultData()
                        {
                            SaveImageResult = true,
                            SaveImageResultMessage = "Good"
                        };

                        return _saveImageResultData;

                    }
                    catch
                    {
                        _saveImageResultData = new SaveImageResultData()
                        {
                            SaveImageResult = false,
                            SaveImageResultMessage = "Error Image not saved"
                        };

                        return _saveImageResultData;
                    }
                }

            }
        }

        public int GetImageId(string name, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [ImageName], [UserId], [ImageId]  FROM dbo.SavedImages", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var a = reader["ImageName"];
                        var b = reader["UserId"];

                        if (name == a.ToString() && userId == (int)(b))
                        {
                            var imageId = reader["ImageId"];

                            return (int)(imageId);
                        }
                    }
                    return 0;
                }
            }
        }
    }
}