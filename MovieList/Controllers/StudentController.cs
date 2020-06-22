using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext context { get; set; }

        public StudentController(StudentContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult List(int id)
        {
            if (id > 0 && id < 11)
            {
                ViewBag.Action = "List";
                ViewBag.Access = id;
                var student = context.Students.OrderBy(s => s.LastName).ToList();
                return View(student);
            }
            else
            {
                ViewBag.Action = "Index";
                ViewBag.Access = id;
                return View("Index");
            }
        }
    }
}
