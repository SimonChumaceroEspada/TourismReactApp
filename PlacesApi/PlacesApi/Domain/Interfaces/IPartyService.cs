using PlacesApi.Application.DTOs;

namespace PlacesApi.Domain.Interfaces
{
    public interface IPartyService
    {
        Task<IEnumerable<PartyDTO>> GetAllPartiesAsync();
        Task<PartyDTO> GetPartyByIdAsync(int id);
        Task<PartyDTO> GetPartyByNameAsync(string name);
    }
}