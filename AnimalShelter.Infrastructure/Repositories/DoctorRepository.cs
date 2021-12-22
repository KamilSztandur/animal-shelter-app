using Microsoft.EntityFrameworkCore;
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

        public Task<bool> AddAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doctor>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int doctorId, Doctor doctorData)
        {
            throw new NotImplementedException();
        }
    }
}
