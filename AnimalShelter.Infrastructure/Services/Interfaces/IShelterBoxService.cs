using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IShelterBoxService
    {
        Task<bool> UpdateShelterBox(int id, CreateShelterBox shelterBoxBody);
        Task<bool> DeleteShelterBox(int id);
        Task<bool> AddShelterBox(CreateShelterBox shelterBoxBody);
        Task<ShelterBoxDTO> GetShelterBox(int id);
        Task<IEnumerable<ShelterBoxDTO>> BrowseAll();
    }
}
