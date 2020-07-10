using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.Agile.Models
{
    [Area("Agile")]
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all";
            StatusId = FilterString;
        }
        public string FilterString { get; }

        public string StatusId { get; }

        public bool HasStatus => StatusId.ToLower() != "all";
    }
}
