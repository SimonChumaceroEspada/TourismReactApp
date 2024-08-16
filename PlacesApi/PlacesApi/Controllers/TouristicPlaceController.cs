using Microsoft.AspNetCore.Mvc;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Interfaces;

namespace PlacesApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TouristicPlaceController : ControllerBase
    {
        private readonly ITouristicPlaceService _touristicPlaceService;

        public TouristicPlaceController(ITouristicPlaceService touristicPlaceService)
        {
            _touristicPlaceService = touristicPlaceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTouristicPlaces()
        {
            var touristicPlaces = await _touristicPlaceService.GetAllTouristicPlaceAsync();
            return Ok(touristicPlaces);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTouristicPlaceById(int id)
        {
            var touristicPlace = await _touristicPlaceService.GetTouristicPlaceByIdAsync(id);
            if (touristicPlace == null)
            {
                return NotFound();
            }
            return Ok(touristicPlace);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetTouristicPlaceByName([FromQuery] string name)
        {
            try
            {
                var touristicPlace = await _touristicPlaceService.GetTouristicPlaceByNameAsync(name);
                return Ok(touristicPlace);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}