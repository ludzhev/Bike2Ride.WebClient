using System.ComponentModel.DataAnnotations;

using Bike2Ride.WebClient.ViewModels.Abstraction;

namespace Bike2Ride.WebClient.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
