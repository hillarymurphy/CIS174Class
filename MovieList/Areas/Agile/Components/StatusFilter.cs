using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using MovieList.Areas.Agile.Models;

namespace MovieList.Areas.Agile.Components
{
    public class StatusFilter : ViewComponent
    {
        private IRepository<Models.Status> data { get; set; }
        public StatusFilter(IRepository<Status> rep) => data = rep;

        public IViewComponentResult Invoke() 
        {
            var statuses = data.List(new QueryOptions<Status>
            {
                OrderBy = s => s.StatusId
            });
            return View(statuses);
        }
    }
}
