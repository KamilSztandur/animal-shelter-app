using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IAnimalRepository
    {
        Task<bool> UpdateAsync(int animalId, Animal animalData);
        Task<bool> DelAsync(int id);
        Task<bool> AddAsync(Animal animal);
        Task<Animal> GetAsync(int id);
        Task<IEnumerable<Animal>> BrowseAllAsync();
    }
}
