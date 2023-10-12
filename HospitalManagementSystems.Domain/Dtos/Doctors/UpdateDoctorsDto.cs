﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Doctors
{
    public class UpdateDoctorsDto
    {
        public int Id { get; set; }
        public string DoctorsName { get; set; }
        public string Specialty { get; set; }
        public DateTime DateEmployed{ get; set; }
    }
}
