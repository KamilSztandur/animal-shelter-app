using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IMedicalProcedureRepository
    {
        Task<int> UpdateAsync(int medicalProcedureId, MedicalProcedure medicalProcedureData);
        Task<int> DelAsync(int id);
        Task<int> AddAsync(MedicalProcedure medicalProcedure);
        Task<MedicalProcedure> GetAsync(int id);
        Task<IEnumerable<MedicalProcedure>> BrowseAllAsync();
    }
}
