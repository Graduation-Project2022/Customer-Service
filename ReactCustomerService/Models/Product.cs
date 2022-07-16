using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Product
    {
        public Product()
        {
            Services = new HashSet<Service>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
    }
}
