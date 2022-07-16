using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class PlanServiceDefaultBillingCondition
    {
        public short PlanId { get; set; }
        public string ServiceName { get; set; } = null!;
        public short BillingConditionId { get; set; }

        public virtual BillingCondition BillingCondition { get; set; } = null!;
        public virtual Plan Plan { get; set; } = null!;
        public virtual Service ServiceNameNavigation { get; set; } = null!;
    }
}
