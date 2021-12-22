using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class ShelterBoxRepository : IShelterBoxRepository
    {
        private readonly AppDbContext _appDbContext;

        public ShelterBoxRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(ShelterBox shelterBox)
        {
            try
            {
                _appDbContext.ShelterBoxes.Add(shelterBox);
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

        public async Task<IEnumerable<ShelterBox>> BrowseAllAsync()
        {
            try
            {
                IEnumerable<ShelterBox> shelterBoxs = await Task.FromResult(_appDbContext.ShelterBoxes);

                return shelterBoxs;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<ShelterBox>();
            }

        }

        public async Task<int> DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(
                    _appDbContext.ShelterBoxes.FirstOrDefault(shelterBox => shelterBox.Id == id)
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

        public async Task<ShelterBox> GetAsync(int id)
        {
            try
            {
                ShelterBox shelterBox = await Task.FromResult(
                    _appDbContext.ShelterBoxes.FirstOrDefault(shelterBox => shelterBox.Id == id)
                );

                return shelterBox;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public async Task<int> UpdateAsync(int shelterBoxId, ShelterBox shelterBoxData)
        {
            try
            {
                var editedShelterBox = _appDbContext.ShelterBoxes.FirstOrDefault(
                    shelterBox => shelterBox.Id == shelterBoxId
                );

                editedShelterBox.AnimalId = shelterBoxData.AnimalId;

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
