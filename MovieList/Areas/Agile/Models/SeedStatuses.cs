using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieList.Areas.Agile.Models
{
    internal class SeedStatuses : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprogress", Name = "In Progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance" },
                new Status { StatusId = "done", Name = "Done" }
            );
        }
    }
}
