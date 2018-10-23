using LAB11_MyFirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB11_MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {

            return RedirectToAction("Result", new { begYear, endYear });
        }

        public ViewResult Result(int begYear, int endYear)
        {
            List<TimePerson> peoplesOfTheYear = TimePerson.GetPersons(begYear, endYear);

            return View(peoplesOfTheYear);
        }
    
    }
}
