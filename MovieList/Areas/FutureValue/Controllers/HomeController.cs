﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.FutureValue.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Areas.FutureValue.Controllers
{
    [Area("FutureValue")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
