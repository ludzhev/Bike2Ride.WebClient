using System;
using System.Collections.Generic;
using Bike2Ride.Data.Models;

namespace Bike2Ride.Services.Contracts
{
    public interface ICityService
    {
        bool CreateCity(City city);

        Location AddCenter(Location location);

        ICollection<Location> AddLocations(ICollection<Location> locations);

        City GetCityByName(string name);
    }
}
