using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string BloodGroup { get; set; }
    }
}
