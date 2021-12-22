using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class ShelterBoxRepository : IShelterBoxRepository
    {
        private AppDbContext _appDbContext;

        public ShelterBoxRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public Task<bool> AddAsync(ShelterBox shelterBox)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShelterBox>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShelterBox> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int shelterBoxId, ShelterBox shelterBoxData)
        {
            throw new NotImplementedException();
        }
    }
}
