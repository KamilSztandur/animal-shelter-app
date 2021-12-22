using AnimalShelter.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Repositories
{
    public interface IAnimalRepository
    {
        Task<int> UpdateAsync(int animalId, Animal animalData);
        Task<int> DelAsync(int id);
        Task<int> AddAsync(Animal animal);
        Task<Animal> GetAsync(int id);
        Task<IEnumerable<Animal>> BrowseAllAsync();
    }
}
