using System.ComponentModel.DataAnnotations;
using Bike2Ride.Data.Models.Abstraction;

namespace Bike2Ride.Data.Models
{
    public class Location : DataModel
    {
        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }
    }
}
