using HospitalManagementSystem.BusinessLogic.Interface;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.Domain.Dtos.MedicalSupportStaffs;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MedicalSupportStaffController : ControllerBase
    {
        private readonly IMedicalSupportStaff _repo;



        public MedicalSupportStaffController(IMedicalSupportStaff repo)
        {
            _repo = repo;
        }





        [HttpGet]
        public async Task<object> GetMedicalSupportStaff(int pageNumber, int pageSize)
        {
            var res = await _repo.GetMedicalSupportStaff(pageNumber, pageSize);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }



        [HttpGet]
        public async Task<object> GetSingleMedicalSupportStaff(int Id)
        {
            var res = await _repo.GetSingleMedicalSupportStaff(Id);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }





        [HttpPost]
        public async Task<ActionResult> CreateMedicalSupportStaff([FromBody] CreateMedicalSupportStaffDto request)
        {
            var res = await _repo.CreateMedicalSupportStaff(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("06"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }



        [HttpPut]
        public async Task<ActionResult> UpdateMedicalSupportStaff([FromBody] UpdateMedicalSupportStaffDto request)
        {
            var res = await _repo.UpdateMedicalSupportStaff(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }
    }
}
