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
        private readonly AppDbContext _appDbContext;

        public MedicalProcedureRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(MedicalProcedure medicalProcedure)
        {
            try
            {
                _appDbContext.MedicalProcedures.Add(medicalProcedure);
                var result = _appDbContext.SaveChanges();

                await Task.CompletedTask;
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return await Task.FromResult(-1);
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

        public async Task<int> DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(
                    _appDbContext.MedicalProcedures.FirstOrDefault(medicalProcedure => medicalProcedure.Id == id)
                );
                var result = _appDbContext.SaveChanges();

                await Task.CompletedTask;
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return await Task.FromResult(-1);
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

        public async Task<int> UpdateAsync(int medicalProcedureId, MedicalProcedure medicalProcedureData)
        {
            try
            {
                var editedMedicalProcedure = _appDbContext.MedicalProcedures.FirstOrDefault(
                    medicalProcedure => medicalProcedure.Id == medicalProcedureId
                );

                editedMedicalProcedure.AnimalId = medicalProcedureData.AnimalId;
                editedMedicalProcedure.DoctorId = medicalProcedureData.DoctorId;
                editedMedicalProcedure.ProcedureName = medicalProcedureData.ProcedureName;
                editedMedicalProcedure.Date = medicalProcedureData.Date;
                editedMedicalProcedure.WasSuccess = medicalProcedureData.WasSuccess;

                var result = _appDbContext.SaveChanges();
                await Task.CompletedTask;

                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return await Task.FromResult(-1);
            }
        }
    }
}
