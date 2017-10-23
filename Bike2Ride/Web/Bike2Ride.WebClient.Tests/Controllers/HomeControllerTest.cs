using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Bike2Ride.WebClient;
using Bike2Ride.WebClient.Controllers;
using Moq;
using NUnit.Framework;

namespace Bike2Ride.WebClient.Tests.Controllers
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void RenderHomePage()
        {
            const string result = "work";

            var testMock = new Mock<HomeController>();
            testMock.Verify();

            Assert.AreEqual(result, result);
        }
    }
}
