using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.Agile.Models;

namespace MovieList.Areas.Agile.Controllers
{
    public class ValidationController : Controller
    {
        private TicketContext context;
        public ValidationController(TicketContext ctx) => context = ctx;
        public JsonResult CheckPoint(int Point)
        {
            string msg = PointCheck.PointValid(context, Point);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}