using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Services
{
    public interface IAnimalService
    {
        Task<bool> UpdateAnimal(int id, CreateAnimal animalBody);
        Task<bool> DeleteAnimal(int id);
        Task<bool> AddAnimal(CreateAnimal animalBody);
        Task<AnimalDTO> GetAnimal(int id);
        Task<IEnumerable<AnimalDTO>> BrowseAll();
    }
}
