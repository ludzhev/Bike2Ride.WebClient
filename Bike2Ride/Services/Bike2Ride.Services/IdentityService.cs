using System;
using System.Web;

using Bike2Ride.Services.Contracts;

using Microsoft.AspNet.Identity;

namespace Bike2Ride.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpContextBase httpContext;

        public IdentityService(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public Guid GetUserId()
        {
            return Guid.Parse(this.httpContext.User.Identity.GetUserId());
        }

        public string GetUsername()
        {
            return this.httpContext.User.Identity.GetUserName();
        }
    }
}
