using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bike2Ride.Startup))]
namespace Bike2Ride
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
