using System.Collections.Generic;

using Bike2Ride.WebClient.ViewModels.Abstraction;

namespace Bike2Ride.WebClient.ViewModels
{
    public class ConfigureTwoFactorViewModel : BaseViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}
