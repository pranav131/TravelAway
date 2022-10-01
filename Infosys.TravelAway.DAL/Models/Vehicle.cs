using System;
using System.Collections.Generic;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            VehicleBooked = new HashSet<VehicleBooked>();
        }

        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public decimal RatePerHour { get; set; }
        public decimal RatePerKm { get; set; }
        public decimal BasePrice { get; set; }

        public virtual ICollection<VehicleBooked> VehicleBooked { get; set; }
    }
}
