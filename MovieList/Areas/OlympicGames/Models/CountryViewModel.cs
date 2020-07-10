using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.OlympicGames.Models
{
    [Area("OlymicGames")]
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public string ActiveSportType { get; set; } = "all";
        public string ActiveCat { get; set; } = "all";
    }
}
