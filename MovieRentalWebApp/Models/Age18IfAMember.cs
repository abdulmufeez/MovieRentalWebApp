using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.Models
{
    public class Age18IfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required!");
            }
            if (customer.MembershipTypeId == MembershipType.Unknown &&
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            else
            {
                var Age = DateTime.Today.Year - customer.BirthDate.Value.Year;
                return (Age >= 18)
                    ? ValidationResult.Success
                    : new ValidationResult("Member must be 18 to acquire membership!");
            }
        }
    }  
}