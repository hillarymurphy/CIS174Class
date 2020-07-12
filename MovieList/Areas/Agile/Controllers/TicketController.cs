using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.Agile.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Areas.Agile.Controllers
{
    [Area("Agile")]
    public class TicketController : Controller
    {
        private TicketContext context;
        public TicketController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            // load current filters and data needed for filter drop downs in ViewBag
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();

            // get ToDo objects from database based on current filters
            IQueryable<Ticket> query = context.Tickets.Include(t => t.Status);
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            var tasks = query.OrderBy(t => t.StatusId).ToList();
            return View(tasks);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Statuses = context.Statuses.OrderBy(s => s.Name).ToList();
            return View("Add", new Ticket()); 
        }

        [HttpPost]
        public IActionResult Add(Ticket task)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(task);
                context.SaveChanges();
                return RedirectToAction("Index", "Ticket");
            }
            else
            {
                ViewBag.Statuses = context.Statuses.ToList();
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Filter(string filter)
        {
            string id = filter;
            return RedirectToAction("Index", "Ticket", new { ID = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]string id, Ticket selected)
        {
            if (selected.StatusId == null)
            {
                context.Tickets.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                ViewBag.Statuses = context.Statuses.ToList();
                selected = context.Tickets.Find(selected.TicketId);
                selected.StatusId = newStatusId;
                context.Tickets.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", "Ticket", new { ID = id });
        }
    }
}