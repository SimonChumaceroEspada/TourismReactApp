using PlacesApi.Domain.Interfaces;
using PlacesApi.Application.DTOs;
using PlacesApi.Domain.Entities;

namespace PlacesApi.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<IEnumerable<FoodDTO>> GetAllFoodAsync()
        {
            var foods = await _foodRepository.GetAllAsync();
            return foods.Select(f => new FoodDTO
            {
                Id = f.id,
                EspName = f.esp_name,
                EngName = f.eng_name,
                EspDescription = f.esp_description,
                EngDescription = f.eng_description,
                Image = f.image,
                PlaceId = f.place_id,
            }).ToList();
        }

        public async Task<FoodDTO> GetFoodByIdAsync(int id)
        {
            var food = await _foodRepository.GetByIdAsync(id);
            if (food == null)
            {
                return null;
            }
            return new FoodDTO
            {
                Id = food.id,
                EspName = food.esp_name,
                EngName = food.eng_name,
                EspDescription = food.esp_description,
                EngDescription = food.eng_description,
                Image = food.image,
                PlaceId = food.place_id,
            };
        }

        public async Task<FoodDTO> GetFoodByNameAsync(string name)
        {
            var food = await _foodRepository.GetByNameAsync(name);
            if (food == null)
            {
                throw new KeyNotFoundException($"Food with name '{name}' not found.");
            }
            return new FoodDTO
            {
                Id = food.id,
                EspName = food.esp_name,
                EngName = food.eng_name,
                EspDescription = food.esp_description,
                EngDescription = food.eng_description,
                Image = food.image,
                PlaceId = food.place_id,
            };
        }
    }
}