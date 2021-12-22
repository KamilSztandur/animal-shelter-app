using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IMedicalProcedureRepository
    {
        Task<bool> UpdateAsync(int medicalProcedureId, MedicalProcedure medicalProcedureData);
        Task<bool> DelAsync(int id);
        Task<bool> AddAsync(MedicalProcedure medicalProcedure);
        Task<MedicalProcedure> GetAsync(int id);
        Task<IEnumerable<MedicalProcedure>> BrowseAllAsync();
    }
}
