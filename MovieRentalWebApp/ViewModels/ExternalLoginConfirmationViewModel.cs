using System.ComponentModel.DataAnnotations;

namespace MovieRentalWebApp.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [StringLength(100)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
