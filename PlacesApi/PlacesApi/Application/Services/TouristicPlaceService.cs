using PlacesApi.Domain.Interfaces;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Entities;


namespace PlacesApi.Application.Services
{
    public class TouristicPlaceService : ITouristicPlaceService
    {
        private readonly ITouristicPlaceRepository _touristicPlaceRepository;

        public TouristicPlaceService(ITouristicPlaceRepository touristicPlaceRepository)
        {
            _touristicPlaceRepository = touristicPlaceRepository;
        }

        public async Task<IEnumerable<TouristicPlaceDto>> GetAllTouristicPlaceAsync()
        {
            var touristicPlaces = await _touristicPlaceRepository.GetAllAsync();
            return touristicPlaces.Select(p => new TouristicPlaceDto
            {
                Id = p.Id,
                EspName = p.EspName,
                EngName = p.EngName,
                Image = p.Image,
                EspDescription = p.EspDescription,
                EngDescription = p.EngDescription,
                PlaceId = p.PlaceId
            }).ToList();
        }

        public async Task<TouristicPlaceDto> GetTouristicPlaceByIdAsync(int id)
        {
            var touristicPlace = await _touristicPlaceRepository.GetByIdAsync(id);
            if (touristicPlace == null)
            {
                return null;
            }

            return new TouristicPlaceDto
            {
                Id = touristicPlace.Id,
                EspName = touristicPlace.EspName,
                EngName = touristicPlace.EngName,
                Image = touristicPlace.Image,
                EspDescription = touristicPlace.EspDescription,
                EngDescription = touristicPlace.EngDescription,
                PlaceId = touristicPlace.PlaceId
            };
        }

        public async Task<TouristicPlaceDto> GetTouristicPlaceByNameAsync(string name)
        {
            var touristicPlace = await _touristicPlaceRepository.GetByNameAsync(name);
            if (touristicPlace == null)
            {
                throw new KeyNotFoundException($"Touristic place with name '{name}' not found.");
            }

            return new TouristicPlaceDto
            {
                Id = touristicPlace.Id,
                EspName = touristicPlace.EspName,
                EngName = touristicPlace.EngName,
                Image = touristicPlace.Image,
                EspDescription = touristicPlace.EspDescription,
                EngDescription = touristicPlace.EngDescription,
                PlaceId = touristicPlace.PlaceId
            };
        }
    }
}