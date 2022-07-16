using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class InitializeBalanceView
    {
        public string Msisdn { get; set; } = null!;
        public short QuantityTypeId { get; set; }
        public decimal Quantity { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
