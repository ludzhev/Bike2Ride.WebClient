using System.Collections.Generic;
using System.Linq;
using Bike2Ride.Data.Contracts;
using Bike2Ride.Data.Models;
using Moq;
using NUnit.Framework;

namespace Bike2Ride.Services.UnitTests.CityServiceTest
{
    [TestFixture]
    public class CreateCity_Should
    {
        [Test]
        public void ReturnTrue_WhenPassedNotExistingCity()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var city = new City()
            {
               Name = "Sofia",
               ZoomLevel = 1
            };

            var query = new List<City>().AsQueryable();

            cityRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.CreateCity(city);

            // Asssert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ReturnFalse_WhenPassedExistingCity()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var city = new City()
            {
                Name = "Sofia",
                ZoomLevel = 1
            };

            var query = new List<City>(){ city }.AsQueryable();

            cityRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.CreateCity(city);

            // Asssert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CallCityRepositoryAdd_WhenPassedNotExistingCity()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var city = new City()
            {
                Name = "Sofia",
                ZoomLevel = 1
            };

            var query = new List<City>().AsQueryable();

            cityRepositoryMock.Setup(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            sut.CreateCity(city);

            // Asssert
            cityRepositoryMock.Verify(c => c.Add(city), Times.Once);
        }
        
        [Test]
        public void CallCityRepositoryAllOnce()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();

            var city = new City()
            {
                Name = "Sofia",
                ZoomLevel = 1
            };

            var query = new List<City>()
            {
                city,
                city
            }.AsQueryable();

            cityRepositoryMock.SetupGet(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            sut.CreateCity(city);

            // Asssert
            cityRepositoryMock.VerifyGet(c => c.All, Times.Once);
        }
    }
}
