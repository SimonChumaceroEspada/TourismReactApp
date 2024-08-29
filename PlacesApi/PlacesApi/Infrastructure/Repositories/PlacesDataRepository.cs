using PlacesApi.Domain.Entities;
using PlacesApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace PlacesApi.Infrastructure.Repositories
{
    public class PlacesDataRepository : IPlacesDataRepository
    {
        private readonly PlacesDbContext _context;

        public PlacesDataRepository(PlacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlacesData>> GetAllAsync()
        {
            return await _context.PlacesData.ToListAsync();
        }

        public async Task<PlacesData> GetByIdAsync(int id)
        {
            return await _context.PlacesData.FindAsync(id);
        }

        public async Task<PlacesData> GetByNameAsync(string name)
        {
            return await _context.PlacesData.FirstOrDefaultAsync(pd => pd.eng_name.ToLower() == name.ToLower() || pd.esp_name.ToLower() == name.ToLower());
        }
    }

}