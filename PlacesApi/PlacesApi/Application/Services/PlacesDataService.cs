using PlacesApi.Domain.Interfaces;
using PlacesApi.Application.DTOs;


namespace PlacesApi.Application.Services
{
    public class PlacesDataService : IPlacesDataService
    {
        private readonly IPlacesDataRepository _placesDataRepository;

        public PlacesDataService(IPlacesDataRepository placesDataRepository)
        {
            _placesDataRepository = placesDataRepository;
        }

        public async Task<IEnumerable<PlacesDataDTO>> GetAllPlacesDataAsync()
        {
            var placesData = await _placesDataRepository.GetAllAsync();
            return placesData.Select(p => new PlacesDataDTO
            {
                Id = p.id,
                EspName = p.esp_name,
                EngName = p.eng_name,
                Image = p.image,
                EspDescription = p.esp_description,
                EngDescription = p.eng_description,
                PlaceId = p.place_id,
                Type = p.type,
            }).ToList();
        }

        public async Task<PlacesDataDTO> GetPlacesDataByIdAsync(int id)
        {
            var placesData = await _placesDataRepository.GetByIdAsync(id);
            if (placesData == null)
            {
                return null;
            }

            return new PlacesDataDTO
            {
                Id = placesData.id,
                EspName = placesData.esp_name,
                EngName = placesData.eng_name,
                Image = placesData.image,
                EspDescription = placesData.esp_description,
                EngDescription = placesData.eng_description,
                PlaceId = placesData.place_id,
                Type = placesData.type,
            };
        }

        public async Task<PlacesDataDTO> GetPlacesDataByNameAsync(string name)
        {
            var placesData = await _placesDataRepository.GetByNameAsync(name);
            if (placesData == null)
            {
                throw new KeyNotFoundException($"Places data with name '{name}' not found.");
            }

            return new PlacesDataDTO
            {
                Id = placesData.id,
                EspName = placesData.esp_name,
                EngName = placesData.eng_name,
                Image = placesData.image,
                EspDescription = placesData.esp_description,
                EngDescription = placesData.eng_description,
                Type = placesData.type,
                PlaceId = placesData.place_id,
            };
        }

        public async Task<IEnumerable<PlacesDataDTO>> GetPlacesDataByIdsAsync(int[] ids)
        {
            var placesData = await _placesDataRepository.GetByIdsAsync(ids);
            return placesData.Select(p => new PlacesDataDTO
            {
                Id = p.id,
                EspName = p.esp_name,
                EngName = p.eng_name,
                Image = p.image,
                EspDescription = p.esp_description,
                EngDescription = p.eng_description,
                PlaceId = p.place_id,
                Type = p.type,
            }).ToList();
        }

        public async Task<IEnumerable<PlacesDataDTO>> GetPlacesDataByPlaceIdAsync(int placeId)
        {
            var placesData = await _placesDataRepository.GetByPlaceIdAsync(placeId);
            return placesData.Select(p => new PlacesDataDTO
            {
                Id = p.id,
                EspName = p.esp_name,
                EngName = p.eng_name,
                Image = p.image,
                EspDescription = p.esp_description,
                EngDescription = p.eng_description,
                PlaceId = p.place_id,
                Type = p.type,
            }).ToList();
        }
    }
}
