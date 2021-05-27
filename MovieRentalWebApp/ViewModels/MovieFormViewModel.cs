using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genre { get; set; }

        public string Title
        {
            get
            {
                return (Movie != null && Movie.Id == 0)
                    ? "Edit Movie"
                    : "New Movie";
            }
        }
    }
}