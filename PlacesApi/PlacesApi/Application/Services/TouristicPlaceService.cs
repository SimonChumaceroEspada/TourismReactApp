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
                Id = p.id,
                EspName = p.esp_name,
                EngName = p.eng_name,
                Image = p.image,
                EspDescription = p.esp_description,
                EngDescription = p.eng_description,
                PlaceId = p.place_id
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
                Id = touristicPlace.id,
                EspName = touristicPlace.esp_name,
                EngName = touristicPlace.eng_name,
                Image = touristicPlace.image,
                EspDescription = touristicPlace.esp_description,
                EngDescription = touristicPlace.eng_description,
                PlaceId = touristicPlace.place_id,
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
                Id = touristicPlace.id,
                EspName = touristicPlace.esp_name,
                EngName = touristicPlace.eng_name,
                Image = touristicPlace.image,
                EspDescription = touristicPlace.esp_description,
                EngDescription = touristicPlace.eng_description,
                PlaceId = touristicPlace.place_id,
            };
        }
    }
}