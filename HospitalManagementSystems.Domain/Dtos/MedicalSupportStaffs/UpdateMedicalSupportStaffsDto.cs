﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.MedicalSupportStaffs
{
    public class UpdateMedicalSupportStaffsDto
    {
        public int Id { get; set; }
        public string MedicalSupportStaffsName { get; set; }
        public string Descripton { get; set; }
    }
}
