using System.ComponentModel.DataAnnotations;
using Bike2Ride.Data.Models.Abstraction;

namespace Bike2Ride.Data.Models
{
    public class MapRoute : DataModel
    {
        [Required]
        public string Path { get; set; }

        [Required]
        public double Distance { get; set; }

        public virtual Location StartLocation { get; set; }

        public virtual Location EndLocation { get; set; }

        public virtual Location Center { get; set; }

        public int? ZoomLevel { get; set; }
    }
}
