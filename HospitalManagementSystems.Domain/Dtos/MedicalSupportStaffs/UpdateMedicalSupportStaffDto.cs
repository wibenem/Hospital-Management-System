using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.MedicalSupportStaffs
{
    public class UpdateMedicalSupportStaffDto
    {
        public int Id { get; set; }
        public string MedicalSupportStaffsName { get; set; }
        public string Role { get; set; }
        public DateTime DateEmployed { get; set; }


    }
}
