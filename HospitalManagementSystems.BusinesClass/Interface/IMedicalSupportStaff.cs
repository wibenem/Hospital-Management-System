using HospitalManagementSystems.Domain.Dtos.MedicalSupportStaffs;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.BusinessLogic.Interface
{
    public interface IMedicalSupportStaff
    {
        Task<APIListResponse3<MedicalSupportStaff>> GetMedicalSupportStaff(int pageNumber, int pageSize);
        Task<APIResponse<MedicalSupportStaff>> GetSingleMedicalSupportStaff(int Id);
        Task<APIResponse<CreateMedicalSupportStaffDto>> CreateMedicalSupportStaff(CreateMedicalSupportStaffDto request);
        Task<APIResponse<UpdateMedicalSupportStaffDto>> UpdateMedicalSupportStaff(UpdateMedicalSupportStaffDto request);
    }
}
