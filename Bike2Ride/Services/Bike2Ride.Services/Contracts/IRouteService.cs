using System;

namespace Bike2Ride.Services.Contracts
{
    public interface IRouteService
    {
        void AddRoute(string path, double distance, int? zoomLevel = null);

        void AtachStartLocation(Guid locationId);

        void AtachEndLocation(Guid locationId);

        void AtachStartCenter(Guid locationId);
    }
}
