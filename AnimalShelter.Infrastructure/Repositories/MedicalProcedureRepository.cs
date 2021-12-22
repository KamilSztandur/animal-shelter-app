using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class MedicalProcedureRepository : IMedicalProcedureRepository
    {
        private AppDbContext _appDbContext;

        public MedicalProcedureRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(MedicalProcedure medicalProcedure)
        {
            try
            {
                _appDbContext.MedicalProcedures.Add(medicalProcedure);
                _appDbContext.SaveChanges();

                await Task.CompletedTask;
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<MedicalProcedure>> BrowseAllAsync()
        {
            try
            {
                IEnumerable<MedicalProcedure> medicalProcedures = await Task.FromResult(_appDbContext.MedicalProcedures);

                return medicalProcedures;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<MedicalProcedure>();
            }

        }

        public async Task<bool> DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(
                    _appDbContext.MedicalProcedures.FirstOrDefault(medicalProcedure => medicalProcedure.Id == id)
                );
                _appDbContext.SaveChanges();

                await Task.CompletedTask;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public async Task<MedicalProcedure> GetAsync(int id)
        {
            try
            {
                MedicalProcedure medicalProcedure = await Task.FromResult(
                    _appDbContext.MedicalProcedures.FirstOrDefault(medicalProcedure => medicalProcedure.Id == id)
                );

                return medicalProcedure;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public async Task<bool> UpdateAsync(int medicalProcedureId, MedicalProcedure medicalProcedureData)
        {
            try
            {
                var editedMedicalProcedure = _appDbContext.MedicalProcedures.FirstOrDefault(
                    medicalProcedure => medicalProcedure.Id == medicalProcedureId
                );

                editedMedicalProcedure.Id = medicalProcedureData.Id;
                editedMedicalProcedure.AnimalId = medicalProcedureData.AnimalId;
                editedMedicalProcedure.DoctorId = medicalProcedureData.DoctorId
                editedMedicalProcedure.ProcedureName = medicalProcedureData.ProcedureName;
                editedMedicalProcedure.date = medicalProcedureData.date;
                editedMedicalProcedure.WasSuccess = medicalProcedureData.WasSuccess;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}
