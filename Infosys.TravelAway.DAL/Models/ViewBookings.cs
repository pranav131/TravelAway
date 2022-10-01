using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infosys.TravelAway.DAL.Models
{
   public class ViewBookings
    {

        // public string EmailId { get; set; }
        [Key]
        public int BookingId { get; set; }
        public int NumberOfAdults{ get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime DateOfTravel { get; set; }
        public Decimal TotalAmount { get; set; }
        public string HotelName { get; set; }
        public string PlacesToVisit { get; set; }
        public int NoOfDays { get; set; }
        public int NoOfRooms { get; set; }
     
        public int NoOfNights { get; set; }

        public string PackageName { get; set; }
    }
}
