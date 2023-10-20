using Dapper;
using HospitalManagementSystems.Domain.Models;
using HospitalManagementSystems.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.DataAccess.Database
{
    public class PatientDbService
    {
        private readonly IDbConnection _connection;

        public PatientDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreatePatient(Patient request)
        {
            try
            {
                var query = @"[InsertInto_Patients]";
                var param = new
                {
                    FullNames = request.FullNames,
                    MaritalStatus = request.MaritalStatus,
                    Age = request.Age,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Email = request.Email,
                    Address = request.Address,
                    Username = request.UserName,
                    Height = request.Height,
                    Weight = request.Weight,
                    BloodGroup = request.BloodGroup,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<Patient> SinglePatient(int Id)
        {
            Patient Patient = new Patient();
            try
            {
                var query = @"[GetPatients]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Patient>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return Patient;
            }
            return null;
        }


        public async Task<APIListResponse3<Patient>> GetPatient(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Patient>();
            try
            {
                var query = @"[GetAllPatients]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<Patient>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Patient>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdatePatient(Patient request)
        {
            try
            {
                var query = @"[Update_Patients]";
                var param = new 
                {
                    Id  = request.Id, 
                    Height = request.Height,
                    Weight = request.Weight,
                    BloodGroup = request.BloodGroup,
                    FullNames = request.FullNames,
                    MaritalStatus = request.MaritalStatus,
                    Age = request.Age,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Email = request.Email,
                    Address = request.Address,
                    UserName = request.UserName,
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