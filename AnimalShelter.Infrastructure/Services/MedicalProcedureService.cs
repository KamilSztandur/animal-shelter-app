using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class MedicalProcedureService : IMedicalProcedureService
    {
        public MedicalProcedureService()
        {

        }

        public Task<int> AddMedicalProcedure(CreateMedicalProcedure medicalProcedureBody)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicalProcedureDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMedicalProcedure(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalProcedureDTO> GetMedicalProcedure(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateMedicalProcedure(int id, CreateMedicalProcedure medicalProcedureBody)
        {
            throw new NotImplementedException();
        }
    }
}
