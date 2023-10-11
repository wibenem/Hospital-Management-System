using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Models
{
    internal class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Specialty { get; set; }
        public string Grade { get; set; }
        public DateTime? DateEmployed { get; set; }
     
    }
}
