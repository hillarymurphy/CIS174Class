using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
             : base(options)
        { }

        public DbSet<Student> Students { get; set; }

        // seeded data to add to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mock data for the Movies data base
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Hillary",
                    LastName = "Murphy",
                    Grade = "A"
                },
                new Student
                {
                    StudentId = 2,
                    FirstName = "Mary",
                    LastName = "Allen",
                    Grade = "C"
                },
                new Student
                {
                    StudentId = 3,
                    FirstName = "Amanda",
                    LastName = "Clare",
                    Grade = "B"
                },
                new Student
                {
                    StudentId = 4,
                    FirstName = "William",
                    LastName = "Bob",
                    Grade = "C"
                },
                new Student
                {
                    StudentId = 5,
                    FirstName = "John",
                    LastName = "Doe",
                    Grade = "B"
                }
            );
        }
    }
}
