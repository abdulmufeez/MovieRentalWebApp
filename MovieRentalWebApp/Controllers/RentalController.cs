using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MovieRentalWebApp.ViewModels;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.Controllers
{
    public class RentalController : Controller
    {
        private ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();


            //this will automatically delete rental record after 20 days rented movie
            //but here is a problem when our record becomes much much bigger it will automatically
            //decrease our application performance
            var rentalInDb = _context.Rentals.Where(rd => 
                DbFunctions.TruncateTime(rd.DateReturned) == 
                DbFunctions.TruncateTime(DateTime.Now))
                .ToList();
            if (rentalInDb != null)
            {
                foreach (var rental in rentalInDb)
                {
                    _context.Rentals.Remove(rental);
                    _context.SaveChanges();
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //GET: Rental
        public ActionResult Index()
        {
            var rentalDetailList = _context.Rentals
                .Include(rd => rd.Customer)
                .Include(rd => rd.Movie)
                .ToList();
            return View("RentalList",rentalDetailList);
        }
        //GET: Rental/New
        public ActionResult New()
        {            
            return View("NewRental");
        }
        //GET: Rental/Detail/id
        public ActionResult Detail(int id)
        {
            var rentalInDb = _context.Rentals
                .Include(rd => rd.Customer)
                .Include(rd => rd.Movie)
                .SingleOrDefault(rd => rd.Id == id);
            if (rentalInDb == null)
                return HttpNotFound(); 

            return View("RentalDetail",rentalInDb);
        }
        //Delete: Rental/Delete/id
        public ActionResult Delete(int id)
        {
            var rentalInDb = _context.Rentals
                .Include(rd => rd.Movie)
                .FirstOrDefault(rd => rd.Id == id);
            if (rentalInDb == null)
                return HttpNotFound();
            else
            {
                //this will automatically increase the availability of stocks to 1
                rentalInDb.Movie.NumberAvailable++;

                _context.Rentals.Remove(rentalInDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Rental");
        }
    }
}