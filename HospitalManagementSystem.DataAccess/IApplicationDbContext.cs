using HospitalManagementSystems.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.DataAccess
{

    public interface IApplicationDbContext
    {
        DbSet<Doctor> Doctors { get; set; }
        DbSet<AdminStaff> AdminStaffs { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<MedicalSupportStaff> MedicalSupportStaffs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

