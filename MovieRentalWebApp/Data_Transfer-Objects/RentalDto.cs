using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalWebApp.Data_Transfer_Objects
{
    public class RentalDto
    {
        public int CustomerId { get; set; }

        public List<int> MovieIds { get; set; }
    }
}