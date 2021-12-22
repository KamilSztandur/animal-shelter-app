using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IShelterBoxService
    {
        Task<int> UpdateShelterBox(int id, CreateShelterBox shelterBoxBody);
        Task<int> DeleteShelterBox(int id);
        Task<int> AddShelterBox(CreateShelterBox shelterBoxBody);
        Task<ShelterBoxDTO> GetShelterBox(int id);
        Task<IEnumerable<ShelterBoxDTO>> BrowseAll();
    }
}
