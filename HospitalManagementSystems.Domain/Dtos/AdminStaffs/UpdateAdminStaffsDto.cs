using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.AdminStaffs
{
    public class UpdateAdminStaffsDto
    {
        public int Id { get; set; }
        public string AdminStaffsName { get; set; }
        public string Descripton { get; set; }
    }
}
