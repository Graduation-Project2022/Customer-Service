using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class InitializeBillingConditionView
    {
        public string Msisdn { get; set; } = null!;
        public string? ServiceName { get; set; }
        public short? BillingConditionId { get; set; }
    }
}
