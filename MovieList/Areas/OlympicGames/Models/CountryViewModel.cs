using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Areas.OlympicGames.Models
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public string ActiveSportType { get; set; }
        public string ActiveCat { get; set; }
    }
}
