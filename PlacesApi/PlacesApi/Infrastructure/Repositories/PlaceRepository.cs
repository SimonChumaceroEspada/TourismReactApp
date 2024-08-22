using PlacesApi.Domain.Entities;
using PlacesApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PlacesApi.Infrastructure.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly PlacesDbContext _context;

        public PlaceRepository(PlacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Place>> GetAllAsync()
        {
            return await _context.Place.ToListAsync();
        }

        public async Task<Place> GetByIdAsync(int id)
        {
            return await _context.Place.FindAsync(id);
        }

        public Task<Place> GetByNameAsync(string name)
        {
            return _context.Place.FirstOrDefaultAsync(p => p.name.ToLower() == name.ToLower());
        }
    }
}
