using System;

using Bike2Ride.Data.Models.Enumerations;

namespace Bike2Ride.Services.Contracts
{
    public interface ITripService
    {
        void AttachRoute(Guid routeId);

        void AttachUser(Guid userId);

        void AddTrip(
            DateTime? startTime = null,
            DateTime? finishTime = null,
            double? duration = null,
            TripStatus status = TripStatus.NotAcconplished);
    }
}
