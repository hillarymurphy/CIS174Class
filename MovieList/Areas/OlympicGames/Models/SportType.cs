﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.OlympicGames.Models
{
    [Area("OlymicGames")]
    public class SportType
    {
        public string SportTypeID { get; set; }
        public string Name { get; set; }
    }
}
