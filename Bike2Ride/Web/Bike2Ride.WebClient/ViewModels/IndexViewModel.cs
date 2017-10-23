using System.Collections.Generic;

using Bike2Ride.WebClient.ViewModels.Abstraction;

using Microsoft.AspNet.Identity;

namespace Bike2Ride.WebClient.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }
}
