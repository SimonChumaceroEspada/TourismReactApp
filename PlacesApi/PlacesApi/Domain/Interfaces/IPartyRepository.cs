using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces

{
    public interface IPartyRepository
    {
        Task<IEnumerable<Party>> GetAllAsync();
        Task<Party> GetByIdAsync(int id);
        Task<Party> GetByNameAsync(string name);
    }
}