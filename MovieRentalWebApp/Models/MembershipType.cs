using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalWebApp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short SignUpfee { get; set; }

        public short DiscountRate { get; set; }

        public byte DurationInMonth { get; set; }

        protected static readonly byte Unknown = 0;
        protected static readonly byte PayAsYouGo = 1;
    }
}