using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.WebApi.Controllers
{
    public class ShelterBoxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
