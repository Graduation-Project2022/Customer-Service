using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Company
    {
        public Company()
        {
            GeneralPlans = new HashSet<GeneralPlan>();
            Plans = new HashSet<Plan>();
        }

        public string CompanyCode { get; set; } = null!;
        public string CompanyName { get; set; } = null!;

        public virtual ICollection<GeneralPlan> GeneralPlans { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}
