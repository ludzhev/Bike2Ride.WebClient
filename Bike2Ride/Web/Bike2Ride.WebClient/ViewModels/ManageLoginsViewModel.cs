using System.Collections.Generic;

using Bike2Ride.WebClient.ViewModels.Abstraction;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Bike2Ride.WebClient.ViewModels
{
    public class ManageLoginsViewModel : BaseViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
