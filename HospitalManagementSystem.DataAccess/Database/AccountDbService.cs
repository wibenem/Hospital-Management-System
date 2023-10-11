﻿using Dapper;
using HospitalManagementSystems.Domain.Dtos.Authentication;
using HospitalManagementSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.DataAccess.Database
{
    public class AccountDbService
    {
        private readonly IDbConnection _connection;

        public AccountDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> OnboardUser(RegistrationDto request, string initiator)
        {
            try
            {
                var query = @"[InsertInto_UserRegistration]";
                var param = new
                {
                    UserName = request.UserName,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    FullName = request.UserName,
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    Role = request.Role,
                    CreatedBy = initiator
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task UpdateFailedLogin(string username, int failedcount, bool isLockedOut)
        {
            try
            {
                var query = @"[UpdateFailedLogin]";
                var param = new
                {
                    UserName = username,
                    FailedCount = failedcount,
                    isLockedOut = isLockedOut
                };
                await _connection.QueryFirstAsync<int>(query, param, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

            }
        }

        public async Task<User> GetUser(string username)
        {
            try
            {
                var query = @"[GetUser]";
                var param = new
                {
                    Username = username
                };
                return await _connection.QueryFirstOrDefaultAsync<User>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<User> Authenticate(string username)
        {
            try
            {
                var query = @"[LoginUser]";
                var param = new
                {
                    UserName = username
                };
                return await _connection.QueryFirstOrDefaultAsync<User>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
