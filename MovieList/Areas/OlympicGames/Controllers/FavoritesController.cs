using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.OlympicGames.Models;

namespace MovieList.Areas.OlympicGames.Controllers
{
    [Area("OlympicGames")]
    public class FavoritesController : Controller
    {
        [Route("[area]/[controller]")]
        [HttpGet]
        public ViewResult Index()
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveSportType = session.GetActiveSportType(),
                ActiveCat = session.GetActiveCat(),
                Countrys = session.GetMyCountrys()
            };
            return View(model);
        }
        [Route("[area]/[controller]/Delete")]
        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new CountrySession(HttpContext.Session);
            var cookies = new CountryCookies(Response.Cookies);

            session.RemoveMyCountrys();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveSportType = session.GetActiveSportType(),
                    ActiveCat = session.GetActiveCat()
                });
        }
    }
}
