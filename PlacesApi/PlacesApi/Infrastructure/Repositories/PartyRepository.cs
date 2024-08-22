using PlacesApi.Domain.Entities;
using PlacesApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PlacesApi.Infrastructure.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly PlacesDbContext _context;

        public PartyRepository(PlacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Party>> GetAllAsync()
        {
            return await _context.Party.ToListAsync();
        }

        public async Task<Party> GetByIdAsync(int id)
        {
            return await _context.Party.FindAsync(id);
        }

        public async Task<Party> GetByNameAsync(string name)
        {
            return await _context.Party.FirstOrDefaultAsync(p => p.eng_name.ToLower() == name.ToLower() || p.esp_name.ToLower() == name.ToLower());
        }
    }
}