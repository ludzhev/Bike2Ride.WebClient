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
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedNullCityRepository()
        {
            // Arrange
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();
            
            // Act & Asssert
            Assert.Throws<ArgumentNullException>(
                () => new CityService(null, locationRepositoryMock.Object, unitOfWorkMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedNullLocationRepository()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            // Act & Asssert
            Assert.Throws<ArgumentNullException>(
                () => new CityService(cityRepositoryMock.Object, null, unitOfWorkMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedNullUnitOfWork()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();

            // Act & Asssert
            Assert.Throws<ArgumentNullException>(
                () => new CityService(cityRepositoryMock.Object, locationRepositoryMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenPassedValidDependencies()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            // Act & Asssert
            Assert.DoesNotThrow(
                () => new CityService(
                    cityRepositoryMock.Object,
                    locationRepositoryMock.Object,
                    unitOfWorkMock.Object));
        }

        [Test]
        public void CreateAnInstanceOfCityService_WhenPassedValidDependencies()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();
            
            // Act
            var result = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Asssert
            Assert.That(result, Is.InstanceOf<CityService>());
        }
    }
}
