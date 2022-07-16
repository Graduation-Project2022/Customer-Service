using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class PlansQuantity
    {
        public short PlanId { get; set; }
        public short QuantityTypeId { get; set; }
        public decimal Quantity { get; set; }

        public virtual Plan Plan { get; set; } = null!;
        public virtual QuantityType QuantityType { get; set; } = null!;
    }
}
