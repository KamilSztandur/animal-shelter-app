using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IDoctorRepository
    {
        Task<bool> UpdateAsync(int doctorId, Doctor doctorData);
        Task<bool> DelAsync(int id);
        Task<bool> AddAsync(Doctor doctor);
        Task<Doctor> GetAsync(int id);
        Task<IEnumerable<Doctor>> BrowseAllAsync();
    }
}
