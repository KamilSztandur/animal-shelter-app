using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private AppDbContext _appDbContext;

        public AnimalRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public Task<bool> AddAsync(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animal>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int animalId, Animal animalData)
        {
            throw new NotImplementedException();
        }
    }
}
