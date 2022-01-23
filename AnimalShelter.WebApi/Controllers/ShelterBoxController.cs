using AnimalShelter.Infrastructure.Commands;
using AnimalShelter.Infrastructure.DTO;
using AnimalShelter.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[Controller]")]
    public class ShelterBoxController : Controller
    {
        private readonly IShelterBoxService _shelterBoxService;
        public ShelterBoxController(IShelterBoxService shelterBoxService)
        {
            _shelterBoxService = shelterBoxService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<ShelterBoxDTO> z = await _shelterBoxService.BrowseAll();

            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShelterBox(int id)
        {
            ShelterBoxDTO z = await _shelterBoxService.GetShelterBox(id);

            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddShelterBox([FromBody] CreateShelterBox shelterBox)
        {
            var result = await _shelterBoxService.AddShelterBox(shelterBox);

            return Json(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShelterBox([FromBody] CreateShelterBox shelterBox, int id)
        {
            var result = await _shelterBoxService.UpdateShelterBox(id, shelterBox);

            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelterBox(int id)
        {
            var result = await _shelterBoxService.DeleteShelterBox(id);

            return Json(result);
        }
    }
}