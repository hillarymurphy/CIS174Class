using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieList.Areas.Agile.Models
{
    internal class SeedTickets : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity.HasData(
               new Ticket
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
