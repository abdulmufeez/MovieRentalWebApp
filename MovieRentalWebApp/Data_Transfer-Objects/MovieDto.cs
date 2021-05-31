using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalWebApp.Data_Transfer_Objects
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public short NumberInStock { get; set; }

        public short NumberAvailable { get; set; }

        //public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public short GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}