using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IMedicalProcedureService
    {
        Task<bool> UpdateMedicalProcedure(int id, CreateMedicalProcedure medicalProcedureBody);
        Task<bool> DeleteMedicalProcedure(int id);
        Task<bool> AddMedicalProcedure(CreateMedicalProcedure medicalProcedureBody);
        Task<MedicalProcedureDTO> GetMedicalProcedure(int id);
        Task<IEnumerable<MedicalProcedureDTO>> BrowseAll();
    }
}
