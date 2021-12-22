using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IShelterBoxRepository
    {
        Task<int> UpdateAsync(int shelterBoxId, ShelterBox shelterBoxData);
        Task<int> DelAsync(int id);
        Task<int> AddAsync(ShelterBox shelterBox);
        Task<ShelterBox> GetAsync(int id);
        Task<IEnumerable<ShelterBox>> BrowseAllAsync();
    }
}
