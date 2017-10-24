using System;

using Bike2Ride.Services.Contracts;
using Bike2Ride.WebClient.Controllers;

using Moq;
using NUnit.Framework;

namespace Bike2Ride.WebClient.Tests.Controllers.MapControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange & Act & Asssert
            Assert.Throws<ArgumentNullException>(() => new MapController(null));
        }

        [Test]
        public void NotThrow_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<ICityService>();

            //Act & Asssert
            Assert.DoesNotThrow(() => new MapController(mockedService.Object));
        }

        [Test]
        public void CreateAnInstanceOfMapController_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<ICityService>();

            //Act
            var sut = new MapController(mockedService.Object);

            //Asssert
            Assert.That(sut, Is.InstanceOf<MapController>());
        }
    }
}
