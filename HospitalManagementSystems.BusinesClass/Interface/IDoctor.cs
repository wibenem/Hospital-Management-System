using HospitalManagementSystems.Domain.Dtos.Doctors;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.BusinesLogic.Interface
{
    public interface IDoctor
    {
        Task<APIListResponse3<Doctor>> GetDoctor(int pageNumber, int pageSize);
        Task<APIResponse<Doctor>> GetSingleDoctor(int Id);
        Task<APIResponse<CreateDoctorDto>> CreateDoctor(CreateDoctorDto request);
        Task<APIResponse<UpdateDoctorDto>> UpdateDoctor(UpdateDoctorDto request);
    }
}
