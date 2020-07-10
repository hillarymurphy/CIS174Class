using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.Agile.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50)]
        public string TicketName { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a sprint number.")]
        [Range(1, 52)]
        public int? Sprint { get; set; }

        [Required(ErrorMessage = "Please enter a point value.")]
        [Remote("CheckPoint", "Validation")]
        public int Point { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
