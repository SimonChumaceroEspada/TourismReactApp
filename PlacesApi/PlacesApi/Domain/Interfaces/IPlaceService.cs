using PlacesApi.Application.DTOs;

namespace PlacesApi.Domain.Interfaces
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceDto>> GetAllPlacesAsync();
        Task<PlaceDto> GetPlaceByIdAsync(int id);
        Task<PlaceDto> GetPlacesByNameAsync(string name);
        // Task CreatePlaceAsync(CreatePlaceDto createPlaceDto);
        // Task UpdatePlaceAsync(int id, UpdatePlaceDto updatePlaceDto);
        // Task DeletePlaceAsync(int id);
    }
}
