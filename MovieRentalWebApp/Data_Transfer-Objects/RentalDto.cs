using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalWebApp.Data_Transfer_Objects
{
    public class RentalDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<int> MovieIds { get; set; }
    }
}