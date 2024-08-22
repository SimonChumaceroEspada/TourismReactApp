using Microsoft.AspNetCore.Mvc;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Interfaces;

namespace PlacesApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            var foods = await _foodService.GetAllFoodAsync();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetFoodByName([FromQuery] string name)
        {
            try
            {
                var food = await _foodService.GetFoodByNameAsync(name);
                return Ok(food);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}