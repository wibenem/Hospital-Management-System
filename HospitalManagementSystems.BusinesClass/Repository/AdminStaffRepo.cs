using AutoMapper;
using HospitalManagementSystem.BusinessLogic.Interface;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.DataAccess.Database;
using HospitalManagementSystems.Domain.Dtos.AdminStaffs;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.BusinessLogic.Repository
{
    public class AdminStaffRepo : IAdminStaff
    {
        private readonly IDbConnection _connection;
        private readonly AdminStaffDbService service;
        private readonly IMapper _mapper;
        public AdminStaffRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new AdminStaffDbService(connection);
        }
        public async Task<APIResponse<CreateAdminStaffDto>> CreateAdminStaff(CreateAdminStaffDto request)
        {
            var response = new APIResponse<CreateAdminStaffDto>();
            var model = _mapper.Map<AdminStaff>(request);
            var result = await service.CreateAdminStaff(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else if (result == -1)
            {
                response.Code = "01";
                response.Description = "Record Already Exist";
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occuried, Please try again later";
            }
            return response;
        }

        public Task<APIResponse<CreateAdminStaffDto>> CreateAdminStaffs(CreateAdminStaffDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<APIListResponse3<AdminStaff>> GetAdminStaff(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<AdminStaff>();
            var result = await service.GetAdminStaff(pageNumber, pageSize);
            if (result != null)
            {
                if (result.Data.Count() > 0)
                {
                    var metadata = new
                    {
                        result.Data.TotalCount,
                        result.Data.PageSize,
                        result.Data.CurrentPage,
                        result.Data.TotalPages,
                        result.Data.HasNext,
                        result.Data.HasPrevious
                    };
                    response.PageInfo = JsonConvert.SerializeObject(metadata);
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result.Data;
                }
                else
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occured, Please try again later";
            }
            return response;
        }

        public async Task<APIResponse<AdminStaff>> GetSingleAdminStaff(int Id)
        {
            var response = new APIResponse<AdminStaff>();
            var result = await service.SingleAdminStaff(Id);

            if (result != null)
            {
                if (result.Id == 0)
                {
                    response.Code = "01";
                    response.Description = "No Record found";
                }
                else
                {
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result;
                }
            }
            else
            {
                response.Code = "01";
                response.Description = "No Record found";
            }
            return response;
        }



        public async Task<APIResponse<UpdateAdminStaffDto>> UpdateAdminStaff(UpdateAdminStaffDto request)
        {
            var response = new APIResponse<UpdateAdminStaffDto>();
            var model = _mapper.Map<AdminStaff>(request);
            var result = await service.UpdateAdminStaff(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occured, Please try again later";
            }
            return response;
        }
    }
}
