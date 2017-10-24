using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Bike2Ride.Services.Contracts;
using Bike2Ride.WebClient.ViewModels;

using Bytes2you.Validation;

namespace Bike2Ride.WebClient.Controllers
{
    public class MapController : Controller
    {
        private const string IndexTitle = "Show Stations";
        private const string DefaultCity = "Sofia";
        private const int DefaultZoomLevel = 12;
        private const int CacheDuration = 60 * 60 * 24;

        private readonly ICityService cityService;

        public MapController(ICityService cityService)
        {
            Guard.WhenArgument(cityService, "MapController cityService")
                .IsNull()
                .Throw();

            this.cityService = cityService;
        }

        [OutputCache(
            Location = System.Web.UI.OutputCacheLocation.Server,
            Duration = CacheDuration)]
        public ActionResult Index()
        {
            var city = this.cityService.GetCityByName(DefaultCity);

            var model = new MapViewModel()
            {
                Title = IndexTitle,
                Center = new LocationViewModel()
                {
                    lat = city.Center.Lat,
                    lng = city.Center.Lng
                },
                ZoomLevel = city.ZoomLevel ?? DefaultZoomLevel,
            };

            var locations = city
                .Locations.Select(location => new LocationViewModel()
                {
                    lat = location.Lat,
                    lng = location.Lng
                })
                .ToList();

            model.Stations = locations;

            return this.View(model);
        }
    }
}
