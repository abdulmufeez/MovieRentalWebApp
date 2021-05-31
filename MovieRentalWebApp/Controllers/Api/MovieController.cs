using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.Entity;
using MovieRentalWebApp.Data_Transfer_Objects;
using MovieRentalWebApp.Models;


namespace MovieRentalWebApp.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //GET: /Api/Movies
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                //filter for loading only those movies which are available in stocks 
                .Where(m => m.NumberAvailable > 0);

            //for filtering to get only required customer
            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

            var moviesInDb = moviesQuery    
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            
            return Ok(moviesInDb);
        }
        //GET: /Api/Movie/id
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
        //POST: /Api/Movie
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInModel = Mapper.Map<MovieDto, Movie>(movieDto);
            //add availability same number as in number in stock for only movie registerd time
            movieInModel.NumberAvailable = movieDto.NumberInStock;
            _context.Movies.Add(movieInModel);
            _context.SaveChanges();

            movieDto.Id = movieInModel.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieInModel.Id), movieDto);
        }
        //PUT /Api/Movies/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            //Updating numberavailable with numberinstock
            movieInDb.NumberAvailable = (short)(movieInDb.NumberAvailable + (movieDto.NumberInStock - movieInDb.NumberInStock));
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }
        //DELETE: /Api/Movie/id
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
