using HospitalManagementSystems.BusinesLogic.Interface;
using HospitalManagementSystems.Domain.Dtos.Patients;
using HospitalManagementSystems.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
   
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatient _repo;



        public PatientController(IPatient repo)
        {
            _repo = repo;
        }





        [HttpGet]
        public async Task<object> GetPatient(int pageNumber, int pageSize)
        {
            var res = await _repo.GetPatient(pageNumber, pageSize);
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
        public async Task<object> GetSinglePatient(int Id)
        {
            var res = await _repo.GetSinglePatient(Id);
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
        public async Task<ActionResult> CreatePatient([FromBody] CreatePatientDto request)
        {
            var res = await _repo.CreatePatient(request);
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
        public async Task<ActionResult> UpdatePatient([FromBody] UpdatePatientDto request)
        {
            var res = await _repo.UpdatePatient(request);
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

