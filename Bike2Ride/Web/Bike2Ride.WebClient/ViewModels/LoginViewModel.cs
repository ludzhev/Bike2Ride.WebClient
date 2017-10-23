using System.ComponentModel.DataAnnotations;

using Bike2Ride.WebClient.ViewModels.Abstraction;

namespace Bike2Ride.WebClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
