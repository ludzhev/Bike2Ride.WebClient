using System;
using System.Collections.Generic;
using System.Linq;
using Bike2Ride.Data.Contracts;
using Bike2Ride.Data.Models;
using Moq;
using NUnit.Framework;

namespace Bike2Ride.Services.UnitTests.UserServiceTests
{
    [TestFixture]
    public class AttachTrip_Should
    {
        [Test]
        public void CallUserRepositoryAllOnes_WhenInvoked()
        {
            // Arrange
            var guid = Guid.NewGuid();

            var userRepositoryMock = new Mock<IEFRepository<User>>();

            userRepositoryMock.Setup(x => x.All).Returns(new List<User>().AsQueryable());

            var sut = new UserService(userRepositoryMock.Object);

            var trip = new Trip();

            // Act
            sut.AttachTrip(guid, trip);

            // Asssert
            userRepositoryMock.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void AddTrip_WhenPassedValidOne()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var trips = new List<Trip>();

            var user = new User()
            {
                Id = guid.ToString(),
                Trips = trips
            };

            var query = new List<User>() { user }.AsQueryable();

            var userRepositoryMock = new Mock<IEFRepository<User>>();

            userRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new UserService(userRepositoryMock.Object);

            var trip = new Trip();

            // Act
            sut.AttachTrip(guid, trip);

            // Asssert
            CollectionAssert.Contains(user.Trips, trip);
        }

        [Test]
        public void Throw_WhenMoreThanOneUserWithGivenId()
        {

            // Arrange
            var guid = Guid.NewGuid();

            var user = new User()
            {
                Id = guid.ToString(),
            };

            var userWithSameId = new User()
            {
                Id = guid.ToString(),
            };

            var query = new List<User>() { user, userWithSameId }.AsQueryable();

            var userRepositoryMock = new Mock<IEFRepository<User>>();

            userRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new UserService(userRepositoryMock.Object);

            // Act & Asssert
            Assert.Throws<InvalidOperationException>(
                () => sut.AttachTrip(guid, new Trip()));
        }
    }
}
