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
    public class MedicalProcedureService : IMedicalProcedureService
    {
        private readonly IMedicalProcedureRepository _medicalProceduresRepository;

        public MedicalProcedureService(IMedicalProcedureRepository medicalProceduresRepository)
        {
            _medicalProceduresRepository = medicalProceduresRepository;
        }

        public async Task<int> AddMedicalProcedure(CreateMedicalProcedure medicalProcedureBody)
        {
            var medicalProcedure = ParseCreateMedicalProcedureIntoMedicalProcedure(medicalProcedureBody);

            var result = await _medicalProceduresRepository.AddAsync(medicalProcedure);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<MedicalProcedureDTO>> BrowseAll()
        {
            var medicalProcedures = await _medicalProceduresRepository.BrowseAllAsync();

            var medicalProceduresDTOs = medicalProcedures.Select(medicalProcedure => ParseMedicalProcedureIntoMedicalProcedureDTO(medicalProcedure));

            return medicalProceduresDTOs;
        }

        public async Task<int> DeleteMedicalProcedure(int id)
        {
            var result = await _medicalProceduresRepository.DelAsync(id);

            return await Task.FromResult(result);
        }

        public async Task<MedicalProcedureDTO> GetMedicalProcedure(int id)
        {
            var medicalProcedure = await _medicalProceduresRepository.GetAsync(id);

            return ParseMedicalProcedureIntoMedicalProcedureDTO(medicalProcedure);
        }

        public async Task<int> UpdateMedicalProcedure(int id, CreateMedicalProcedure medicalProcedureBody)
        {
            var medicalProcedure = ParseCreateMedicalProcedureIntoMedicalProcedure(medicalProcedureBody);

            var result = await _medicalProceduresRepository.UpdateAsync(id, medicalProcedure);

            return await Task.FromResult(result);
        }

        MedicalProcedureDTO ParseMedicalProcedureIntoMedicalProcedureDTO(MedicalProcedure medicalProcedure)
        {
            return new MedicalProcedureDTO()
            {
                DoctorId = medicalProcedure.DoctorId,
                AnimalId = medicalProcedure.AnimalId,
                ProcedureName = medicalProcedure.ProcedureName,
                WasSuccess = medicalProcedure.WasSuccess,
                Date = medicalProcedure.Date
            };
        }

        MedicalProcedure ParseCreateMedicalProcedureIntoMedicalProcedure(CreateMedicalProcedure medicalProcedureBody)
        {
            MedicalProcedure medicalProcedure = new MedicalProcedure()
            {
                DoctorId = medicalProcedureBody.DoctorId,
                AnimalId = medicalProcedureBody.AnimalId,
                ProcedureName = medicalProcedureBody.ProcedureName,
                WasSuccess = Boolean.Parse(medicalProcedureBody.WasSuccess),
                Date = DateTime.Parse(medicalProcedureBody.Date)
            };

            return medicalProcedure;
        }
    }
}
