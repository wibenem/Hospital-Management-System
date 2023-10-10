using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Models
{
    internal class BaseEntity
    {
        public String? FullNames { get; set; }
        public String? MaritalStatus { get; set; }
        public int? Age { get; set; }
        public bool Gender { get; set; }
        public ushort Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
