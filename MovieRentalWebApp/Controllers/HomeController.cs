using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalWebApp.Controllers
{
    //This attribute is used for opening home page without asking sign in or sign up
    [AllowAnonymous]
    [OutputCache(Duration = 0 , VaryByParam ="*")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}