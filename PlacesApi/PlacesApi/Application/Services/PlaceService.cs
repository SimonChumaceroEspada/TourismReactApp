using PlacesApi.Domain.Interfaces;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Entities;

namespace PlacesApi.Application.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<IEnumerable<PlaceDto>> GetAllPlacesAsync()
        {
            var places = await _placeRepository.GetAllAsync();
            return places.Select(p => new PlaceDto
            {
                Id = p.id,
                Name = p.name,
                Capital = p.capital,
                Image = p.image,
                EspDescription = p.esp_description,
                EngDescription = p.eng_description
            }).ToList();
        }

        public async Task<PlaceDto> GetPlaceByIdAsync(int id)
        {
            var place = await _placeRepository.GetByIdAsync(id);
            if (place == null)
            {
                return null;
            }

            return new PlaceDto
            {
                Id = place.id,
                Name = place.name,
                Capital = place.capital,
                Image = place.image,
                EspDescription = place.esp_description,
                EngDescription = place.eng_description
            };
        }

        public async Task<PlaceDto> GetPlacesByNameAsync(string name)
        {
            var place = await _placeRepository.GetByNameAsync(name);
            if (place == null)
            {
                throw new KeyNotFoundException($"Place with name '{name}' not found.");
            }

            return new PlaceDto
            {
                Id = place.id,
                Name = place.name,
                Capital = place.capital,
                Image = place.image,
                EspDescription = place.esp_description,
                EngDescription = place.eng_description
            };
        }
    }
}
