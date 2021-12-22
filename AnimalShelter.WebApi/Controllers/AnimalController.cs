using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using AnimalShelter.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<AnimalDTO> z = await _animalService.BrowseAll();

            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimal(int id)
        {
            AnimalDTO z = await _animalService.GetAnimal(id);

            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal([FromBody] CreateAnimal animal)
        {
            var result = await _animalService.AddAnimal(animal);

            return Json(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal([FromBody] CreateAnimal animal, int id)
        {
            var result = await _animalService.UpdateAnimal(id, animal);

            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var result = await _animalService.DeleteAnimal(id);

            return Json(result);
        }
    }
}