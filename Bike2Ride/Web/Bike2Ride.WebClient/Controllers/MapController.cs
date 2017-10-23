using System.Collections.Generic;
using System.Web.Mvc;

using Bike2Ride.WebClient.ViewModels;

namespace Bike2Ride.WebClient.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Index()
        {
            var model = new MapViewModel()
            {
                Title = "Show Stations",
                Center = new LocationViewModel()
                {
                    lat = 42.70,
                    lng = 23.317
                },
                ZoomLevel = 12,
                Stations = new List<LocationViewModel>()
                {
                    new LocationViewModel()
                    {
                        lat = 42.705,
                        lng = 23.297
                    },
                    new LocationViewModel()
                    {
                        lat = 42.690,
                        lng = 23.337
                    },
                    new LocationViewModel()
                    {
                        lat = 42.651,
                        lng = 23.379
                    },
                    new LocationViewModel()
                    {
                        lat = 42.674,
                        lng = 23.310
                    }
                }
            };
            return this.View(model);
        }
    }
}
