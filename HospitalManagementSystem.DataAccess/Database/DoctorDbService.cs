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
    public class DoctorDbService
    {
        private readonly IDbConnection _connection;

        public DoctorDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateDoctor(Doctor request)
        {
            try
            {
                var query = @"[InsertInto_Doctors]";
                var param = new
                {
                    FullNames = request.FullNames,
                    MaritalStatus = request.MaritalStatus,
                    Age = request.Age,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Email = request.Email,
                    Address = request.Address,
                    UserName = request.UserName,
                    Specialty = request.Specialty,
                    Grade = request.Grade,
                    DateEmployed = request.DateEmployed,

                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<Doctor> SingleDoctor(int Id)
        {
            Doctor Doctor = new Doctor();
            try
            {
                var query = @"[GetDoctors]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Doctor>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return Doctor;
            }
            return null;
        }


        public async Task<APIListResponse3<Doctor>> GetDoctor(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Doctor>();
            try
            {
                var query = @"[GetAllDoctors]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Doctor>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Doctor>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateDoctor(Doctor request)
        {
            try
            {
                var query = @"[Update_Doctors]";
                var param = new
                {
                    FullNames = request.FullNames,
                    MaritalStatus = request.MaritalStatus,
                    Age = request.Age,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Email = request.Email,
                    Address = request.Address,
                    UserName = request.UserName,
                    Specialty = request.Specialty,
                    Grade = request.Grade,
                    DateEmployed = request.DateEmployed,
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
