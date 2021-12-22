using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IShelterBoxRepository
    {
        Task<bool> UpdateAsync(int shelterBoxId, ShelterBox shelterBoxData);
        Task<bool> DelAsync(int id);
        Task<bool> AddAsync(ShelterBox shelterBox);
        Task<ShelterBox> GetAsync(int id);
        Task<IEnumerable<ShelterBox>> BrowseAllAsync();
    }
}
