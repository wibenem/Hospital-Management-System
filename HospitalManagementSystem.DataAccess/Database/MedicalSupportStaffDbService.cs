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
    public class MedicalSupportStaffDbService
    {
        private readonly IDbConnection _connection;

        public MedicalSupportStaffDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateMedicalSupportStaff(MedicalSupportStaff request)
        {
            try
            {
                var query = @"[InsertInto_MedicalSupportStaff]";
                var param = new
                {
                    Role = request.Role,
                    DateEmployed = request.DateEmployed,

                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<MedicalSupportStaff> SingleMedicalSupportStaff(int Id)
        {
            MedicalSupportStaff MedicalSupportStaff = new MedicalSupportStaff();
            try
            {
                var query = @"[GetMedicalSupportStaff]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<MedicalSupportStaff>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return MedicalSupportStaff;
            }
            return null;
        }


        public async Task<APIListResponse3<MedicalSupportStaff>> GetMedicalSupportStaff(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<MedicalSupportStaff>();
            try
            {
                var query = @"[GetAllMedicalSupportStaff]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<MedicalSupportStaff>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<MedicalSupportStaff>.ToPagedList(result, pageNumber, pageSize);
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


        public async Task<int> UpdateMedicalSupportStaff(MedicalSupportStaff request)
        {
            try
            {
                var query = @"[Update_MedicalSupportStaff]";
                var param = new
                {
                    Role = request.Role,
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
