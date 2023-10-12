using AutoMapper;
using HospitalManagementSystem.BusinessLogic.Interface;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.DataAccess.Database;
using HospitalManagementSystems.Domain.Dtos.MedicalSupportStaffs;
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
    public class MedicalSupportStaffRepo : IMedicalSupportStaff
    {
        private readonly IDbConnection _connection;
        private readonly MedicalSupportStaffDbService service;
        private readonly IMapper _mapper;
        public MedicalSupportStaffRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new MedicalSupportStaffDbService(connection);
        }
        public async Task<APIResponse<CreateMedicalSupportStaffDto>> CreateMedicalSupportStaff(CreateMedicalSupportStaffDto request)
        {
            var response = new APIResponse<CreateMedicalSupportStaffDto>();
            var model = _mapper.Map<MedicalSupportStaff>(request);
            var result = await service.CreateMedicalSupportStaff(model);

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

        public Task<APIResponse<CreateMedicalSupportStaffDto>> CreateMedicalSupportStaffs(CreateMedicalSupportStaffDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<APIListResponse3<MedicalSupportStaff>> GetMedicalSupportStaff(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<MedicalSupportStaff>();
            var result = await service.GetMedicalSupportStaff(pageNumber, pageSize);
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

        public async Task<APIResponse<MedicalSupportStaff>> GetSingleMedicalSupportStaff(int Id)
        {
            var response = new APIResponse<MedicalSupportStaff>();
            var result = await service.SingleMedicalSupportStaff(Id);

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



        public async Task<APIResponse<UpdateMedicalSupportStaffDto>> UpdateMedicalSupportStaff(UpdateMedicalSupportStaffDto request)
        {
            var response = new APIResponse<UpdateMedicalSupportStaffDto>();
            var model = _mapper.Map<MedicalSupportStaff>(request);
            var result = await service.UpdateMedicalSupportStaff(model);

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
