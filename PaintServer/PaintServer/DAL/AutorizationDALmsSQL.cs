using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaintServer.Exeptions;

namespace PaintServer.DAL
{
    public class AutorizationDALmsSQL : IAutorizationDAL
    {
        private string _connectionString = "Server=localhost;Database=PaintDB;User Id=paint;password=paint;Trusted_Connection=False;MultipleActiveResultSets=true;";
        
        private RegistrationResultData _registrationResultData;
        public AutorizationDALmsSQL()
        {
        }

        public AutorizationResultData Autorization(string login, string password)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                    connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PaintUsers WHERE [Email]=@Email", connection))
                {
                    command.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.String,
                        Value = login,
                        ParameterName="@Email"
                    }); 
                                       
                    var reader = command.ExecuteReader();
                    
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (reader["Password"].ToString()==password)
                        {
                            var autorizationResultData = new AutorizationResultData()
                            {
                                UserId = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Login = reader["Email"].ToString(),
                                AutorizationResultCode = 200,
                                AutorizationResultMessage = "Good"
                            };

                            using (SqlCommand commandSession = new SqlCommand($"INSERT INTO UserSessions (UserId) VALUES (@UserID )", connection))
                            {
                                commandSession.Parameters.Add(new SqlParameter()
                                { 
                                    ParameterName = "@UserID",
                                    Value = autorizationResultData.UserId,
                                    DbType = System.Data.DbType.Int32
                                });
                                commandSession.ExecuteNonQuery();
                            }
                            return autorizationResultData;
                        }
                        else
                        {
                            throw new AutorizationFailException("Incorrect password");
                        }
                    }
                    else
                    {
                        throw new AutorizationFailException("No such user in database");
                    }
                }
            }
        }


        public RegistrationResultData Registration(string login, string password, string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var queryString = $"INSERT INTO dbo.PaintUsers (FirstName, LastName, Email, Password) VALUES ('{firstName}','{lastName}','{login}','{password}')";
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        _registrationResultData = new RegistrationResultData()
                        {
                            RegistrationResult = true,
                            RegistrationResultMessage = "Good"
                        };

                        return _registrationResultData;

                    }
                    catch
                    {
                        _registrationResultData = new RegistrationResultData()
                        {
                            RegistrationResult = false,
                            RegistrationResultMessage = "Can't create such user"
                        };

                        return _registrationResultData;
                    }
                }
            }
        }
    }
}
