using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.Data_Transfer_Objects
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        //[Unique(ErrorMessage = "This already exist !!")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Birthdate")]
        //[Age18IfAMember]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "Subscribe to newsletter ?")]
        public bool IsSubscribedToNewsletter { get; set; }

        //public MembershipType Membershiptype { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}