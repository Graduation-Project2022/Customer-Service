using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class GeneralPlan
    {
        public GeneralPlan()
        {
            Plans = new HashSet<Plan>();
        }

        public short GeneralPlanId { get; set; }
        public string GeneralPlanName { get; set; } = null!;
        public string CompanyCode { get; set; } = null!;
        public DateTime GenerationTime { get; set; }
        public DateTime? TerminationTime { get; set; }

        public virtual Company CompanyCodeNavigation { get; set; } = null!;
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
