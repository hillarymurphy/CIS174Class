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
            var session = new CountrySession(HttpContext.Session);
            session.SetActiveSportType(activeSportType);
            session.SetActiveCat(activeCat);

            // if no count in session, get cookie
            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new CountryCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountrys = new List<Country>();
                if (ids.Length > 0)
                    mycountrys = context.Countrys.Include(t => t.SportType)
                        .Include(t => t.Category)
                        .Where(t => ids.Contains(t.CountryID)).ToList();
                session.SetMyCountrys(mycountrys);
            }

            var model = new CountryListViewModel
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
            model.Countrys = query.ToList();

            return View(model);
        }

        [Route("[area]/[controller]/Details/{id?}")]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countrys
                    .Include(t => t.SportType)
                    .Include(t => t.Category)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveSportType = session.GetActiveSportType(),
                ActiveCat = session.GetActiveCat()
            };
            return View(model);
        }

        [Route("[area]/[controller]/Favorites/{id?}")]
        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countrys
                .Include(t => t.SportType)
                .Include(t => t.Category)
                .Where(t => t.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new CountrySession(HttpContext.Session);
            var countrys = session.GetMyCountrys();
            countrys.Add(model.Country);
            session.SetMyCountrys(countrys);

            var cookies = new CountryCookies(Response.Cookies);
            cookies.SetMyCountryIds(countrys);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index", "Country",
                new
                {
                    ActiveSportType = session.GetActiveSportType(),
                    ActiveCat = session.GetActiveCat()
                });
        }
    }
}