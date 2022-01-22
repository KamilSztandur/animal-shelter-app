using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;
using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class ShelterBoxService : IShelterBoxService
    {
        private readonly IShelterBoxRepository _shelterBoxsRepository;
        private readonly IAnimalRepository _animalRepository;

        public ShelterBoxService(IShelterBoxRepository shelterBoxsRepository, IAnimalRepository animalsRepository)
        {
            _shelterBoxsRepository = shelterBoxsRepository;
            _animalRepository = animalsRepository;
        }

        public async Task<int> AddShelterBox(CreateShelterBox shelterBoxBody)
        {
            var shelterBox = await ParseCreateShelterBoxIntoShelterBox(shelterBoxBody);

            var result = await _shelterBoxsRepository.AddAsync(shelterBox);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ShelterBoxDTO>> BrowseAll()
        {
            var shelterBoxs = await _shelterBoxsRepository.BrowseAllAsync();

            var shelterBoxsDTOs = shelterBoxs.Select(shelterBox => ParseShelterBoxIntoShelterBoxDTO(shelterBox));

            return shelterBoxsDTOs;
        }

        public async Task<int> DeleteShelterBox(int id)
        {
            var result = await _shelterBoxsRepository.DelAsync(id);

            return await Task.FromResult(result);
        }

        public async Task<ShelterBoxDTO> GetShelterBox(int id)
        {
            var shelterBox = await _shelterBoxsRepository.GetAsync(id);

            return ParseShelterBoxIntoShelterBoxDTO(shelterBox);
        }

        public async Task<int> UpdateShelterBox(int id, CreateShelterBox shelterBoxBody)
        {
            var shelterBox = await ParseCreateShelterBoxIntoShelterBox(shelterBoxBody);

            var result = await _shelterBoxsRepository.UpdateAsync(id, shelterBox);

            return await Task.FromResult(result);
        }

        ShelterBoxDTO ParseShelterBoxIntoShelterBoxDTO(ShelterBox shelterBox)
        {
            AnimalDTO animal = null;
            if(shelterBox.Animal != null)
            {
                animal = new AnimalDTO()
                {
                    Id = shelterBox.Animal.Id,
                    Name = shelterBox.Animal.Name,
                    MainDoctorId = shelterBox.Animal.MainDoctorId,
                    IsReadyForAdoption = shelterBox.Animal.IsReadyForAdoption,
                    Box = null
                };
            }

            ShelterBoxDTO dto = new ShelterBoxDTO()
            {
                Id = shelterBox.Id,
                Animal = animal
            };
            
            if (shelterBox.Animal != null) {
                dto.Animal.Box = dto;
            }

            return dto;
        }

        private async Task<ShelterBox> ParseCreateShelterBoxIntoShelterBox(CreateShelterBox shelterBoxBody)
        {
            Animal animal = await _animalRepository.GetAsync(shelterBoxBody.AnimalId);
            
            ShelterBox shelterBox = new ShelterBox()
            {
                Animal = animal
            };

            return shelterBox;
        }
    }
}
