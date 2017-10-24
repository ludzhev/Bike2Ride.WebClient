using System;
using System.Collections.Generic;
using System.Linq;

using Bike2Ride.Data.Contracts;
using Bike2Ride.Data.Models;

using Moq;
using NUnit.Framework;

namespace Bike2Ride.Services.UnitTests.CityServiceTest
{
    [TestFixture]
    public class AddLocations__Should
    {
        [Test]
        public void ReturnCollectionWithSameLocation_WhenThereIsNoSuchLocation()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var location = new Location() {Lat = 1, Lng = 1};
            var differentLocation = new Location() {Lat = 2, Lng = 2};

            var query = new List<Location>() {location}.AsQueryable();

            locationRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.AddLocations(new List<Location>() {differentLocation});

            // Asssert
            Assert.AreSame(differentLocation, result.First());
        }

        [Test]
        public void ReturnDifferentLocation_WhenThereIsSuchLocation()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var location = new Location() { Lat = 1, Lng = 1 };
            var differentLocation = new Location() { Lat = 1, Lng = 1 };

            var query = new List<Location>() { location }.AsQueryable();

            locationRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.AddLocations(new List<Location>() { differentLocation });

            // Asssert
            Assert.AreNotSame(differentLocation, result.First());
        }


        [Test]
        public void Throw_WhenMoreThanOneLocationWithGivenName()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var differentLocation = new Location() { Lat = 1, Lng = 1 };

            var query = new List<Location>()
            {
                new Location() { Lat = 1, Lng = 1 },
                new Location() { Lat = 1, Lng = 1 }
            }.AsQueryable();

            locationRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act & Asssert
            Assert.Throws<InvalidOperationException>(
                () => sut.AddLocations(new List<Location>() { differentLocation }));
        }

        [Test]
        public void CallLocationRepositoryAllTwice_WhenTwoLacationsAdded()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var location = new Location() { Lat = 2, Lng = 2 };
            var differentLocation = new Location() { Lat = 1, Lng = 1 };

            var query = new List<Location>()
            {
                new Location() { Lat = 1, Lng = 1 },
            }.AsQueryable();

            locationRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act 
            sut.AddLocations(new List<Location>() { location, differentLocation });

            // Asssert
            locationRepositoryMock.VerifyGet(c => c.All, Times.Exactly(2));
        }

    }
}
