using AutoMapper;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.DataAccess.Database;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.BusinesLogic.Repository
{
    public class PatientRepo : IPatient
    {
        private readonly IDbConnection _connection;
        private readonly PatientDbService service;
        private readonly IMapper _mapper;
        public PatientRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new PatientDbService(connection);
        }
        public async Task<APIResponse<CreatePatientDto>> CreateExpense(CreatePatientDto request)
        {
            var response = new APIResponse<CreatePatientDto>();
            var model = _mapper.Map<Patient>(request);
            var result = await service.CreatePatient(model);

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

        public Task<APIResponse<CreatePatientDto>> CreatePatient(CreatePatientDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<APIListResponse3<Patient>> GetPatient(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Patient>();
            var result = await service.GetPatient(pageNumber, pageSize);
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

        public async Task<APIResponse<Patient>> GetSinglePatient(int Id)
        {
            var response = new APIResponse<Patient>();
            var result = await service.SinglePatient(Id);

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



        public async Task<APIResponse<UpdatePatientDto>> UpdatePatient(UpdatePatientDto request)
        {
            var response = new APIResponse<UpdatePatientDto>();
            var model = _mapper.Map<Patient>(request);
            var result = await service.UpdatePatient(model);

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
