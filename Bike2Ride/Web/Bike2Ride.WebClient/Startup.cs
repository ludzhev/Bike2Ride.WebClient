using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bike2Ride.WebClient.Startup))]
namespace Bike2Ride.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
