using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystems.DataAccess.Migrations
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<AdminStaff> AdminStaffs { get; set; }
        public DbSet<MedicalSupportStaff> MedicalSupportStaffs { get; set; }
        DbSet<Doctor> IApplicationDbContext.Doctors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<AdminStaff> IApplicationDbContext.AdminStaffs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<Patient> IApplicationDbContext.Patients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<MedicalSupportStaff> IApplicationDbContext.MedicalSupportStaffs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{envName}.json", optional: true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        }
    }

}