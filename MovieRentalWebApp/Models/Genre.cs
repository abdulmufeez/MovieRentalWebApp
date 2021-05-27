using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalWebApp.Models
{
    public class Genre
    {
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}