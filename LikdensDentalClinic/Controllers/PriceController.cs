using LikdensDentalClinic.Core.Services;
using LikdensDentalClinic.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LikdensDentalClinic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly PriceService _priceService;

        public PriceController(PriceService priceService)
        {
            _priceService = priceService;
        }

        [Route("getPrices")]
        public IActionResult GetPrices()
        {
            return Ok(_priceService.GetPrices());
        }

        [Route("getPriceById/{id}")]
        public async Task<IActionResult> GetPriceById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var price = await _priceService.GetPriceById(id);

            if (price == null)
            {
                return NotFound();
            }

            return Ok(price);
        }

        [Route("createPrice")]
        public async Task<IActionResult> CreatePrice([FromBody] PriceDto newPriceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _priceService.CreatePrice(newPriceDto));
        }

        [Route("updatePriceById")]
        public async Task<IActionResult> UpdatePriceById([FromBody] PriceDto newPriceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newPriceDto.Id > -1)
            {
                return BadRequest();
            }

            return Ok(await _priceService.UpdatePrice(newPriceDto));
        }

        [HttpDelete("deletePriceById/{id}")]
        public async Task<IActionResult> DeletePriceById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _priceService.DeletePrice(id);

            return Ok();
        }
    }
}