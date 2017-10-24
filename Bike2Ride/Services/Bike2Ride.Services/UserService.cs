using System;
using System.Linq;

using Bike2Ride.Data.Contracts;
using Bike2Ride.Data.Models;
using Bike2Ride.Services.Contracts;

using Bytes2you.Validation;

namespace Bike2Ride.Services
{
    public class UserService : IUserService
    {
        private readonly IEFRepository<User> userRepository;

        public UserService(IEFRepository<User> userRepository)
        {
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();
            this.userRepository = userRepository;
        }

        public void AttachTrip(Guid userId, Trip trip)
        {
            this.userRepository
                .All
                .SingleOrDefault(u => u.Id == userId.ToString())
                ?.Trips.Add(trip);
        }
    }
}
