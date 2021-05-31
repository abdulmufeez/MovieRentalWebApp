using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MovieRentalWebApp.Models;
using MovieRentalWebApp.ViewModels;

namespace MovieRentalWebApp.Controllers
{
    //[Authorize] if you want to protect only this controller with all its actions
    //And restrict anonymous users
    public class MovieController : Controller
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
        // GET: Movie
        public ActionResult Index()
        {
            var movieInDb = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMoviesAndCustomers))
                return View("MovieList", movieInDb);

            return View("ReadOnlyMovieList",movieInDb);
        }
        //GET: Movie/Detail/id
        public ActionResult Detail(int id)
        {
            var movieInDb = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return HttpNotFound();

            return View("MovieDetail",movieInDb);
        }
        //POST: Movie/New
        [Authorize (Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult New()
        {
            var newMovieForm = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm",newMovieForm);
        }
        //PUT: Movie/Edit/id
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return HttpNotFound();

            var editMovieForm = new MovieFormViewModel()
            {
                Movie = movieInDb,
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm",editMovieForm);
        }
        //POST: Movie/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var reEditMovieForm = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", reEditMovieForm);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                //Updating numberavailable with numberinstock
                movieInDb.NumberAvailable = (short)(movieInDb.NumberAvailable + (movie.NumberInStock - movieInDb.NumberInStock));
                movieInDb.NumberInStock = movie.NumberInStock;
                
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movie");
        }
        //DELETE: Movie/Delete/id
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult Delete(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return HttpNotFound();
            else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Movie");
        }
    }
}