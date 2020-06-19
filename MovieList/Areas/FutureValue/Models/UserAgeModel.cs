using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Areas.FutureValue.Models
{
    public class UserAgeModel
    {
        public static object Assert { get; set; }

        // All fields are required
        [Required(ErrorMessage = "Please enter your name.")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Please enter your birth year.")]
        [Range(1900, 2020, ErrorMessage = "Birth year must be year 1900 - 2020.")]
        public int? BirthYear { get; set; }

        public string Slug => Name?.ToLower();

        // method to figure out age using global variable for year
        public int AgeThisYear()
        {
            int currentAge = 0;
            currentAge = GlobalVar.CURRENTYEAR - BirthYear.Value;
            return currentAge;
        }
    }
}
