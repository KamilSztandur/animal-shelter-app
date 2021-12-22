using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IDoctorRepository
    {
        Task<int> UpdateAsync(int doctorId, Doctor doctorData);
        Task<int> DelAsync(int id);
        Task<int> AddAsync(Doctor doctor);
        Task<Doctor> GetAsync(int id);
        Task<IEnumerable<Doctor>> BrowseAllAsync();
    }
}
