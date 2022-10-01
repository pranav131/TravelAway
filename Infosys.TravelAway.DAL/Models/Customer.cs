using System;
using System.Collections.Generic;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BookPackage = new HashSet<BookPackage>();
        }

        public string EmailId { get; set; }
        public byte? RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPassword { get; set; }
        public string Gender { get; set; }
        public decimal ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<BookPackage> BookPackage { get; set; }
    }
}
