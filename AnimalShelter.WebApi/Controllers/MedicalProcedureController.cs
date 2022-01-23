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
    public class MedicalProcedureController : Controller
    {
        private readonly IMedicalProcedureService _medicalProcedureService;
        public MedicalProcedureController(IMedicalProcedureService medicalProcedureService)
        {
            _medicalProcedureService = medicalProcedureService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<MedicalProcedureDTO> z = await _medicalProcedureService.BrowseAll();

            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalProcedure(int id)
        {
            MedicalProcedureDTO z = await _medicalProcedureService.GetMedicalProcedure(id);

            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicalProcedure([FromBody] CreateMedicalProcedure medicalProcedure)
        {
            var result = await _medicalProcedureService.AddMedicalProcedure(medicalProcedure);

            return Json(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalProcedure([FromBody] CreateMedicalProcedure medicalProcedure, int id)
        {
            var result = await _medicalProcedureService.UpdateMedicalProcedure(id, medicalProcedure);

            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalProcedure(int id)
        {
            var result = await _medicalProcedureService.DeleteMedicalProcedure(id);

            return Json(result);
        }
    }
}