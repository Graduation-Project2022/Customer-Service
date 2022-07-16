using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Plan
    {
        public Plan()
        {
            PlanServiceDefaultBillingConditions = new HashSet<PlanServiceDefaultBillingCondition>();
            PlansQuantities = new HashSet<PlansQuantity>();
            PlansServicesPrices = new HashSet<PlansServicesPrice>();
            CompanyCodes = new HashSet<Company>();
        }

        public short PlanId { get; set; }
        public string PlanName { get; set; } = null!;
        public short GeneralPlanId { get; set; }
        public decimal InitialPrice { get; set; }
        public string Periodicity { get; set; } = null!;

        public virtual GeneralPlan GeneralPlan { get; set; } = null!;
        public virtual ICollection<PlanServiceDefaultBillingCondition> PlanServiceDefaultBillingConditions { get; set; }
        public virtual ICollection<PlansQuantity> PlansQuantities { get; set; }
        public virtual ICollection<PlansServicesPrice> PlansServicesPrices { get; set; }

        public virtual ICollection<Company> CompanyCodes { get; set; }
    }
}
