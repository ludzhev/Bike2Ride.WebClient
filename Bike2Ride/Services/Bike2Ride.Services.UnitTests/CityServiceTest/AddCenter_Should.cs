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
    public class AddCenter_Should
    {
        [Test]
        public void ReturnNull_WhenNullPassed()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.AddCenter(null);


            // Asssert
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnSameLocation_WhenThereIsNoSuchLocation()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var location = new Location() { Lat = 1, Lng = 1 };
            var differentLocation = new Location() { Lat = 2, Lng = 2 };

            var query = new List<Location>() { location }.AsQueryable();

            locationRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.AddCenter(differentLocation);


            // Asssert
            Assert.AreEqual(differentLocation, result);
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
            var result = sut.AddCenter(differentLocation);


            // Asssert
            Assert.AreNotEqual(differentLocation, result);
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
                () => sut.AddCenter(differentLocation));
        }

        [Test]
        public void CallLocationRepositoryAllOnce()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

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
            sut.AddCenter(differentLocation);

            // Asssert
            locationRepositoryMock.VerifyGet(c => c.All, Times.Once);
        }
    }
}
