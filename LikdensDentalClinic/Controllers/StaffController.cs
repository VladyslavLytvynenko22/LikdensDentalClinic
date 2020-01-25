using LikdensDentalClinic.Core.Services;
using LikdensDentalClinic.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LikdensDentalClinic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        [Route("getStaffs")]
        public IActionResult GetStaffs()
        {
            return Ok(_staffService.GetStaffs());
        }

        [Route("getStaffById/{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staff = await _staffService.GetStaffById(id);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        [Route("createStaff")]
        public async Task<IActionResult> CreateStaff([FromBody] StaffDto newStaffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _staffService.CreateStaff(newStaffDto));
        }

        [Route("updateStaffById")]
        public async Task<IActionResult> UpdateStaffById([FromBody] StaffDto newStaffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newStaffDto.Id > -1)
            {
                return BadRequest();
            }

            return Ok(await _staffService.UpdateStaff(newStaffDto));
        }

        [HttpDelete("deleteStaffById/{id}")]
        public async Task<IActionResult> DeleteStaffById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _staffService.DeleteStaff(id);

            return Ok();
        }
    }
}