using Microsoft.Data.SqlClient;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
    public class OperationDALmsSQL : IOperationDAL

    {
        private string _connectionString = "Server=localhost;Database=PaintDB;User Id=paint;password=paint;Trusted_Connection=False;MultipleActiveResultSets=true;";
        public SaveImageResultData SaveImage(string name, int size, string imageType, int userId, DateTime dateTime, string imageData)
        {
            SaveImageResultData saveImageResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var queryString = $"INSERT INTO dbo.SavedImages (UserId, ImageName, CreateDate, FileSize,ImageType,ImageData) VALUES ('{userId}','{name}','{dateTime}','{size}','{imageType}','{imageData}')";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        saveImageResultData = new SaveImageResultData()
                        {
                            SaveImageResult = true,
                            SaveImageResultMessage = "Good"
                        };

                        return saveImageResultData;

                    }
                    catch
                    {
                        saveImageResultData = new SaveImageResultData()
                        {
                            SaveImageResult = false,
                            SaveImageResultMessage = "Error Image not saved"
                        };

                        return saveImageResultData;
                    }
                }

            }
        }

        public int GetImageId(string name, int userId, DateTime dateTime)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [ImageName], [UserId], [ImageId], [CreateDate]  FROM dbo.SavedImages", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var a = reader["ImageName"];
                        var b = reader["UserId"];
                        var c = reader["CreateDate"];

                        if (name == a.ToString() && userId == (int)(b) && Convert.ToDateTime(c) == dateTime)
                        {
                            var imageId = reader["ImageId"];

                            return (int)(imageId);
                        }
                    }
                    return 0;
                }
            }
        }

        public LoadImageResultData LoadImage(int userId, int imageId)
        {
            LoadImageResultData loadImageResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [ImageData], [ImageType], [UserId], [ImageId]  FROM dbo.SavedImages", connection))
                {

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var a = reader["UserId"];
                        var b = reader["ImageId"];

                        if (userId == (int)a && imageId == (int)b)
                        {
                            loadImageResultData = new LoadImageResultData()
                            {
                                ImageData = reader["ImageData"].ToString(),
                                ImageType = reader["ImageType"].ToString(),
                                LoadImageResult = true,
                                LoadImageResultMessage = "Good"
                            };

                            return loadImageResultData;
                        }
                    }

                    loadImageResultData = new LoadImageResultData()
                    {
                        ImageData = "",
                        ImageType = "",
                        LoadImageResult = false,
                        LoadImageResultMessage = "Error Image not opened"
                    };

                    return loadImageResultData;
                }
            }
        }

        public GetFilesListResultData GetFilesList(int userId)
        {
            GetFilesListResultData getFilesListResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var queryString = $"SELECT [ImageId], [ImageName], [CreateDate], [FileSize], [ImageType]  FROM dbo.SavedImages WHERE ([UserId] = {userId.ToString()}) ORDER BY [CreateDate] DESC";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    getFilesListResultData = new GetFilesListResultData();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        var savedFileInfo = new SavedFileInfo()
                        {
                            ImageId = (int)reader["ImageId"],
                            ImageName = reader["ImageName"].ToString(),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                            FileSize = (int)reader["FileSize"],
                            ImageType = reader["ImageType"].ToString()
                        };

                        getFilesListResultData.SavedFileInfo.Add(savedFileInfo);
                    }

                    getFilesListResultData.GetFilesListResultMessage = "Get files list - OK";
                    getFilesListResultData.GetFilesListResult = true;

                    return getFilesListResultData;
                }
            }
        }

        public DeleteImageResultData DeleteImage(int userId, int imageId)
        {
            DeleteImageResultData deleteImageResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"DELETE FROM [SavedImages] WHERE (UserID={userId} AND ImageID={imageId})", connection))
                {

                    var res = command.ExecuteNonQuery();
                    
                    if (res==1)
                    {
                        deleteImageResultData = new DeleteImageResultData()
                        {

                            LoadImageResult = true,
                            LoadImageResultMessage = "Image deleted OK"
                        };
                    }
                    else
                    {
                        deleteImageResultData = new DeleteImageResultData()
                        {

                            LoadImageResult = false,
                            LoadImageResultMessage = "Error Image not deleted"
                        };
                    }

                    

                    return deleteImageResultData;
                }
            }
        }
    }
}