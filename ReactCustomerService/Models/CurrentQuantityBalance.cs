using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class CurrentQuantityBalance
    {
        public string Msisdn { get; set; } = null!;
        public short QuantityTypeId { get; set; }
        public string? CurrentBalance { get; set; }
        public string? ExpirationDate { get; set; }

        public virtual Mobilenumber MsisdnNavigation { get; set; } = null!;
        public virtual QuantityType QuantityType { get; set; } = null!;
    }
}
