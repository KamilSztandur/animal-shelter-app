using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.WebApp.Controllers
{
    public class MedicalProcedureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
