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

        // [HttpPost]
        // public async Task<IActionResult> CreatePlace([FromBody] CreatePlaceDto createPlaceDto)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     await _placeService.CreatePlaceAsync(createPlaceDto);
        //     return CreatedAtAction(nameof(GetPlaceById), new { id = createPlaceDto.Id }, createPlaceDto);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdatePlace(int id, [FromBody] UpdatePlaceDto updatePlaceDto)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     try
        //     {
        //         await _placeService.UpdatePlaceAsync(id, updatePlaceDto);
        //     }
        //     catch (KeyNotFoundException)
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePlace(int id)
        // {
        //     try
        //     {
        //         await _placeService.DeletePlaceAsync(id);
        //     }
        //     catch (KeyNotFoundException)
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }
    }
}
