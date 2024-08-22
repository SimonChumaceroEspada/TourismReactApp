using PlacesApi.Application.DTOs;

namespace PlacesApi.Domain.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDTO>> GetAllFoodAsync();
        Task<FoodDTO> GetFoodByIdAsync(int id);
        Task<FoodDTO> GetFoodByNameAsync(string name);
    }
}