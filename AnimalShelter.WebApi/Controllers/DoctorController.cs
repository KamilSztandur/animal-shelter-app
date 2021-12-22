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
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<DoctorDTO> z = await _doctorService.BrowseAll();

            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            DoctorDTO z = await _doctorService.GetDoctor(id);

            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] CreateDoctor doctor)
        {
            var result = await _doctorService.AddDoctor(doctor);

            return Json(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor([FromBody] CreateDoctor doctor, int id)
        {
            var result = await _doctorService.UpdateDoctor(id, doctor);

            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _doctorService.DeleteDoctor(id);

            return Json(result);
        }
    }
}