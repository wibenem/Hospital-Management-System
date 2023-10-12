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
                var query = @"[InsertInto_Doctor]";
                var param = new
                {
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
                var query = @"[GetDoctor]";
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
                var query = @"[GetAllDoctor]";
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
                var query = @"[Update_Doctor]";
                var param = new
                {
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
