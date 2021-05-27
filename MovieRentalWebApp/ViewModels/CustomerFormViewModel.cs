using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipType { get; set; }

        public string Title
        {
            get
            {
                return (Customer!=null && Customer.Id != 0)
                    ? "Edit Customer"
                    : "New Customer";
            }
        }
    }
}