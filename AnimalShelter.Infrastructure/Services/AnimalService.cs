using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using AnimalShelter.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class AnimalService : IAnimalService
    {
        public AnimalService()
        {

        }

        public Task<bool> AddAnimal(CreateAnimal animalBody)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDTO> GetAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAnimal(int id, CreateAnimal animalBody)
        {
            throw new NotImplementedException();
        }
    }
}
