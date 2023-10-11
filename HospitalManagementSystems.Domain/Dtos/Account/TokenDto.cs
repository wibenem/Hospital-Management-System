﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Authentication
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public UserDto UserDetails { get; set; }

    }
}
