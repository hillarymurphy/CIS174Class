using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.Agile.Models
{
    [Area("Agile")]
    public class Status
    {
        public string StatusId { get; set; }
        public string Name { get; set; }
    }
}
