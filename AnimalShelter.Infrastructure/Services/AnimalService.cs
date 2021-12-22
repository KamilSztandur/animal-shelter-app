using AnimalShelter.Core.Domain;
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

        public async Task<int> AddAnimal(CreateAnimal animalBody)
        {
            var animal = ParseCreateAnimalIntoAnimal(animalBody);

            var result = await _animalsRepository.AddAsync(animal);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<AnimalDTO>> BrowseAll()
        {
            var animals = await _animalsRepository.BrowseAllAsync();

            var animalsDTOs = animals.Select(animal => ParseAnimalIntoAnimalDTO(animal));

            return animalsDTOs;
        }

        public async Task<int> DeleteAnimal(int id)
        {
            var result = await _animalsRepository.DelAsync(id);

            return await Task.FromResult(result);
        }

        public async Task<AnimalDTO> GetAnimal(int id)
        {
            var animal = await _animalsRepository.GetAsync(id);

            return ParseAnimalIntoAnimalDTO(animal);
        }

        public async Task<int> UpdateAnimal(int id, CreateAnimal animalBody)
        {
            var animal = ParseCreateAnimalIntoAnimal(animalBody);

            var result = await _animalsRepository.UpdateAsync(id, animal);
            
            return await Task.FromResult(result);
        }

        AnimalDTO ParseAnimalIntoAnimalDTO(Animal animal)
        {
            return new AnimalDTO()
            {
                Id = animal.Id,
                Name = animal.Name,
                MainDoctorId = animal.MainDoctorId,
                BoxId = animal.BoxId,
                IsReadyForAdoption = animal.IsReadyForAdoption
            };
        }

        Animal ParseCreateAnimalIntoAnimal(CreateAnimal animalBody)
        {
            Animal animal = new Animal()
            {
                Name = animalBody.Name,
                MainDoctorId = animalBody.MainDoctorId,
                BoxId = animalBody.BoxId,
                IsReadyForAdoption = Boolean.Parse(animalBody.IsReadyForAdoption)
            };

            return animal;
        }
    }
}
