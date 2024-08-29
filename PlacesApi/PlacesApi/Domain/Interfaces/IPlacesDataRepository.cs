using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces

{
    public interface IPlacesDataRepository
    {
        Task<IEnumerable<PlacesData>> GetAllAsync();
        Task<PlacesData> GetByIdAsync(int id);
        Task<PlacesData> GetByNameAsync(string name);

    }
}