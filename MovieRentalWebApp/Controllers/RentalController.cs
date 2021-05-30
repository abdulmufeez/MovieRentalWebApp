using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalWebApp.ViewModels;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.Controllers
{
    public class RentalController : Controller
    {
        //private ApplicationDbContext _context;
        //public RentalController()
        //{
        //    _context = new ApplicationDbContext();
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}
        public ActionResult New()
        {
            
            return View("NewRental");
        }
    }
}