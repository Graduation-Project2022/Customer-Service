using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string Msisdn { get; set; } = null!;
        public DateOnly ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }

        public virtual Mobilenumber MsisdnNavigation { get; set; } = null!;
    }
}
