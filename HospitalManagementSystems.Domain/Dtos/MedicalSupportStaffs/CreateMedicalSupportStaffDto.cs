using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.MedicalSupportStaffs
{
    public class CreateMedicalSupportStaffDto
    {
        public string Id { get; set; }
        public string Role { get; set; }
        
        public DateTime DateEmployed { get; set; }
    }
}
