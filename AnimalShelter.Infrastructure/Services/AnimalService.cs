using AnimalShelter.Core.Repositories;
using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalsRepository;

        public AnimalService(IAnimalRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }

        public async Task<bool> AddAnimal(CreateAnimal animalBody)
        {
            var animal = animalBody.ToAnimal();

            var result = await _animalsRepository.AddAsync(animal);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<AnimalDTO>> BrowseAll()
        {
            var animals = await _animalsRepository.BrowseAllAsync();

            return animals.Select(animal => new AnimalDTO()
            {
                Id = animal.Id,
                Name = this.Name,
                MainDoctorId = this.MainDoctorId,
                BoxId = this.BoxId,
                isReadyForAdoption = Boolean.Parse(this.isReadyForAdoption)
            });
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
