using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieRentalWebApp.Data_Transfer_Objects;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.Controllers.Api
{
    public class RentalController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Post: /Api/Rental
        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //filtering if no movieId entered
            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("No MovieIds have been given");

            var customerInDb = _context.Customers
                .SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            //filtering if the entered customerId is invalid
            if (customerInDb == null)
                return BadRequest("CustomerId is not valid");

            var moviesInDb = _context.Movies
                .Where(m => rentalDto.MovieIds.Contains(m.Id))
                .ToList();

            //filtering if one of te entered movies is invalid
            if (moviesInDb.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more movies is not reloaded from database");

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Curentty this movie is not available: Id: " 
                        + movie.Id + " Name: " + movie.Name);
                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customerInDb,
                    Movie = movie,
                    DateRented = DateTime.Now,
                    //this will set the expiry date for only 20 days
                    DateReturned = DateTime.Now.AddDays(20)                    
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
