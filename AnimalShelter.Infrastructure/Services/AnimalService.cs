using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;
using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalsRepository;
        private readonly IShelterBoxRepository _shelterBoxRepository;

        public AnimalService(IAnimalRepository animalsRepository, IShelterBoxRepository shelterBoxRepository)
        {
            _animalsRepository = animalsRepository;
            _shelterBoxRepository = shelterBoxRepository;
        }

        public async Task<int> AddAnimal(CreateAnimal animalBody)
        {
            var animal = await ParseCreateAnimalIntoAnimal(animalBody);

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
            var animal = await ParseCreateAnimalIntoAnimal(animalBody);

            var result = await _animalsRepository.UpdateAsync(id, animal);
            
            return await Task.FromResult(result);
        }

        AnimalDTO ParseAnimalIntoAnimalDTO(Animal animal)
        {
            ShelterBoxDTO box = null;
            if(animal.Box != null)
            {
                box = new ShelterBoxDTO()
                {
                    Id = animal.Box.Id,
                    Animal = null
                };
            }

            AnimalDTO dto = new AnimalDTO()
            {
                Id = animal.Id,
                Name = animal.Name,
                MainDoctorId = animal.MainDoctorId,
                Box = box,
                IsReadyForAdoption = animal.IsReadyForAdoption
            };

            if (animal.Box != null)
            {
                dto.Box.Animal = dto;
            }

            return dto;
        }

        private async Task<Animal> ParseCreateAnimalIntoAnimal(CreateAnimal animalBody)
        {
            ShelterBox box = await _shelterBoxRepository.GetAsync(animalBody.BoxId);

            Animal animal = new Animal()
            {
                Name = animalBody.Name,
                MainDoctorId = animalBody.MainDoctorId,
                Box = box,
                IsReadyForAdoption = animalBody.IsReadyForAdoption
            };

            return animal;
        }
    }
}
