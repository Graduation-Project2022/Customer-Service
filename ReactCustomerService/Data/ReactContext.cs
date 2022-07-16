using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReactCustomerService.Models;

namespace ReactCustomerService.Data
{
    public partial class ReactContext : DbContext
    {
        public ReactContext()
        {
        }

        public ReactContext(DbContextOptions<ReactContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CurrentBillingCondition> CurrentBillingConditions { get; set; } = null!;
        public virtual DbSet<CurrentInvoiceView> CurrentInvoiceViews { get; set; } = null!;
        public virtual DbSet<CurrentQuantityBalance> CurrentQuantityBalances { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<GeneralPlan> GeneralPlans { get; set; } = null!;
        public virtual DbSet<GetTodayInvoicesView> GetTodayInvoicesViews { get; set; } = null!;
        public virtual DbSet<InitializeBalanceView> InitializeBalanceViews { get; set; } = null!;
        public virtual DbSet<InitializeBillingConditionView> InitializeBillingConditionViews { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Mobilenumber> Mobilenumbers { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<PlanServiceDefaultBillingCondition> PlanServiceDefaultBillingConditions { get; set; } = null!;
        public virtual DbSet<PlansQuantity> PlansQuantities { get; set; } = null!;
        public virtual DbSet<PlansServicesPrice> PlansServicesPrices { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<QuantityType> QuantityTypes { get; set; } = null!;
        public virtual DbSet<RateCallsView> RateCallsViews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<BillingCondition> BillingConditions { get; set; } = null!;
        public virtual DbSet<Cdr> Cdrs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PRIMARY");

                entity.ToTable("admins");

                entity.Property(e => e.UserName)
                    .HasMaxLength(45)
                    .HasColumnName("userName");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<BillingCondition>(entity =>
            {
                entity.ToTable("billing_conditions");

                entity.Property(e => e.BillingConditionId).HasColumnName("billingConditionID");

                entity.Property(e => e.ConditionName)
                    .HasMaxLength(45)
                    .HasColumnName("conditionName");
            });

            modelBuilder.Entity<Cdr>(entity =>
            {
                entity.ToTable("cdrs");

                entity.HasIndex(e => e.MsisdnA, "fk_recent_cdrs_mobileNumbers1_idx");

                entity.HasIndex(e => e.MsisdnB, "fk_recent_cdrs_mobileNumbers2_idx");

                entity.HasIndex(e => e.QuantityTypeId, "fk_recent_cdrs_quantity_types1_idx");

                entity.HasIndex(e => e.ServiceName, "fk_recent_cdrs_services1_idx");

                entity.Property(e => e.CdrId).HasColumnName("cdrID");

                entity.Property(e => e.CallTime)
                    .HasColumnType("datetime")
                    .HasColumnName("callTime");

                entity.Property(e => e.DurationInSeconds).HasColumnName("durationInSeconds");

                entity.Property(e => e.IsBilled)
                    .HasColumnType("bit(1)")
                    .HasColumnName("isBilled");

                entity.Property(e => e.MsisdnA)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN_A");

                entity.Property(e => e.MsisdnB)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN_B");

                entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeID");

                entity.Property(e => e.Rate)
                    .HasPrecision(10, 3)
                    .HasColumnName("rate");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(45)
                    .HasColumnName("serviceName");

                entity.HasOne(d => d.MsisdnANavigation)
                    .WithMany(p => p.CdrMsisdnANavigations)
                    .HasForeignKey(d => d.MsisdnA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recent_cdrs_mobileNumbers1");

                entity.HasOne(d => d.MsisdnBNavigation)
                    .WithMany(p => p.CdrMsisdnBNavigations)
                    .HasForeignKey(d => d.MsisdnB)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recent_cdrs_mobileNumbers2");

                entity.HasOne(d => d.QuantityType)
                    .WithMany(p => p.Cdrs)
                    .HasForeignKey(d => d.QuantityTypeId)
                    .HasConstraintName("fk_recent_cdrs_quantity_types1");

                entity.HasOne(d => d.ServiceNameNavigation)
                    .WithMany(p => p.Cdrs)
                    .HasForeignKey(d => d.ServiceName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recent_cdrs_services1");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyCode)
                    .HasName("PRIMARY");

                entity.ToTable("companies");

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(45)
                    .HasColumnName("companyCode");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(45)
                    .HasColumnName("companyName");

                entity.HasMany(d => d.Plans)
                    .WithMany(p => p.CompanyCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "CompanyPlan",
                        l => l.HasOne<Plan>().WithMany().HasForeignKey("PlanId").HasConstraintName("fk_company_plans_plans1"),
                        r => r.HasOne<Company>().WithMany().HasForeignKey("CompanyCode").HasConstraintName("fk_company_plans_companies1"),
                        j =>
                        {
                            j.HasKey("CompanyCode", "PlanId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("company_plans");

                            j.HasIndex(new[] { "CompanyCode" }, "fk_company_plans_companies1_idx");

                            j.HasIndex(new[] { "PlanId" }, "fk_company_plans_plans1_idx");

                            j.IndexerProperty<string>("CompanyCode").HasMaxLength(45).HasColumnName("companyCode");

                            j.IndexerProperty<short>("PlanId").HasColumnName("planID");
                        });
            });

            modelBuilder.Entity<CurrentBillingCondition>(entity =>
            {
                entity.HasKey(e => new { e.Msisdn, e.ServiceName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("current_billing_condition");

                entity.HasIndex(e => e.BillingConditionId, "fk_current_billing_condition_billing_conditions1");

                entity.HasIndex(e => e.Msisdn, "fk_current_billing_condition_mobilenumbers1_idx");

                entity.HasIndex(e => e.ServiceName, "fk_current_billing_condition_services1_idx");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(45)
                    .HasColumnName("serviceName");

                entity.Property(e => e.BillingConditionId).HasColumnName("billingConditionID");

                entity.HasOne(d => d.BillingCondition)
                    .WithMany(p => p.CurrentBillingConditions)
                    .HasForeignKey(d => d.BillingConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_current_billing_condition_billing_conditions1");

                entity.HasOne(d => d.MsisdnNavigation)
                    .WithMany(p => p.CurrentBillingConditions)
                    .HasForeignKey(d => d.Msisdn)
                    .HasConstraintName("fk_current_billing_condition_mobilenumbers1");

                entity.HasOne(d => d.ServiceNameNavigation)
                    .WithMany(p => p.CurrentBillingConditions)
                    .HasForeignKey(d => d.ServiceName)
                    .HasConstraintName("fk_current_billing_condition_services1");
            });

            modelBuilder.Entity<CurrentInvoiceView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("current_invoice_view");

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CurrentPrice)
                    .HasMaxLength(45)
                    .HasColumnName("currentPrice");

                entity.Property(e => e.ExpirationDate)
                    .HasMaxLength(45)
                    .HasColumnName("expirationDate");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");
            });

            modelBuilder.Entity<CurrentQuantityBalance>(entity =>
            {
                entity.HasKey(e => new { e.Msisdn, e.QuantityTypeId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("current_quantity_balance");

                entity.HasIndex(e => e.Msisdn, "fk_current_quantity_balance_mobileNumbers1_idx");

                entity.HasIndex(e => e.QuantityTypeId, "fk_current_quantity_balance_quantity_types1_idx");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeID");

                entity.Property(e => e.CurrentBalance)
                    .HasMaxLength(45)
                    .HasColumnName("currentBalance");

                entity.Property(e => e.ExpirationDate)
                    .HasMaxLength(45)
                    .HasColumnName("expirationDate");

                entity.HasOne(d => d.MsisdnNavigation)
                    .WithMany(p => p.CurrentQuantityBalances)
                    .HasForeignKey(d => d.Msisdn)
                    .HasConstraintName("fk_current_quantity_balance_mobileNumbers1");

                entity.HasOne(d => d.QuantityType)
                    .WithMany(p => p.CurrentQuantityBalances)
                    .HasForeignKey(d => d.QuantityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_current_quantity_balance_quantity_types1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .HasColumnName("lastName");

                entity.Property(e => e.NationalId)
                    .HasMaxLength(45)
                    .HasColumnName("nationalID");
            });

            modelBuilder.Entity<GeneralPlan>(entity =>
            {
                entity.ToTable("general_plans");

                entity.HasIndex(e => e.CompanyCode, "fk_general_plans_companies_idx");

                entity.Property(e => e.GeneralPlanId).HasColumnName("generalPlanID");

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(45)
                    .HasColumnName("companyCode");

                entity.Property(e => e.GeneralPlanName)
                    .HasMaxLength(45)
                    .HasColumnName("generalPlanName");

                entity.Property(e => e.GenerationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("generationTime");

                entity.Property(e => e.TerminationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("terminationTime");

                entity.HasOne(d => d.CompanyCodeNavigation)
                    .WithMany(p => p.GeneralPlans)
                    .HasForeignKey(d => d.CompanyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_general_plans_companies");
            });

            modelBuilder.Entity<GetTodayInvoicesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("get_today_invoices_view");

                entity.Property(e => e.Currency)
                    .HasMaxLength(45)
                    .HasColumnName("currency");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.Price)
                    .HasPrecision(8, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ReleaseDate).HasColumnName("releaseDate");
            });

            modelBuilder.Entity<InitializeBalanceView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("initialize_balance_view");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.Quantity)
                    .HasPrecision(11, 2)
                    .HasColumnName("quantity");

                entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeID");

                entity.Property(e => e.ReleaseDate).HasColumnName("releaseDate");
            });

            modelBuilder.Entity<InitializeBillingConditionView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("initialize_billing_condition_view");

                entity.Property(e => e.BillingConditionId).HasColumnName("billingConditionID");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(45)
                    .HasColumnName("serviceName");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoices");

                entity.HasIndex(e => e.Msisdn, "fk_invoice_mobilenumbers1_idx");

                entity.Property(e => e.InvoiceId).HasColumnName("invoiceID");

                entity.Property(e => e.Currency)
                    .HasMaxLength(45)
                    .HasColumnName("currency");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.Price)
                    .HasPrecision(8, 2)
                    .HasColumnName("price");

                entity.Property(e => e.ReleaseDate).HasColumnName("releaseDate");

                entity.HasOne(d => d.MsisdnNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Msisdn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_mobilenumbers1");
            });

            modelBuilder.Entity<Mobilenumber>(entity =>
            {
                entity.HasKey(e => e.Msisdn)
                    .HasName("PRIMARY");

                entity.ToTable("mobilenumbers");

                entity.HasIndex(e => e.CompanyCode, "fk_mobileNumbers_companies1_idx");

                entity.HasIndex(e => e.CustomerId, "fk_mobileNumbers_customers1_idx");

                entity.HasIndex(e => e.PlanId, "fk_mobileNumbers_plans1_idx");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(45)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(45)
                    .HasColumnName("companyCode");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.PlanId).HasColumnName("planID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Mobilenumbers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_mobileNumbers_customers1");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("plans");

                entity.HasIndex(e => e.GeneralPlanId, "fk_plans_general_plans1_idx");

                entity.Property(e => e.PlanId).HasColumnName("planID");

                entity.Property(e => e.GeneralPlanId).HasColumnName("generalPlanID");

                entity.Property(e => e.InitialPrice)
                    .HasPrecision(8, 2)
                    .HasColumnName("initialPrice");

                entity.Property(e => e.Periodicity)
                    .HasMaxLength(45)
                    .HasColumnName("periodicity");

                entity.Property(e => e.PlanName)
                    .HasMaxLength(45)
                    .HasColumnName("planName");

                entity.HasOne(d => d.GeneralPlan)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.GeneralPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_plans_general_plans1");
            });

            modelBuilder.Entity<PlanServiceDefaultBillingCondition>(entity =>
            {
                entity.HasKey(e => new { e.PlanId, e.ServiceName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("plan_service_default_billing_condition");

                entity.HasIndex(e => e.BillingConditionId, "fk_plans_services_default_billing_condition_billing_conditi_idx");

                entity.HasIndex(e => e.PlanId, "fk_plans_services_default_billing_condition_plans1_idx");

                entity.HasIndex(e => e.ServiceName, "fk_plans_services_default_billing_condition_services1_idx");

                entity.Property(e => e.PlanId).HasColumnName("planID");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(45)
                    .HasColumnName("serviceName");

                entity.Property(e => e.BillingConditionId).HasColumnName("billingConditionID");

                entity.HasOne(d => d.BillingCondition)
                    .WithMany(p => p.PlanServiceDefaultBillingConditions)
                    .HasForeignKey(d => d.BillingConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_plans_services_default_billing_condition_billing_conditions1");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlanServiceDefaultBillingConditions)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("fk_plans_services_default_billing_condition_plans1");

                entity.HasOne(d => d.ServiceNameNavigation)
                    .WithMany(p => p.PlanServiceDefaultBillingConditions)
                    .HasForeignKey(d => d.ServiceName)
                    .HasConstraintName("fk_plans_services_default_billing_condition_services1");
            });

            modelBuilder.Entity<PlansQuantity>(entity =>
            {
                entity.HasKey(e => new { e.PlanId, e.QuantityTypeId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("plans_quantities");

                entity.HasIndex(e => e.PlanId, "fk_plans_quantities_plans1_idx");

                entity.HasIndex(e => e.QuantityTypeId, "fk_plans_quantities_quantity_types1_idx");

                entity.Property(e => e.PlanId).HasColumnName("planID");

                entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeID");

                entity.Property(e => e.Quantity)
                    .HasPrecision(11, 2)
                    .HasColumnName("quantity");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlansQuantities)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_plans_quantities_plans1");

                entity.HasOne(d => d.QuantityType)
                    .WithMany(p => p.PlansQuantities)
                    .HasForeignKey(d => d.QuantityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_plans_quantities_quantity_types1");
            });

            modelBuilder.Entity<PlansServicesPrice>(entity =>
            {
                entity.HasKey(e => new { e.PlanId, e.ServiceName, e.BillingConditionId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("plans_services_prices");

                entity.HasIndex(e => e.BillingConditionId, "fk_plans_service_prices_billing_conditions1_idx");

                entity.HasIndex(e => e.PlanId, "fk_plans_service_prices_plans1_idx");

                entity.HasIndex(e => e.QuantityTypeId, "fk_plans_service_prices_quantity_types1_idx");

                entity.HasIndex(e => e.ServiceName, "fk_plans_service_prices_services1_idx");

                entity.Property(e => e.PlanId).HasColumnName("planID");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(45)
                    .HasColumnName("serviceName");

                entity.Property(e => e.BillingConditionId).HasColumnName("billingConditionID");

                entity.Property(e => e.Price)
                    .HasPrecision(6, 2)
                    .HasColumnName("price");

                entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeID");

                entity.HasOne(d => d.BillingCondition)
                    .WithMany(p => p.PlansServicesPrices)
                    .HasForeignKey(d => d.BillingConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_plans_service_prices_billing_conditions1");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlansServicesPrices)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("fk_plans_service_prices_plans1");

                entity.HasOne(d => d.QuantityType)
                    .WithMany(p => p.PlansServicesPrices)
                    .HasForeignKey(d => d.QuantityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_plans_service_prices_quantity_types1");

                entity.HasOne(d => d.ServiceNameNavigation)
                    .WithMany(p => p.PlansServicesPrices)
                    .HasForeignKey(d => d.ServiceName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_plans_service_prices_services1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(45)
                    .HasColumnName("productName");
            });

            modelBuilder.Entity<QuantityType>(entity =>
            {
                entity.ToTable("quantity_types");

                entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeID");

                entity.Property(e => e.QuantityTypeName)
                    .HasMaxLength(45)
                    .HasColumnName("quantityTypeName");

                entity.HasMany(d => d.ServiceNames)
                    .WithMany(p => p.QuantityTypes)
                    .UsingEntity<Dictionary<string, object>>(
                        "ServiceQuantityType",
                        l => l.HasOne<Service>().WithMany().HasForeignKey("ServiceName").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_service_quantity_types_services1"),
                        r => r.HasOne<QuantityType>().WithMany().HasForeignKey("QuantityTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_service_quantity_types_quantity_types1"),
                        j =>
                        {
                            j.HasKey("QuantityTypeId", "ServiceName").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("service_quantity_types");

                            j.HasIndex(new[] { "QuantityTypeId" }, "fk_service_quantity_types_quantity_types1_idx");

                            j.HasIndex(new[] { "ServiceName" }, "fk_service_quantity_types_services1_idx");

                            j.IndexerProperty<short>("QuantityTypeId").HasColumnName("quantityTypeID");

                            j.IndexerProperty<string>("ServiceName").HasMaxLength(45).HasColumnName("serviceName");
                        });
            });

            modelBuilder.Entity<RateCallsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("rate_calls_view");

                entity.Property(e => e.CdrId).HasColumnName("cdrID");

                entity.Property(e => e.QuantityTypeId).HasColumnName("quantityTypeID");

                entity.Property(e => e.Rate)
                    .HasPrecision(26, 2)
                    .HasColumnName("rate");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServiceName)
                    .HasName("PRIMARY");

                entity.ToTable("services");

                entity.HasIndex(e => e.ProductId, "fk_services_products1_idx");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(45)
                    .HasColumnName("serviceName");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_services_products1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
