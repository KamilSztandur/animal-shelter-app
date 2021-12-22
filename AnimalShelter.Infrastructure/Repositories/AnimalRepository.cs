using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Core.Domain;
using AnimalShelter.Core.Repositories;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private AppDbContext _appDbContext;

        public AnimalRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(Animal animal)
        {
            try
            {
                _appDbContext.Animals.Add(animal);
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

        public async Task<IEnumerable<Animal>> BrowseAllAsync()
        {
            try
            {
                IEnumerable<Animal> animals = await Task.FromResult(_appDbContext.Animals);

                return animals;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Animal>();
            }

        }

        public async Task<bool> DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Animals.FirstOrDefault(animal => animal.Id == id));
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

        public async Task<Animal> GetAsync(int id)
        {
            try
            {
                Animal animal = await Task.FromResult(
                    _appDbContext.Animals.FirstOrDefault(animal => animal.Id == id)
                );

                return animal; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public async Task<bool> UpdateAsync(int animalId, Animal animalData)
        {
            try
            {
                var editedAnimal = _appDbContext.Animals.FirstOrDefault(animal => animal.Id == animalId);

                editedAnimal.Id = animalData.Id;
                editedAnimal.Name = animalData.Name;
                editedAnimal.BoxId = animalData.BoxId;
                editedAnimal.MainDoctorId = animalData.MainDoctorId;
                editedAnimal.isReadyForAdoption = animalData.isReadyForAdoption;

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
