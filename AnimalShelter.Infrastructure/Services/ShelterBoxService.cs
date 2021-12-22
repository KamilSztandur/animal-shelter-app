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

        public ShelterBoxService(IShelterBoxRepository shelterBoxsRepository)
        {
            _shelterBoxsRepository = shelterBoxsRepository;
        }

        public async Task<int> AddShelterBox(CreateShelterBox shelterBoxBody)
        {
            var shelterBox = ParseCreateShelterBoxIntoShelterBox(shelterBoxBody);

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
            var shelterBox = ParseCreateShelterBoxIntoShelterBox(shelterBoxBody);

            var result = await _shelterBoxsRepository.UpdateAsync(id, shelterBox);

            return await Task.FromResult(result);
        }

        ShelterBoxDTO ParseShelterBoxIntoShelterBoxDTO(ShelterBox shelterBox)
        {
            return new ShelterBoxDTO()
            {
                Id = shelterBox.Id,
                AnimalId = shelterBox.AnimalId
            };
        }

        ShelterBox ParseCreateShelterBoxIntoShelterBox(CreateShelterBox shelterBoxBody)
        {
            ShelterBox shelterBox = new ShelterBox()
            {
                AnimalId = shelterBoxBody.AnimalId
            };

            return shelterBox;
        }
    }
}
