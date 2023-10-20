using HospitalManagementSystem.BusinessLogic.Interface;
using HospitalManagementSystem.BusinessLogic.Repository;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.BusinesLogic.Repository;
using HospitalManagementSystems.DataAccess;
using HospitalManagementSystems.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hospital_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IDbConnection>(prov => new SqlConnection(prov.GetService<IConfiguration>().GetConnectionString("DefaultConnection")));





            builder.Services.AddEndpointsApiExplorer();



            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





            builder.Services.AddSwaggerGen();



            builder.Services.AddScoped<HospitalManagementSystems.BusinesLogic.Interface.IPatient, HospitalManagementSystems.BusinesLogic.Repository.PatientRepo >();
            builder.Services.AddScoped<IAdminStaff, AdminStaffRepo>();
            builder.Services.AddScoped<IMedicalSupportStaff, MedicalSupportStaffRepo>();
            builder.Services.AddScoped<IDoctor, DoctorRepo>();
            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();



            app.UseAuthorization();



            app.MapControllers();



            app.Run();
        }
            
    }
}