using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class CurrentInvoiceView
    {
        public string Msisdn { get; set; } = null!;
        public string? CurrentPrice { get; set; }
        public string? ExpirationDate { get; set; }
        public string Currency { get; set; } = null!;
    }
}
