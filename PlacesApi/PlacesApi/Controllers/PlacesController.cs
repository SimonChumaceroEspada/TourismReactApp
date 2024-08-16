using Microsoft.AspNetCore.Mvc;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Interfaces;

namespace PlacesApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllPlacesAsync();
            return Ok(places);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaceById(int id)
        {
            var place = await _placeService.GetPlaceByIdAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPlacesByName([FromQuery] string name)
        {
            try
            {
                var place = await _placeService.GetPlacesByNameAsync(name);
                return Ok(place);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
