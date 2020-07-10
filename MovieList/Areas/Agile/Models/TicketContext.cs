using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.Agile.Models
{
    [Area("Agile")]
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprogress", Name = "In Progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance" },
                new Status { StatusId = "done", Name = "Done" }
            );
            modelBuilder.Entity<Ticket>().HasData(
                new
                {
                    TicketId = 1,
                    TicketName = "Agile Index",
                    Description = "Set up Index Page",
                    Sprint = 1,
                    Point = 2,
                    StatusId = "todo"
                }
            );
        }
    }
}
