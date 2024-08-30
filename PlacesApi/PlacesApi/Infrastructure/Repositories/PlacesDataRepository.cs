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

        public async Task<IEnumerable<PlacesData>> GetByPlaceIdAsync(int placeId)
        {
            return await _context.PlacesData.Where(pd => pd.place_id == placeId).ToListAsync();
        }

        public async Task<IEnumerable<PlacesData>> GetByTypeAsync(string type)
        {
            return await _context.PlacesData.Where(pd => pd.type.ToLower() == type.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<PlacesData>> GetByPlaceIdAndTypeAsync(int placeId, string type)
        {
            return await _context.PlacesData.Where(pd => pd.place_id == placeId && pd.type.ToLower() == type.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<PlacesData>> GetByIdsAsync(int[] ids)
        {
            return await _context.PlacesData.Where(pd => ids.Contains(pd.id)).ToListAsync();
        }

        public async Task<IEnumerable<PlacesData>> GetByPlaceIdsAsync(int[] placeIds)
        {
            return await _context.PlacesData.Where(pd => placeIds.Contains(pd.place_id)).ToListAsync();
        }
    }

}