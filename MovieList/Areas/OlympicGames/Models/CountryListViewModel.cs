using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Areas.OlympicGames.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public List<Country> Countrys { get; set; }

        private List<SportType> sporttypes;
        public List<SportType> SportTypes
        {
            get => sporttypes;
            set
            {
                sporttypes = value;
                sporttypes.Insert(0,
                    new SportType { SportTypeID = "all", Name = "All" });
            }
        }

        private List<Category> categorys;
        public List<Category> Categorys
        {
            get => categorys;
            set
            {
                categorys = value;
                categorys.Insert(0,
                    new Category { CategoryID = "all", Name = "All" });
            }
        }

        // methods to help view determine active link
        public string CheckActiveSportType(string t) =>
            t.ToLower() == ActiveSportType.ToLower() ? "active" : "";
        public string CheckActiveCat(string c) =>
            c.ToLower() == ActiveCat.ToLower() ? "active" : "";
    }
}
