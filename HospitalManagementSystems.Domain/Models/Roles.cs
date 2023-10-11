using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Models
{
    public class Role : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}