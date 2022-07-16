using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Cdr
    {
        public int CdrId { get; set; }
        public string MsisdnA { get; set; } = null!;
        public string MsisdnB { get; set; } = null!;
        public string ServiceName { get; set; } = null!;
        public DateTime CallTime { get; set; }
        public short DurationInSeconds { get; set; }
        public decimal? Rate { get; set; }
        public short? QuantityTypeId { get; set; }
        public ulong? IsBilled { get; set; }

        public virtual Mobilenumber MsisdnANavigation { get; set; } = null!;
        public virtual Mobilenumber MsisdnBNavigation { get; set; } = null!;
        public virtual QuantityType? QuantityType { get; set; }
        public virtual Service ServiceNameNavigation { get; set; } = null!;
    }
}
