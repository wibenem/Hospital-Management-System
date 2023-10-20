using AutoMapper;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.DataAccess.Database;
using HospitalManagementSystems.Domain.Dtos.Doctors;
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
    public class DoctorRepo : IDoctor
    {
        private readonly IDbConnection _connection;
        private readonly DoctorDbService service;
        private readonly IMapper _mapper;
        public DoctorRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new DoctorDbService(connection);
        }
        public async Task<APIResponse<CreateDoctorDto>> CreateDoctor(CreateDoctorDto request)
        {
            var response = new APIResponse<CreateDoctorDto>();
            var model = _mapper.Map<Doctor>(request);
            var result = await service.CreateDoctor(model);

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

        public Task<APIResponse<CreateDoctorDto>> CreateDoctors(CreateDoctorDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<APIListResponse3<Doctor>> GetDoctor(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Doctor>();
            var result = await service.GetDoctor(pageNumber, pageSize);
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

        public async Task<APIResponse<Doctor>> GetSingleDoctor(int Id)
        {
            var response = new APIResponse<Doctor>();
            var result = await service.SingleDoctor(Id);

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



        public async Task<APIResponse<UpdateDoctorDto>> UpdateDoctor(UpdateDoctorDto request)
        {
            var response = new APIResponse<UpdateDoctorDto>();
            var model = _mapper.Map<Doctor>(request);
            var result = await service.UpdateDoctor(model);

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
