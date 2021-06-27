﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using PaintServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.DAL
{
    public class AutorizationDALmsSQL : IAutorizationDAL
    {
        private string _connectionString = "Server=localhost;Database=PaintDB;User Id=paint;password=paint;Trusted_Connection=False;MultipleActiveResultSets=true;";
        private AutorizationResultData _autorizationResultData;
        private RegistrationResultData _registrationResultData;
        public AutorizationDALmsSQL()
        {
        }

        public AutorizationResultData Autorization(string login, string password)
        {
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PaintUsers", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var a = reader["Email"];
                        var b = reader["Password"];

                        if (login == a.ToString() && password == b.ToString())
                        {
                            _autorizationResultData = new AutorizationResultData()
                            {
                                UserId = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Login = reader["Email"].ToString(),
                                AutorizationResultCode = 200,
                                AutorizationResultMessage = "Good"
                            };

                            return _autorizationResultData;
                        }
                    }

                    _autorizationResultData = new AutorizationResultData()
                    {
                        UserId = 0,
                        FirstName = "",
                        LastName = "",
                        Login = "",
                        AutorizationResultCode = 666,
                        AutorizationResultMessage = "Login or password invalide"
                    };

                    return _autorizationResultData;
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