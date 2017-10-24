using System.Collections.Generic;
using System.Linq;

using Bike2Ride.Data.Contracts;
using Bike2Ride.Data.Models;
using Bike2Ride.Services.Contracts;

using Bytes2you.Validation;

namespace Bike2Ride.Services
{
    public class CityService : ICityService
    {
        private const double Delta = 0.0001;

        private readonly IEFRepository<City> cityRepository;
        private readonly IEFUnitOfWork unitOfWork;
        private readonly IEFRepository<Location> locationRepository;

        public CityService(
            IEFRepository<City> cityRepository,
            IEFRepository<Location> locationRepository,
            IEFUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(cityRepository, "CityService cityRepository")
                .IsNull()
                .Throw();

            this.cityRepository = cityRepository;

            Guard.WhenArgument(locationRepository, "CityService locationRepository")
                .IsNull()
                .Throw();

            this.locationRepository = locationRepository;

            Guard.WhenArgument(unitOfWork, "CityService unitOfWork")
                .IsNull()
                .Throw();

            this.unitOfWork = unitOfWork;
        }


        public bool CreateCity(City city)
        {
            var isNameOccupied = this.cityRepository
                .All
                .Any(c => c.Name == city.Name);

            if (isNameOccupied)
            {
                return false;
            }

            city.Center = AddCenter(city.Center);
            city.Locations = AddLocations(city.Locations);

            this.cityRepository.Add(city);
            this.unitOfWork.SaveChanges();

            return true;
        }

        public Location AddCenter(Location location)
        {
            if (location == null)
            {
                return null;
            }

            location = locationRepository
                              .All
                              .SingleOrDefault(
                                  l => (l.Lat - location.Lat < Delta ||
                                        location.Lat - l.Lat < Delta) &&
                                       (l.Lng - location.Lng < Delta ||
                                        location.Lng - l.Lng < Delta))
                          ?? location;

            return location;
        }

        public ICollection<Location> AddLocations(ICollection<Location> locations)
        {
            var currentLocations = new List<Location>(locations.Count);

            foreach (var location in locations)
            {
                var currentLocation = locationRepository
                               .All
                               .SingleOrDefault(
                                              l => (l.Lat - location.Lat < Delta ||
                                                    location.Lat - l.Lat < Delta) &&
                                                   (l.Lng - location.Lng < Delta ||
                                                    location.Lng - l.Lng < Delta))
                           ?? location;

                currentLocations.Add(currentLocation);
            }

            return currentLocations;
        }

        public City GetCityByName(string name)
        {
            return this.cityRepository
                .All
                .SingleOrDefault(c => c.Name == name);
        }
    }
}
