using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;
using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorsRepository;

        public DoctorService(IDoctorRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public async Task<int> AddDoctor(CreateDoctor doctorBody)
        {
            var doctor = ParseCreateDoctorIntoDoctor(doctorBody);

            var result = await _doctorsRepository.AddAsync(doctor);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<DoctorDTO>> BrowseAll()
        {
            var doctors = await _doctorsRepository.BrowseAllAsync();

            var doctorsDTOs = doctors.Select(doctor => ParseDoctorIntoDoctorDTO(doctor));

            return doctorsDTOs;
        }

        public async Task<int> DeleteDoctor(int id)
        {
            var result = await _doctorsRepository.DelAsync(id);

            return await Task.FromResult(result);
        }

        public async Task<DoctorDTO> GetDoctor(int id)
        {
            var doctor = await _doctorsRepository.GetAsync(id);

            return ParseDoctorIntoDoctorDTO(doctor);
        }

        public async Task<int> UpdateDoctor(int id, CreateDoctor doctorBody)
        {
            var doctor = ParseCreateDoctorIntoDoctor(doctorBody);

            var result = await _doctorsRepository.UpdateAsync(id, doctor);

            return await Task.FromResult(result);
        }

        DoctorDTO ParseDoctorIntoDoctorDTO(Doctor doctor)
        {
            return new DoctorDTO()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                SecondName = doctor.SecondName,
            };
        }

        Doctor ParseCreateDoctorIntoDoctor(CreateDoctor doctorBody)
        {
            Doctor doctor = new Doctor()
            {
                Name = doctorBody.Name,
                SecondName = doctorBody.SecondName
            };

            return doctor;
        }
    }
}
