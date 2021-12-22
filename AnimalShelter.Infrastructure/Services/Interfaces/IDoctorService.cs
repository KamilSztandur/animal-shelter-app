using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IDoctorService
    {
        Task<int> UpdateDoctor(int id, CreateDoctor doctorBody);
        Task<int> DeleteDoctor(int id);
        Task<int> AddDoctor(CreateDoctor doctorBody);
        Task<DoctorDTO> GetDoctor(int id);
        Task<IEnumerable<DoctorDTO>> BrowseAll();
    }
}
