using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.OlympicGames.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Areas.OlympicGames.Controllers
{
    [Area("OlympicGames")]
    public class CountryController : Controller
    {
        private CountryContext context;

        public CountryController(CountryContext ctx)
        {
            context = ctx;
        }

        [Route("[area]/[controller]")]
        [HttpGet]
        public IActionResult Index(string activeSportType = "all",
                                   string activeCat = "all")
        {
            var data = new CountryListViewModel
            {
                ActiveSportType = activeSportType,
                ActiveCat = activeCat,
                SportTypes = context.SportTypes.ToList(),
                Categorys = context.Categorys.ToList()
            };

            IQueryable<Country> query = context.Countrys;
            if (activeSportType != "all")
                query = query.Where(
                    t => t.SportType.SportTypeID.ToLower() == activeSportType.ToLower());
            if (activeCat != "all")
                query = query.Where(
                    t => t.Category.CategoryID.ToLower() == activeCat.ToLower());
            data.Countrys = query.ToList();

            return View(data);
        }

        [Route("[area]/Countrys/sporttype/{activeSportType}/cat/{activeCat}")]
        [HttpPost]
        public IActionResult Details(CountryViewModel model)
        {
            Utility.LogCountryClick(model.Country.CountryID);

            TempData["ActiveSportType"] = model.ActiveSportType;
            TempData["ActiveCat"] = model.ActiveCat;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }

        [Route("[area]/[controller]/Details/{id?}")]
        [HttpPost]
        public IActionResult Details(string id)
        {
            var model = new CountryViewModel
            {
                Country = context.Countrys
                    .Include(t => t.SportType)
                    .Include(t => t.Category)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveSportType = TempData?["ActiveSportType"]?.ToString() ?? "all",
                ActiveCat = TempData?["ActiveCat"]?.ToString() ?? "all"
            };
            return View(model);
        }
    }
}