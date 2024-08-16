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
                Id = p.Id,
                Name = p.Name,
                Capital = p.Capital,
                Image = p.Image,
                EspDescription = p.EspDescription,
                EngDescription = p.EngDescription
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
                Id = place.Id,
                Name = place.Name,
                Capital = place.Capital,
                Image = place.Image,
                EspDescription = place.EspDescription,
                EngDescription = place.EngDescription
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
                Id = place.Id,
                Name = place.Name,
                Capital = place.Capital,
                Image = place.Image,
                EspDescription = place.EspDescription,
                EngDescription = place.EngDescription
            };
        }
    }
}
