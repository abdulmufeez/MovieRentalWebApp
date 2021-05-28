using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }

        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name ="Numbers In Stock")]
        public short NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name ="Genre Type")]
        public short GenreId { get; set; }
    }
}