using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> GetAllAsync();       
        Task<Place> GetByIdAsync(int id);              
        Task<Place> GetByNameAsync(string name); 

    }
}
