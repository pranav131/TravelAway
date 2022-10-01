using System;
using System.Collections.Generic;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public string Comments { get; set; }
        public int? Rating1 { get; set; }
        public int? BookingId { get; set; }

        public virtual BookPackage Booking { get; set; }
    }
}
