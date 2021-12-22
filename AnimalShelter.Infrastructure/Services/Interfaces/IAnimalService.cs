using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IAnimalService
    {
        Task<int> UpdateAnimal(int id, CreateAnimal animalBody);
        Task<int> DeleteAnimal(int id);
        Task<int> AddAnimal(CreateAnimal animalBody);
        Task<AnimalDTO> GetAnimal(int id);
        Task<IEnumerable<AnimalDTO>> BrowseAll();
    }
}
