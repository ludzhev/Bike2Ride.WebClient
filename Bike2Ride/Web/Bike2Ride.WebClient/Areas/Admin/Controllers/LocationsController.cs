using System.Linq;
using System.Web.Mvc;
using Bike2Ride.Services.Contracts;
using Bike2Ride.WebClient.ViewModels;
using Bytes2you.Validation;

namespace Bike2Ride.WebClient.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationsController : Controller
    {
        private const string IndexTitle = "Add Stations";
        private const string DefaultCity = "Sofia";
        private const int DefaultZoomLevel = 12;

        private readonly ICityService cityService;

        public LocationsController(ICityService cityService)
        {
            Guard.WhenArgument(cityService, "MapController cityService")
                .IsNull()
                .Throw();

            this.cityService = cityService;
        }

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
