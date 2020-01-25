using LikdensDentalClinic.Core.Services;
using LikdensDentalClinic.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LikdensDentalClinic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [Route("getPatients")]
        public IActionResult GetPatients()
        {
            return Ok(_patientService.GetPatients());
        }

        [Route("getPatientById/{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = await _patientService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [Route("createPatient")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDto newPatientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _patientService.CreatePatient(newPatientDto));
        }

        [Route("updatePatientById")]
        public async Task<IActionResult> UpdatePatientById([FromBody] PatientDto newPatientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newPatientDto.Id > -1)
            {
                return BadRequest();
            }

            return Ok(await _patientService.UpdatePatient(newPatientDto));
        }

        [HttpDelete("deletePatientById/{id}")]
        public async Task<IActionResult> DeletePatientById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _patientService.DeletePatient(id);

            return Ok();
        }
    }
}