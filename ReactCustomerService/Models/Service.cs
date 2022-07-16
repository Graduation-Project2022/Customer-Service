using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Service
    {
        public Service()
        {
            Cdrs = new HashSet<Cdr>();
            CurrentBillingConditions = new HashSet<CurrentBillingCondition>();
            PlanServiceDefaultBillingConditions = new HashSet<PlanServiceDefaultBillingCondition>();
            PlansServicesPrices = new HashSet<PlansServicesPrice>();
            QuantityTypes = new HashSet<QuantityType>();
        }

        public string ServiceName { get; set; } = null!;
        public short ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<Cdr> Cdrs { get; set; }
        public virtual ICollection<CurrentBillingCondition> CurrentBillingConditions { get; set; }
        public virtual ICollection<PlanServiceDefaultBillingCondition> PlanServiceDefaultBillingConditions { get; set; }
        public virtual ICollection<PlansServicesPrice> PlansServicesPrices { get; set; }

        public virtual ICollection<QuantityType> QuantityTypes { get; set; }
    }
}
