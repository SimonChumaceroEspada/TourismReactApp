using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food> GetByIdAsync(int id);
        Task<Food> GetByNameAsync(string name);
    }
}