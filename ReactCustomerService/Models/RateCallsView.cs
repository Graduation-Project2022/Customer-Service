using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class RateCallsView
    {
        public int CdrId { get; set; }
        public decimal? Rate { get; set; }
        public short QuantityTypeId { get; set; }
    }
}
