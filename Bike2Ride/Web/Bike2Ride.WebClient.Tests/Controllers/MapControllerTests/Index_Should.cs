using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Bike2Ride.Services.Contracts;
using Bike2Ride.WebClient.Controllers;

using Moq;
using NUnit.Framework;

namespace Bike2Ride.WebClient.Tests.Controllers.MapControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange & Act & Asssert
            Assert.Throws<ArgumentNullException>(() => new MapController(null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<ICityService>();

            //Act & Asssert
            Assert.DoesNotThrow(() => new MapController(mockedService.Object));
        }

        [Test]
        public void Constructor_ShouldCreateAnInstanceOfMapController_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<ICityService>();

            //Act
            var sut = new MapController(mockedService.Object);

            //Asssert
            Assert.That(sut, Is.InstanceOf<MapController>());
        }

        [Test]
        public void Index_ShouldHaveOutputCacheAttribute()
        {
            // Arrange
            var method = typeof(MapController).GetMethod("Index");

            //Act & Asssert
            Assert.True(method.GetCustomAttributes(typeof(OutputCacheAttribute), false).Any());
        }
    }
}
