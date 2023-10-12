using AutoMapper;
using HospitalManagementSystems.Domain.Dtos.AdminStaffs;
using HospitalManagementSystems.Domain.Dtos.MedicalSupportStaffs;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using System.Runtime.InteropServices;

namespace Hospital_Management_System.Extensions
{
    

   public class AutoMapper : Profile

    {

        public AutoMapper()

        {

            CreateMap<Patient, CreatePatientDto>();

            CreateMap<CreatePatientDto, Patient>();

            CreateMap<AdminStaff, CreateAdminStaffDto>();

            CreateMap<CreateAdminStaffDto, AdminStaff>();





            CreateMap<MedicalSupportStaff, CreateMedicalSupportStaffDto>();

            CreateMap<CreateMedicalSupportStaffDto, MedicalSupportStaff>();







        }

    }
}
