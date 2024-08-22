using PlacesApi.Domain.Entities;
using PlacesApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PlacesApi.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly PlacesDbContext _context;

        public FoodRepository(PlacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await _context.Food.ToListAsync();
        }

        public async Task<Food> GetByIdAsync(int id)
        {
            return await _context.Food.FindAsync(id);
        }

        public async Task<Food> GetByNameAsync(string name)
        {
            return await _context.Food.FirstOrDefaultAsync(f => f.eng_name.ToLower() == name.ToLower() || f.esp_name.ToLower() == name.ToLower());
        }
    }
}