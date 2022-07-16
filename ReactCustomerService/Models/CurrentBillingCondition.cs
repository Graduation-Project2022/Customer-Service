﻿using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class CurrentBillingCondition
    {
        public string Msisdn { get; set; } = null!;
        public string ServiceName { get; set; } = null!;
        public short BillingConditionId { get; set; }

        public virtual BillingCondition BillingCondition { get; set; } = null!;
        public virtual Mobilenumber MsisdnNavigation { get; set; } = null!;
        public virtual Service ServiceNameNavigation { get; set; } = null!;
    }
}
