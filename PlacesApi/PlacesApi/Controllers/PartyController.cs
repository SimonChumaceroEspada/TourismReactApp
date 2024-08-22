using Microsoft.AspNetCore.Mvc;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Interfaces;

namespace PlacesApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService _partyService;

        public PartyController(IPartyService partyService)
        {
            _partyService = partyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParties()
        {
            var parties = await _partyService.GetAllPartiesAsync();
            return Ok(parties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartyById(int id)
        {
            var party = await _partyService.GetPartyByIdAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            return Ok(party);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPartyByName([FromQuery] string name)
        {
            try
            {
                var party = await _partyService.GetPartyByNameAsync(name);
                return Ok(party);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}