using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalWebApp.Data_Transfer_Objects
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}