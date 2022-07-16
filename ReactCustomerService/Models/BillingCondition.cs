using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class BillingCondition
    {
        public BillingCondition()
        {
            CurrentBillingConditions = new HashSet<CurrentBillingCondition>();
            PlanServiceDefaultBillingConditions = new HashSet<PlanServiceDefaultBillingCondition>();
            PlansServicesPrices = new HashSet<PlansServicesPrice>();
        }

        public short BillingConditionId { get; set; }
        public string ConditionName { get; set; } = null!;

        public virtual ICollection<CurrentBillingCondition> CurrentBillingConditions { get; set; }
        public virtual ICollection<PlanServiceDefaultBillingCondition> PlanServiceDefaultBillingConditions { get; set; }
        public virtual ICollection<PlansServicesPrice> PlansServicesPrices { get; set; }
    }
}
