using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Models
{
    public class MedicalSupportStaff : BaseEntity
    {
        
        public int Id { get; set; }
        public string Role { get; set; }
        public DateTime? DateEmployed { get; set; }
    }
}
