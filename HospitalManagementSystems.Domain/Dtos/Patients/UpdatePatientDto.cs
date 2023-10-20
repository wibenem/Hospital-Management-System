﻿using HospitalManagementSystems.Domain.Models;
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
        public String FullNames { get; set; }
        public String? MaritalStatus { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? UserName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string BloodGroup { get; set; }
    }
}
