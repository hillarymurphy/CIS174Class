using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // Default Routing example
        public IActionResult Default()
        {
            return Content("Home controller, Default routing");
        }

        // Attribute Routing Example
        [Route("Attribute")]
        public IActionResult Attribute()
        {
            return Content("Home controller, Attribute routing");
        }

        // Custome Routing Example
        [Route("CustomRouting/[controller]/{id?}")]
        public IActionResult Custom(string id)
        {
            return Content("Custom Routing, Home controller, Custom ID= " + id);
        }
    }
}
