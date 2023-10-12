using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.AdminStaffs
{
    public class UpdateAdminStaffDto
    {
        public int Id { get; set; }
        public string AdminStaffsName { get; set; }
        public string Role { get; set; }
        public DateTime? DateEmployed { get; set; }
    }
}
