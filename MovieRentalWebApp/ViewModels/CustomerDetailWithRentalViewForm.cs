using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.ViewModels
{
    public class CustomerDetailWithRentalViewForm
    {
        public Customer Customer { get; set; }
        public IEnumerable<Rental> RentalDetails { get; set; }
    }
}