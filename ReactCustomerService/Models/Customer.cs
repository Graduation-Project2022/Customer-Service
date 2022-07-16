using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Mobilenumbers = new HashSet<Mobilenumber>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? NationalId { get; set; }

        public virtual ICollection<Mobilenumber> Mobilenumbers { get; set; }
    }
}
