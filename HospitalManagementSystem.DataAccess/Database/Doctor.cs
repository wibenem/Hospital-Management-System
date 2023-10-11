using Dapper;
using HospitalManagementSystems.Domain.Models;
using HospitalManagementSystems.Domain.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.DataAccess.Database
{
    public class Doctor
    {
         
        private readonly IDbConnection _connection;

        public Doctor(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateExpense(Doctor request)
        {
            try
            {
                var query = @"[InsertInto_Expense]";
                var param = new
                {
                    ExpensesName = request.DoctorName,
                    Amount = request.Amount,
                    Description = request.Description,
                    CreatedBy = request.CreatedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public async Task<Doctor> SingleExpense(int Id)
        {
            Doctor expenses = new Doctor();
            try
            {
                var query = @"[GetExpense]";
                var param = new { Id = Id };
                return await _connection.QueryFirstAsync<Doctor>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("Sequence contain no elements"))
                    return expenses;
            }
            return null;
        }


        public async Task<APIListResponse3<Doctor>> GetExpenses(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Doctor>();
            try
            {
                var query = @"[GetAllExpenses]";
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


        public async Task<int> UpdateExpense(Doctor request)
        {
            try
            {
                var query = @"[Update_Expense]";
                var param = new
                {
                    DoctorName = request.DoctorName,
                    Amount = request.Amount,
                    Description = request.Description,
                    ModifiedBy = request.ModifiedBy,
                    Id = request.Id
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

