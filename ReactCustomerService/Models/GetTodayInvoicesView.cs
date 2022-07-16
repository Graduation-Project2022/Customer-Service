using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class GetTodayInvoicesView
    {
        public string Msisdn { get; set; } = null!;
        public DateOnly ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
    }
}
