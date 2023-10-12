using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Doctors
{
    public class CreateDoctorsDto
    {
        public string Specialty { get; set; }
        public string Grade { get; set; }
        public DateTime? DateEmployed { get; set; }
    }
}
