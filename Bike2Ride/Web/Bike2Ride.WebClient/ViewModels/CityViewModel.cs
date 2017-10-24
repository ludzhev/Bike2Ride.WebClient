using System.Collections.Generic;

using Bike2Ride.WebClient.ViewModels.Abstraction;

namespace Bike2Ride.WebClient.ViewModels
{
    public class CityViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public LocationViewModel Center { get; set; }

        public int ZoomLevel { get; set; }

        public IEnumerable<LocationViewModel> Stations { get; set; }
    }
}
