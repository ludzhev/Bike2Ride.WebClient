using System.Linq;
using System.Web.Mvc;

using Bike2Ride.WebClient.Controllers;

using NUnit.Framework;

namespace Bike2Ride.WebClient.Tests.Controllers.MapControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void HaveOutputCacheAttribute()
        {
            // Arrange
            var method = typeof(MapController).GetMethod("Index");

            //Act & Asssert
            Assert.True(method.GetCustomAttributes(typeof(OutputCacheAttribute), false).Any());
        }
    }
}
