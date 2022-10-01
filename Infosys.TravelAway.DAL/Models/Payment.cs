using System;
using System.Collections.Generic;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PaymentStatus { get; set; }

        public virtual BookPackage Booking { get; set; }
    }
}
