using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.ContactList.Models
{
    [Area("ContactList")]
    public class Contact
    {
        // Database will generate this value
        public int ContactId { get; set; }

        // Remaining fields are required
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNumber { get; set; }

        // Address not required - I don't know everyone's address in my contact list
        public string Address { get; set; }
        // Note not required - I don't need a note to know Mom is my mom
        public string Note { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower();
    }
}


