using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class ShelterBoxService : IShelterBoxService
    {
        public ShelterBoxService()
        {

        }

        public Task<bool> AddShelterBox(CreateShelterBox shelterBoxBody)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShelterBoxDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteShelterBox(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShelterBoxDTO> GetShelterBox(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateShelterBox(int id, CreateShelterBox shelterBoxBody)
        {
            throw new NotImplementedException();
        }
    }
}
