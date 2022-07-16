using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class QuantityType
    {
        public QuantityType()
        {
            Cdrs = new HashSet<Cdr>();
            CurrentQuantityBalances = new HashSet<CurrentQuantityBalance>();
            PlansQuantities = new HashSet<PlansQuantity>();
            PlansServicesPrices = new HashSet<PlansServicesPrice>();
            ServiceNames = new HashSet<Service>();
        }

        public short QuantityTypeId { get; set; }
        public string? QuantityTypeName { get; set; }

        public virtual ICollection<Cdr> Cdrs { get; set; }
        public virtual ICollection<CurrentQuantityBalance> CurrentQuantityBalances { get; set; }
        public virtual ICollection<PlansQuantity> PlansQuantities { get; set; }
        public virtual ICollection<PlansServicesPrice> PlansServicesPrices { get; set; }

        public virtual ICollection<Service> ServiceNames { get; set; }
    }
}
