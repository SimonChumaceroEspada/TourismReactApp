using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces

{
    public interface ITouristicPlaceRepository
    {
        Task<IEnumerable<TouristicPlace>> GetAllAsync();
        Task<TouristicPlace> GetByIdAsync(int id);
        Task<TouristicPlace> GetByNameAsync(string name);

    }
}