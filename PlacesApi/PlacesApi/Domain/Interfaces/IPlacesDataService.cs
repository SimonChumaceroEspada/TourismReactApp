using PlacesApi.Application.DTOs;

namespace PlacesApi.Domain.Interfaces
{
    public interface IPlacesDataService
    {
        Task<IEnumerable<PlacesDataDTO>> GetAllPlacesDataAsync();
        Task<PlacesDataDTO> GetPlacesDataByIdAsync(int id);
        Task<PlacesDataDTO> GetPlacesDataByNameAsync(string name);
        Task<IEnumerable<PlacesDataDTO>> GetPlacesDataByIdsAsync(int[] ids);
        Task<IEnumerable<PlacesDataDTO>> GetPlacesDataByPlaceIdAsync(int placeId);
    }
}