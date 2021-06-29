using Microsoft.Data.SqlClient;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.Exeptions;

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
                var queryString = $"INSERT INTO dbo.SavedImages (UserId, ImageName, CreateDate, FileSize,ImageType,ImageData) VALUES (@userId,@ImageName, @CreateDate, @Filesize, @ImageType,@ImageData)";

                //var queryString = $"INSERT INTO dbo.SavedImages (UserId, ImageName, CreateDate, FileSize,ImageType,ImageData) VALUES
                //('{userId}','{name}','{dateTime}','{size}','{imageType}','{imageData}')";
                //UserId, ImageName, CreateDate, FileSize,ImageType,ImageData
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {   DbType=System.Data.DbType.Int32,
                        ParameterName="@UserId",
                        Value=userId
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.String,
                        ParameterName = "@ImageName",
                        Value = name
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.DateTime2,
                        ParameterName = "@CreateDate",
                        Value = dateTime
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@FileSize",
                        Value = size
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.String,
                        ParameterName = "@ImageType",
                        Value = imageType
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.String,
                        ParameterName = "@ImageData",
                        Value = imageData
                    });
                    command.ExecuteNonQuery();
                        saveImageResultData = new SaveImageResultData()
                        {
                            SaveImageResult = true,
                            SaveImageResultMessage = "Good"
                        };
                        return saveImageResultData;
                }
            }
        }
        public int GetImageId(string name, int userId, DateTime dateTime)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [ImageName], [UserId], [ImageId], [CreateDate]  FROM dbo.SavedImages WHERE ([ImageName]=@ImageName AND [UserId]=@UserId)", connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@UserId",
                        Value = userId
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.String,
                        ParameterName = "@ImageName",
                        Value = name
                    });
                    var reader = command.ExecuteReader();
                    
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return Convert.ToInt32(reader["ImageId"]);
                    }
                    else
                    {
                        throw new DatabaseOperationErrorException("Unexpected database error while saving image");
                    }
                }
            }
        }

        public LoadImageResultData LoadImage(int userId, int imageId)
        {
            LoadImageResultData loadImageResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                
                using (SqlCommand command = new SqlCommand("SELECT [ImageData], [ImageType], [UserId], [ImageId]  FROM dbo.SavedImages WHERE ([ImageID]=@ImageID)", connection))
                {

                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@ImageId",
                        Value = imageId
                    });
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        if ( Convert.ToInt32(reader["UserId"])!=userId)
                        {
                            throw new AccessLevelException("You have no permission to load this image");
                        }
                        loadImageResultData = new LoadImageResultData()
                        {
                            ImageData = reader["ImageData"].ToString(),
                            ImageType = reader["ImageType"].ToString(),
                            LoadImageResult = true,
                            LoadImageResultMessage = "Good"
                        };

                        return loadImageResultData;
                    }
                    else
                    {
                        throw new ParameterValidationException("No file with such ID");
                    }
                }
            }
        }

        public GetFilesListResultData GetFilesList(int userId)
        {
            GetFilesListResultData getFilesListResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var queryString = $"SELECT [ImageId], [ImageName], [CreateDate], [FileSize], [ImageType]  FROM dbo.SavedImages WHERE ([UserId] = @UserID) ORDER BY [CreateDate] DESC";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    getFilesListResultData = new GetFilesListResultData();
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@UserId",
                        Value = userId
                    });

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

        public DeleteImageResultData DeleteImage( int imageId)
        {
            DeleteImageResultData deleteImageResultData;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"DELETE FROM [SavedImages]  WHERE (SavedImages.ImageID=@ImageId)", connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@ImageId",
                        Value = imageId
                    });
                    var res = command.ExecuteNonQuery();

                    if (res == 1)
                    {
                        deleteImageResultData = new DeleteImageResultData()
                        {

                            DeleteImageResult = true,
                            DeleteImageResultMessage = "Image deleted OK"
                        };
                    }
                    else
                    {
                        throw new DatabaseOperationErrorException("Error while deleting image");
                    }



                    return deleteImageResultData;
                }
            }
        }

        public bool DeleteImageStatistics(int imageId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"DELETE FROM [ImageFiguresCount] WHERE ( ImageID=@ImageId)", connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@ImageId",
                        Value = imageId
                    });
                    var res = command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public bool IsImageExists(string filename, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT SavedImages.ImageName FROM SavedImages WHERE ([ImageName]=@ImageName AND [UserId]=@UserID)", connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.String,
                        Value = filename,
                        ParameterName = "@ImageName"
                    });
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = userId,
                        ParameterName = "@UserId"
                    });

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
        }

        public bool IsImageExists(int imageId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT SavedImages.ImageName FROM SavedImages WHERE ([ImageId]=@ImageID)", connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = imageId,
                        ParameterName = "@ImageId"
                    });
                    

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public bool IsImageBelongs(int imageId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT SavedImages.ImageName, UserId FROM SavedImages WHERE ([ImageId]=@ImageID)", connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = imageId,
                        ParameterName = "@ImageId"
                    });


                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (Convert.ToInt32(reader["UserId"])==userId)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
    }
}