using System;
using System.Collections.Generic;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class BookPackage
    {
        public BookPackage()
        {
            Accomodation = new HashSet<Accomodation>();
            CustomerCare = new HashSet<CustomerCare>();
            Payment = new HashSet<Payment>();
            Rating = new HashSet<Rating>();
        }

        public string EmailId { get; set; }
        public int BookingId { get; set; }
        public decimal ContactNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfTravel { get; set; }
        public int NumberOfAdults { get; set; }
        public int? NumberOfChildren { get; set; }
        public string Status { get; set; }
        public int? PackageId { get; set; }

        public virtual Customer Email { get; set; }
        public virtual Package Package { get; set; }
        public virtual ICollection<Accomodation> Accomodation { get; set; }
        public virtual ICollection<CustomerCare> CustomerCare { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
