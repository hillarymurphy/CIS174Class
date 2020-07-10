using MovieList.Areas.OlympicGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.OlympicGames.Models
{
    [Area("OlymicGames")]
    public class Country
    {
        public string CountryID { get; set; }
        public string Name { get; set; }
        public SportType SportType { get; set; }
        public string Sport { get; set; }
        public Category Category { get; set; }
        public string LogoImage { get; set; }        
    }
}
