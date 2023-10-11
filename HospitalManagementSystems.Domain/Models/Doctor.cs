using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Models
{
    public class Doctor
    {
        [Key]
        public string DoctorName { get; set; }
        public int Id { get; set; }
        public string Specialty { get; set; }
        public string Grade { get; set; }
        public DateTime? DateEmployed { get; set; }
     
    }
}
