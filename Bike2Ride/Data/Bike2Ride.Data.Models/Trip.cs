using System;
using System.ComponentModel.DataAnnotations;

using Bike2Ride.Data.Models.Abstraction;
using Bike2Ride.Data.Models.Enumerations;

namespace Bike2Ride.Data.Models
{
    public class Trip : DataModel
    {
        public Trip() { }

        public virtual MapRoute Route { get; set; }

        public virtual User User { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FinishTime { get; set; }

        public double? Duration { get; set; }

        public TripStatus Status { get; set; }
    }
}
