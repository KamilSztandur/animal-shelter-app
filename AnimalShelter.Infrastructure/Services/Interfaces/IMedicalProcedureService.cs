using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IMedicalProcedureService
    {
        Task<int> UpdateMedicalProcedure(int id, CreateMedicalProcedure medicalProcedureBody);
        Task<int> DeleteMedicalProcedure(int id);
        Task<int> AddMedicalProcedure(CreateMedicalProcedure medicalProcedureBody);
        Task<MedicalProcedureDTO> GetMedicalProcedure(int id);
        Task<IEnumerable<MedicalProcedureDTO>> BrowseAll();
    }
}
