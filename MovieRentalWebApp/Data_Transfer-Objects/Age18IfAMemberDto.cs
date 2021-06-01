using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieRentalWebApp.Models;
using MovieRentalWebApp.Data_Transfer_Objects;

namespace MovieRentalWebApp.Data_Transfer_Objects
{
    //this is class made only to check is a customer is 18+ to get the membership
    //although this is not class this is a validation class
    public class Age18IfAMemberDto : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customerDto = (CustomerDto)validationContext.ObjectInstance;
            if (customerDto.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required!");
            }
            if (customerDto.MembershipTypeId == MembershipTypeDto.Unknown &&
                customerDto.MembershipTypeId == MembershipTypeDto.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            else
            {
                var Age = DateTime.Today.Year - customerDto.BirthDate.Value.Year;
                return (Age >= 18)
                    ? ValidationResult.Success
                    //if less than 18 show message
                    : new ValidationResult("Member must be 18 to acquire membership!");
            }
        }
    }
}