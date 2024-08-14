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
            return _context.Place.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }
        public async Task AddAsync(Place place)
        {
            await _context.Place.AddAsync(place);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Place place)
        {
            _context.Place.Update(place);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var place = await _context.Place.FindAsync(id);
            if (place != null)
            {
                _context.Place.Remove(place);
                await _context.SaveChangesAsync();
            }
        }


    }
}
