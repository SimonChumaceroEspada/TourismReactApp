using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> GetAllAsync();           // Get all places
        Task<Place> GetByIdAsync(int id);                 // Get a specific place by ID
        Task<Place> GetByNameAsync(string name); // Get places by name
        // Task AddAsync(Place place);                       // Add a new place
        // Task UpdateAsync(Place place);                    // Update an existing place
        // Task DeleteAsync(int id);                         // Delete a place by ID
    }
}
