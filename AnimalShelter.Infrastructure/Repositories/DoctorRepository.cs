using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private AppDbContext _appDbContext;

        public DoctorRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(Doctor doctor)
        {
            try
            {
                _appDbContext.Doctors.Add(doctor);
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

        public async Task<IEnumerable<Doctor>> BrowseAllAsync()
        {
            try
            {
                IEnumerable<Doctor> doctors = await Task.FromResult(_appDbContext.Doctors);

                return doctors;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Doctor>();
            }

        }

        public async Task<int> DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Doctors.FirstOrDefault(doctor => doctor.Id == id));
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

        public async Task<Doctor> GetAsync(int id)
        {
            try
            {
                Doctor doctor = await Task.FromResult(
                    _appDbContext.Doctors.FirstOrDefault(doctor => doctor.Id == id)
                );

                return await Task.FromResult(doctor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<int> UpdateAsync(int doctorId, Doctor doctorData)
        {
            try
            {
                var editedDoctor = _appDbContext.Doctors.FirstOrDefault(doctor => doctor.Id == doctorId);

                editedDoctor.Id = doctorData.Id;
                editedDoctor.Name = doctorData.Name;
                editedDoctor.SecondName = doctorData.SecondName;

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
