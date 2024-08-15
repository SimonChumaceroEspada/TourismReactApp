using PlacesApi.Domain.Entities;
using PlacesApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PlacesApi.Infrastructure.Repositories
{
    public class TouristicPlaceRepository : ITouristicPlaceRepository
    {
        private readonly PlacesDbContext _context;

        public TouristicPlaceRepository(PlacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TouristicPlace>> GetAllAsync()
        {
            return await _context.TouristicPlace.ToListAsync();
        }

        public async Task<TouristicPlace> GetByIdAsync(int id)
        {
            return await _context.TouristicPlace.FindAsync(id);
        }

        public async Task<TouristicPlace> GetByNameAsync(string name)
        {
            return await _context.TouristicPlace.FirstOrDefaultAsync(tp => tp.EngName.ToLower() == name.ToLower() || tp.EspName.ToLower() == name.ToLower());
        }
    }
}