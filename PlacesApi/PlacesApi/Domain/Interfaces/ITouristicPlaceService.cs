using PlacesApi.Application.DTOs;

namespace PlacesApi.Domain.Interfaces
{
    public interface ITouristicPlaceService
    {
        Task<IEnumerable<TouristicPlaceDto>> GetAllTouristicPlaceAsync();
        Task<TouristicPlaceDto> GetTouristicPlaceByIdAsync(int id);
        Task<TouristicPlaceDto> GetTouristicPlaceByNameAsync(string name);
    }
}
