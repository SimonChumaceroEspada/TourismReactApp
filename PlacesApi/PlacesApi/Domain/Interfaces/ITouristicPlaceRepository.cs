using PlacesApi.Domain.Entities;

namespace PlacesApi.Domain.Interfaces

{
    public interface ITouristicPlaceRepository
    {
        Task<IEnumerable<TouristicPlace>> GetAllAsync();           // Get all touristic places
        Task<TouristicPlace> GetByIdAsync(int id);                 // Get a specific touristic place by ID
        Task<TouristicPlace> GetByNameAsync(string name); // Get touristic places by name
        // Task AddAsync(TouristicPlace touristicPlace);                       // Add a new touristic place
        // Task UpdateAsync(TouristicPlace touristicPlace);                    // Update an existing touristic place
        // Task DeleteAsync(int id);                         // Delete a touristic place by ID
    }
}