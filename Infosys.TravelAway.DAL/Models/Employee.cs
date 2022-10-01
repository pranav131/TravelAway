using System;
using System.Collections.Generic;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public byte? RoleId { get; set; }
        public string EmailId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
