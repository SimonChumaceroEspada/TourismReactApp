using PlacesApi.Domain.Interfaces;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Entities;

namespace PlacesApi.Application.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;

        public PartyService(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        public async Task<IEnumerable<PartyDTO>> GetAllPartiesAsync()
        {
            var parties = await _partyRepository.GetAllAsync();
            return parties.Select(p => new PartyDTO
            {
                Id = p.id,
                EspName = p.esp_name,
                EngName = p.eng_name,
                EspDescription = p.esp_description,
                EngDescription = p.eng_description,
                Image = p.image,
                PlaceId = p.place_id,
            }).ToList();
        }

        public async Task<PartyDTO> GetPartyByIdAsync(int id)
        {
            var party = await _partyRepository.GetByIdAsync(id);
            if (party == null)
            {
                return null;
            }

            return new PartyDTO
            {
                Id = party.id,
                EspName = party.esp_name,
                EngName = party.eng_name,
                Image = party.image,
                EspDescription = party.esp_description,
                EngDescription = party.eng_description,
                PlaceId = party.place_id,
            };
        }

        public async Task<PartyDTO> GetPartyByNameAsync(string name)
        {
            var party = await _partyRepository.GetByNameAsync(name);
            if (party == null)
            {
                throw new KeyNotFoundException($"Party with name '{name}' not found.");
            }

            return new PartyDTO
            {
                Id = party.id,
                EspName = party.esp_name,
                EngName = party.eng_name,
                Image = party.image,
                EspDescription = party.esp_description,
                EngDescription = party.eng_description,
                PlaceId = party.place_id,
            };
        }
    }
}