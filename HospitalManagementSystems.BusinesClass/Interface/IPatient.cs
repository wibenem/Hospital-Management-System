using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.BusinesLogic.Interface
{
    public interface IPatient
    {
        Task<APIListResponse3<Patient>> GetPatient(int pageNumber, int pageSize);
        Task<APIResponse<Patient>> GetSinglePatient(int Id);
        Task<APIResponse<CreatePatientDto>> CreatePatient(CreatePatientDto request);
        Task<APIResponse<UpdatePatientDto>> UpdatePatient(UpdatePatientDto request);
    }
}
