using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Areas.OlympicGames.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        { }

        public DbSet<Country> Countrys { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SportType>().HasData(
                new SportType { SportTypeID = "sum", Name = "Summer Olympics" },
                new SportType { SportTypeID = "win", Name = "Winter Olympics" },
                new SportType { SportTypeID = "par", Name = "Paralympic Games" },
                new SportType { SportTypeID = "you", Name = "Youth Olympic Games" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "in", Name = "Indoor" },
                new Category { CategoryID = "out", Name = "Outdoor" }
            );
            modelBuilder.Entity<Country>().HasData(
                new { CountryID = "can", Name = "Canada", SportTypeID = "win", Sport = "Curling", CategoryID = "in", LogoImage = "CAN.png" },
                new { CountryID = "swe", Name = "Sweden", SportTypeID = "win", Sport = "Curling", CategoryID = "in", LogoImage = "SWE.png" },
                new { CountryID = "grb", Name = "Great Britain", SportTypeID = "win", Sport = "Curling", CategoryID = "in", LogoImage = "GRB.png" },
                new { CountryID = "jam", Name = "Jamaica", SportTypeID = "win", Sport = "Bobsleigh", CategoryID = "out", LogoImage = "JAM.png" },
                new { CountryID = "ita", Name = "Italy", SportTypeID = "win", Sport = "Bobsleigh", CategoryID = "out", LogoImage = "ITA.png" },
                new { CountryID = "jap", Name = "Japan", SportTypeID = "win", Sport = "Bobsleigh", CategoryID = "out", LogoImage = "JAP.png" },
                new { CountryID = "ger", Name = "Germany", SportTypeID = "sum", Sport = "Diving", CategoryID = "in", LogoImage = "GER.png" },
                new { CountryID = "chi", Name = "China", SportTypeID = "sum", Sport = "Diving", CategoryID = "in", LogoImage = "CHI.png" },
                new { CountryID = "mex", Name = "Mexico", SportTypeID = "sum", Sport = "Diving", CategoryID = "in", LogoImage = "MEX.png" },
                new { CountryID = "bra", Name = "Brazil", SportTypeID = "sum", Sport = "Road Cycling", CategoryID = "out", LogoImage = "BRA.png" },
                new { CountryID = "net", Name = "Netherlands", SportTypeID = "sum", Sport = "Road Cycling", CategoryID = "out", LogoImage = "NET.png" },
                new { CountryID = "usa", Name = "USA", SportTypeID = "sum", Sport = "Road Cycling", CategoryID = "out", LogoImage = "USA.png" },
                new { CountryID = "tha", Name = "Thailan", SportTypeID = "par", Sport = "Archery", CategoryID = "in", LogoImage = "THA.png" },
                new { CountryID = "uru", Name = "Uruguay", SportTypeID = "par", Sport = "Archery", CategoryID = "in", LogoImage = "URU.png" },
                new { CountryID = "ukr", Name = "Ukraine", SportTypeID = "par", Sport = "Archery", CategoryID = "in", LogoImage = "UKR.png" },
                new { CountryID = "aus", Name = "Austria", SportTypeID = "par", Sport = "Canoe Sprint", CategoryID = "out", LogoImage = "AUS.png" },
                new { CountryID = "pak", Name = "Pakistan", SportTypeID = "par", Sport = "Canoe Sprint", CategoryID = "out", LogoImage = "PAK.png" },
                new { CountryID = "zim", Name = "Zimbabwe", SportTypeID = "par", Sport = "Canoe Sprint", CategoryID = "out", LogoImage = "ZIM.png" },
                new { CountryID = "fra", Name = "France", SportTypeID = "you", Sport = "Breakdancing", CategoryID = "in", LogoImage = "FRA.png" },
                new { CountryID = "cyp", Name = "Cyprus", SportTypeID = "you", Sport = "Breakdancing", CategoryID = "in", LogoImage = "CYP.png" },
                new { CountryID = "rus", Name = "Russia", SportTypeID = "you", Sport = "Breakdancing", CategoryID = "in", LogoImage = "RUS.png" },
                new { CountryID = "fin", Name = "Finland", SportTypeID = "you", Sport = "Skateboarding", CategoryID = "out", LogoImage = "FIN.png" },
                new { CountryID = "slo", Name = "Slovakia", SportTypeID = "you", Sport = "Skateboarding", CategoryID = "out", LogoImage = "SLO.png" },
                new { CountryID = "por", Name = "Portugal", SportTypeID = "you", Sport = "Skateboarding", CategoryID = "out", LogoImage = "POR.png" }
            );
        }
    }
}
