using Microsoft.AspNetCore.Mvc;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Interfaces;

namespace PlacesApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesDataController : ControllerBase
    {
        private readonly IPlacesDataService _placesDataService;

        public PlacesDataController(IPlacesDataService placesDataService)
        {
            _placesDataService = placesDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlacesData()
        {
            var placesData = await _placesDataService.GetAllPlacesDataAsync();
            return Ok(placesData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlacesDataById(int id)
        {
            var placesData = await _placesDataService.GetPlacesDataByIdAsync(id);
            if (placesData == null)
            {
                return NotFound();
            }
            return Ok(placesData);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPlacesDataByName([FromQuery] string name)
        {
            try
            {
                var placesData = await _placesDataService.GetPlacesDataByNameAsync(name);
                return Ok(placesData);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
       

    }
}
    