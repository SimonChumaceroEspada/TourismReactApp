using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces

{
    public interface IPlacesDataRepository
    {
        Task<IEnumerable<PlacesData>> GetAllAsync();
        Task<PlacesData> GetByIdAsync(int id);
        Task<PlacesData> GetByNameAsync(string name);
        Task<IEnumerable<PlacesData>> GetByPlaceIdAsync(int placeId);
        Task<IEnumerable<PlacesData>> GetByTypeAsync(string type);
        Task<IEnumerable<PlacesData>> GetByPlaceIdAndTypeAsync(int placeId, string type);
        Task<IEnumerable<PlacesData>> GetByIdsAsync(int[] ids);

    }
}