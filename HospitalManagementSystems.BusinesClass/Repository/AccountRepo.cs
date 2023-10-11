using AutoMapper;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.DataAccess.Database;
using HospitalManagementSystems.Domain.Dtos.Authentication;
using HospitalManagementSystems.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.BusinesLogic.Repository
{
    public class AccountRepo : IAccount
    {
        private readonly IDbConnection _connection;
        private readonly AccountDbService service;
        private readonly IMapper _mapper;
        private AppSettings _appSettings;
        private readonly TokenSettings _jwtTokenConfig;

        private readonly byte[] _secret;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loggedUser;

        public AccountRepo(IDbConnection connection, IMapper mapper,
            IOptions<AppSettings> appSettings,
            IOptions<TokenSettings> jwtTokenConfig, IHttpContextAccessor httpContextAccessor)
        {
            _connection = connection;
            _mapper = mapper;
            service = new AccountDbService(connection);
            _appSettings = appSettings.Value;
            _jwtTokenConfig = jwtTokenConfig.Value;

            _secret = Encoding.ASCII.GetBytes(_jwtTokenConfig.Secret);

            _httpContextAccessor = httpContextAccessor;
            loggedUser = string.Empty;
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                loggedUser = identity?.Name;
            }
        }

        public async Task<APIResponse<UserDto>> CreateRegistration(RegistrationDto request)
        {
            var response = new APIResponse<UserDto>();

            var validUser = await service.GetUser(request.UserName);
            if (validUser != null)
            {
                response.Code = "06";
                response.Description = "Record Already Exist";
                return response;
            }

            var result = await service.OnboardUser(request, loggedUser);
            if (result > 0)
            {
                response.Code = "00";
                response.Description = "Successful";
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occured, Please try again later";
            }
            return response;
        }

        public Task<APIResponse<TokenDto>> Login(LoginDto request)
        {
            throw new NotImplementedException();
        }
    }
}
