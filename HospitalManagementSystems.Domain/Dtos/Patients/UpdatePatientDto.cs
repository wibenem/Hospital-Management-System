using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Patients
{
    public class UpdatePatientDto
    {
        public int Id { get; set; }
        public string PatientsName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Address { get; set; }
    }
}
