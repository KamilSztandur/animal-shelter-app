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

        public Task<bool> AddMedicalProcedure(CreateMedicalProcedure medicalProcedureBody)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicalProcedureDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMedicalProcedure(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalProcedureDTO> GetMedicalProcedure(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMedicalProcedure(int id, CreateMedicalProcedure medicalProcedureBody)
        {
            throw new NotImplementedException();
        }
    }
}
