using HospitalManagementSystem.BusinessLogic.Interface;
using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.Domain.Dtos.AdminStaffs;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminStaffController : ControllerBase
    {
        private readonly IAdminStaff _repo;


        public AdminStaffController(IAdminStaff repo)
        {
            _repo = repo;
        }





        [HttpGet]
        public async Task<object> GetAdminStaff(int pageNumber, int pageSize)
        {
            var res = await _repo.GetAdminStaff(pageNumber, pageSize);
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
        public async Task<object> GetSingleAdminStaff(int Id)
        {
            var res = await _repo.GetSingleAdminStaff(Id);
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
        public async Task<ActionResult> CreateAdminStaff([FromBody] CreateAdminStaffDto request)
        {
            var res = await _repo.CreateAdminStaff(request);
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
        public async Task<ActionResult> UpdateAdminStaff([FromBody] UpdateAdminStaffDto request)
        {
            var res = await _repo.UpdateAdminStaff(request);
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
