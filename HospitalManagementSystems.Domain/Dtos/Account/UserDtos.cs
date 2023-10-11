using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Authentication
{
    public class UserDtos
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool LockOutEnabled { get; set; }
        public int PasswordTrail { get; set; }
    }
}
