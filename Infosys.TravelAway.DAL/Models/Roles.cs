using System;
using System.Collections.Generic;

namespace Infosys.TravelAway.DAL.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
        }

        public byte RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
