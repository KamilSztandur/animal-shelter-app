using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IDoctorService
    {
        Task<bool> UpdateDoctor(int id, CreateDoctor doctorBody);
        Task<bool> DeleteDoctor(int id);
        Task<bool> AddDoctor(CreateDoctor doctorBody);
        Task<DoctorDTO> GetDoctor(int id);
        Task<IEnumerable<DoctorDTO>> BrowseAll();
    }
}
