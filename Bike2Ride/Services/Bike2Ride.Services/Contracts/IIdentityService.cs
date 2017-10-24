using System;

namespace Bike2Ride.Services.Contracts
{
    public interface IIdentityService
    {
        Guid GetUserId();

        string GetUsername();
    }
}
