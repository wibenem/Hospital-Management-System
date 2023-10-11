using HospitalManagementSystems.Domain.Dtos.Authentication;
using HospitalManagementSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.BusinesLogic.Interface
{
    public interface IAccount
    {
        Task<APIResponse<TokenDto>> Login(LoginDto request);
        Task<APIResponse<UserDto>> CreateRegistration(RegistrationDto request);
    }
}

