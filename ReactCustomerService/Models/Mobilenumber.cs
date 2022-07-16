using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Mobilenumber
    {
        public Mobilenumber()
        {
            CdrMsisdnANavigations = new HashSet<Cdr>();
            CdrMsisdnBNavigations = new HashSet<Cdr>();
            CurrentBillingConditions = new HashSet<CurrentBillingCondition>();
            CurrentQuantityBalances = new HashSet<CurrentQuantityBalance>();
            Invoices = new HashSet<Invoice>();
        }

        public string Msisdn { get; set; } = null!;
        public string CompanyCode { get; set; } = null!;
        public int? CustomerId { get; set; }
        public short PlanId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Cdr> CdrMsisdnANavigations { get; set; }
        public virtual ICollection<Cdr> CdrMsisdnBNavigations { get; set; }
        public virtual ICollection<CurrentBillingCondition> CurrentBillingConditions { get; set; }
        public virtual ICollection<CurrentQuantityBalance> CurrentQuantityBalances { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
