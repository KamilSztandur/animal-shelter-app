using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class MedicalProcedureRepository : IMedicalProcedureRepository
    {
        private AppDbContext _appDbContext;

        public MedicalProcedureRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public Task<bool> AddAsync(MedicalProcedure shelterBox)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicalProcedure>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalProcedure> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int shelterBoxId, MedicalProcedure shelterBoxData)
        {
            throw new NotImplementedException();
        }
    }
}
