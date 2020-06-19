using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieList.Areas.ContactList.Controllers;

namespace MovieList.Areas.ContactList.Models
{
    [Area("ContactList")]
    // inherits from DbContext class
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
             : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }

        // seeded data to add to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // mock data for database
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Name = "Mom",
                    PhoneNumber = "515-555-1010",
                    Address = "1234 1st St, West Des Moines, IA 50265"
                },
                new Contact
                {
                    ContactId = 2,
                    Name = "Daniel Tiger",
                    PhoneNumber = "515-555-1111",
                    Address = "123 Tiger Lane, Neighborhood, IA 50001",
                    Note = "Lizzy's favorite TV Show"
                },
                new Contact
                {
                    ContactId = 3,
                    Name = "Katerina KittyKat",
                    PhoneNumber = "515-555-1234",
                    Address = "123 Treehouse Lane, Neighborhood, IA 50001",
                    Note = "My favorite Character"
                }
            );
        }
    }
}
