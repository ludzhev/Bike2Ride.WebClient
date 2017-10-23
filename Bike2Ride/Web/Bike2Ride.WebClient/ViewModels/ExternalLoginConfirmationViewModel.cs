using System.ComponentModel.DataAnnotations;

using Bike2Ride.WebClient.ViewModels.Abstraction;

namespace Bike2Ride.WebClient.ViewModels
{
    public class ExternalLoginConfirmationViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
