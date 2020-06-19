using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.ContactList.Models;

namespace MovieList.Areas.ContactList.Controllers
{
    [Area("ContactList")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();  //maps to /Areas/Contact/Views/Home/Index.cshtml
        }
    }
}
