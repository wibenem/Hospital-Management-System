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
                var query = @"[InsertInto_Patient]";
                var param = new
                {
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
                var query = @"[GetPatient]";
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
                var query = @"[Update_Patient]";
                var param = new
                {
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

    }
}