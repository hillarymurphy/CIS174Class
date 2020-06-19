using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.FutureValue.Models;

namespace MovieList.Areas.FutureValue.Controllers
{
    [Area("FutureValue")]
    public class UserAgeController : Controller
    {
        // Initial set up for view
        [Route("[area]/[controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.currentAge = 0;
            return View();
        }
        // view once user entry completed
        [HttpPost]
        public IActionResult Index(UserAgeModel model)
        {
            // if user entry is valid - return name & age
            if (ModelState.IsValid)
            {
                ViewBag.Name = model.Name;
                ViewBag.currentAge = model.AgeThisYear().ToString();
            }
            // if user entry invalid set age to 0
            else
            {
                ViewBag.currentAge = 0;
            }
            return View(model);
        }
    }
}
