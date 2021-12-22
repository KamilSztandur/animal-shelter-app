using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        public DoctorService()
        {

        }

        public Task<bool> AddDoctor(CreateDoctor doctorBody)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoctorDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorDTO> GetDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDoctor(int id, CreateDoctor doctorBody)
        {
            throw new NotImplementedException();
        }
    }
}
