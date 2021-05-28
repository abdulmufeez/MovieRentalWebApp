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
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }
        //GET: /Api/Movie/id
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
        //POST: /Api/Movie
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInModel = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movieInModel);
            _context.SaveChanges();

            movieDto.Id = movieInModel.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieInModel.Id), movieDto);
        }
        //PUT /Api/Movies/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInModel = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInModel == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movieInModel);
            _context.SaveChanges();
            return Ok();
        }
        //DELETE: /Api/Movie/id
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
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
