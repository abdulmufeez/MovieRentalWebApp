using System.ComponentModel.DataAnnotations;

namespace MovieRentalWebApp.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
