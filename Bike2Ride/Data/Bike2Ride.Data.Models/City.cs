using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bike2Ride.Data.Models.Abstraction;

namespace Bike2Ride.Data.Models
{
    public class City : DataModel
    {
        private ICollection<Location> locations;

        public City()
        {
            this.locations = new HashSet<Location>();
        }

        [Required]
        public string Name { get; set; }

        public virtual Location Center { get; set; }

        public int? ZoomLevel { get; set; }

        public virtual ICollection<Location> Locations
        {
            get
            {
                return this.locations;
            }

            set
            {
                this.locations = value;
            }
        }
    }
}
