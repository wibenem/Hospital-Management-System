using HospitalManagementSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Doctors
{
    public class CreateDoctorDto
    {
        public String FullNames { get; set; }
        public String? MaritalStatus { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? UserName { get; set; }
        public string Specialty { get; set; }
        public string Grade { get; set; }
        public DateTime? DateEmployed { get; set; }
    }
}
