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
    public class GetCityByName_Should
    {
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

            var query = new List<City>() { city }.AsQueryable();

            cityRepositoryMock.SetupGet(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            sut.GetCityByName(city.Name);

            // Asssert
            cityRepositoryMock.VerifyGet(c => c.All, Times.Once);
        }

        [Test]
        public void ReturnNull_WhenNoSuchCity()
        {
            // Arrange
            var cityRepositoryMock = new Mock<IEFRepository<City>>();
            var locationRepositoryMock = new Mock<IEFRepository<Location>>();
            var unitOfWorkMock = new Mock<IEFUnitOfWork>();
            
            var query = new List<City>().AsQueryable();

            cityRepositoryMock.SetupGet(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.GetCityByName("Sofia");

            // Asssert
            Assert.IsNull(result);
        }

        [Test]
        public void NotReturnNull_WhenSuchCity()
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

            var query = new List<City>() { city }.AsQueryable();

            cityRepositoryMock.SetupGet(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            var result = sut.GetCityByName("Sofia");

            // Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Throw_WhenMoreThanOneCityWithGivenName()
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

            var cityWithSameName = new City()
            {
                Name = "Sofia",
                ZoomLevel = 1
            };

            var query = new List<City>()
            {
                city,
                cityWithSameName
            }.AsQueryable();

            cityRepositoryMock.SetupGet(x => x.All).Returns(query);

            var sut = new CityService(
                cityRepositoryMock.Object,
                locationRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act & Asssert
            Assert.Throws<InvalidOperationException>(
                () => sut.GetCityByName(city.Name));
        }
    }
}
