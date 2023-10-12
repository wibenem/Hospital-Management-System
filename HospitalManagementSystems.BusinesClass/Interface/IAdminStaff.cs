using HospitalManagementSystems.Domain.Dtos.AdminStaffs;
using HospitalManagementSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.BusinessLogic.Interface
{
    public interface IAdminStaff
    {
        
        Task<APIListResponse3<AdminStaff>> GetAdminStaff(int pageNumber, int pageSize);
        Task<APIResponse<AdminStaff>> GetSingleAdminStaff(int Id);
        Task<APIResponse<CreateAdminStaffDto>> CreateAdminStaff(CreateAdminStaffDto request);
        Task<APIResponse<UpdateAdminStaffDto>> UpdateAdminStaff(UpdateAdminStaffDto request);
    }
}

