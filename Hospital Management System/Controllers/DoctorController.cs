using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.Domain.Dtos.Doctors;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctor _repo;



        public DoctorController(IDoctor repo)
        {
            _repo = repo;
        }





        [HttpGet]
        public async Task<object> GetDoctor(int pageNumber, int pageSize)
        {
            var res = await _repo.GetDoctor(pageNumber, pageSize);
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
        public async Task<object> GetSingleDoctor(int Id)
        {
            var res = await _repo.GetSingleDoctor(Id);
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
        public async Task<ActionResult> CreateDoctor([FromBody] CreateDoctorDto request)
        {
            var res = await _repo.CreateDoctor(request);
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
        public async Task<ActionResult> UpdateDoctor([FromBody] UpdateDoctorDto request)
        {
            var res = await _repo.UpdateDoctor(request);
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
