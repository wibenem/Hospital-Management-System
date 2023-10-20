using Dapper;
using HospitalManagementSystems.Domain.Models;
using HospitalManagementSystems.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.DataAccess.Database
{
    public class AdminStaffDbService
    {
        private readonly IDbConnection _connection;

        public AdminStaffDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateAdminStaff(AdminStaff request)
        {
            try
            {
                var query = @"[InsertInto_AdminStaffs]";
                var param = new
                {
                    Role = request.Role,
                    DateEmployed = request.DateEmployed,
                    FullNames = request.FullNames,
                    MaritalStatus = request.MaritalStatus,
                    Age = request.Age,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Email = request.Email,
                    Address = request.Address,
                    Username = request.UserName,

                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<AdminStaff> SingleAdminStaff(int Id)
        {
            AdminStaff AdminStaff = new AdminStaff();
            try
            {
                var query = @"[GetAdminStaffs]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<AdminStaff>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return AdminStaff;
            }
            return null;
        }


        public async Task<APIListResponse3<AdminStaff>> GetAdminStaff(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<AdminStaff>();
            try
            {
                var query = @"[GetAllAdminStaffs]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<AdminStaff>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<AdminStaff>.ToPagedList(result, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contatins no elements"))
                {
                    response.Code = "01";
                }
            }
            return response;
        }


        public async Task<int> UpdateAdminStaff(AdminStaff request)
        {
            try
            {
                var query = @"[Update_AdminStaffs]";
                var param = new
                {
                    Role = request.Role,
                    DateEmployed = request.DateEmployed,
                    FullNames = request.FullNames,
                    MaritalStatus = request.MaritalStatus,
                    Age = request.Age,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Email = request.Email,
                    Address = request.Address,
                    Username = request.UserName,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

    }
}
