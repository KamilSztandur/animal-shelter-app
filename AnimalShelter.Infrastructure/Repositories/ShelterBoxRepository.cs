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
        private AppDbContext _appDbContext;

        public ShelterBoxRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(ShelterBox shelterBox)
        {
            try
            {
                _appDbContext.ShelterBoxes.Add(shelterBox);
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

        public async Task<bool> DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(
                    _appDbContext.ShelterBoxes.FirstOrDefault(shelterBox => shelterBox.Id == id)
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

        public async Task<bool> UpdateAsync(int shelterBoxId, ShelterBox shelterBoxData)
        {
            try
            {
                var editedShelterBox = _appDbContext.ShelterBoxes.FirstOrDefault(
                    shelterBox => shelterBox.Id == shelterBoxId
                );

                editedShelterBox.Id = shelterBoxData.Id;
                editedShelterBox.AnimalId = shelterBoxData.AnimalId;

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
