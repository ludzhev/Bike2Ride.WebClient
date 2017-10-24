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
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange & Act & Asssert
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

        [Test]
        public void NotThrowArgumentNullException_WhenPassedValidUserRepository()
        {
            var userRepositoryMock = new Mock<IEFRepository<User>>();

            // Arrange & Act & Asssert
            Assert.DoesNotThrow(() => new UserService(userRepositoryMock.Object));
        }

        [Test]
        [Category("UserService.Constructor")]
        public void CreateAnInstanceOfUserService_WhenPassedValidInput()
        {
            // Arrange
            var userRepositoryMock = new Mock<IEFRepository<User>>();

            // Act
            var result = new UserService(userRepositoryMock.Object);

            //Asssert
            Assert.That(result, Is.InstanceOf<UserService>());
        }
    }
}
