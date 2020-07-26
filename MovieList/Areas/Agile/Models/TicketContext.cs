using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MovieList.Areas.Agile.Models
{
    [Area("Agile")]
    public class TicketContext : IdentityDbContext<User>
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Remove cascading delete with Status
            modelBuilder.Entity<Ticket>().HasOne(t => t.Status)
                .WithMany(s => s.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedTickets());
            modelBuilder.ApplyConfiguration(new SeedStatuses());
         }

    }
}
