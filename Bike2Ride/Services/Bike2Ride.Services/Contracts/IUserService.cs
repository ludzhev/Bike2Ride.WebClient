using System;

using Bike2Ride.Data.Models;

namespace Bike2Ride.Services.Contracts
{
    public interface IUserService
    {
        void AttachTrip(Guid userId, Trip trip);
    }
}
