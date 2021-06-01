using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalWebApp.Data_Transfer_Objects
{
    public class GenreDto
    {
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}