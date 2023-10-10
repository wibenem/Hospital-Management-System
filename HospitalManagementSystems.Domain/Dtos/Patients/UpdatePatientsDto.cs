using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Patients
{
    public class UpdatePatientsDto
    {
        public int Id { get; set; }
        public string PatientsName { get; set; }
        public string Descripton { get; set; }
    }
}
