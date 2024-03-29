﻿using Microsoft.EntityFrameworkCore;
using PLD.Blazor.DataAccess.Model;

namespace PLD.Blazor.DataAccess
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {           
        }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<TimeActivityMapping> TimeActivityMapping { get; set; }    
        public DbSet<CommissionError> CommissionError { get; set; }
        public DbSet<PremiumMode> PremiumMode { get; set; }
        public DbSet<CommissionFinal> CommissionFinal { get; set; }
        public DbSet<StateCode> StateCode { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<CaseStatus> CaseStatus { get; set; }
        public DbSet<CaseType> CaseType { get; set; }
        public DbSet<Payment> Payment { get; set; }
       protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // Product
            modelBuilder.Entity<Product>().HasOne(p => p.Carrier).WithMany(c => c.Products).HasForeignKey(f => f.CarrierId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasOne(p => p.ProductType).WithMany( pt => pt.Products).HasForeignKey(f => f.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserRole
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(f => f.UserId);
            modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(f => f.RoleId);

            //TimeActivtyMapping
            modelBuilder.Entity<TimeActivityMapping>().HasOne(p => p.Carrier).WithMany(t => t.TimeActivityMappings).HasForeignKey( f => f.CarrierId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeActivityMapping>().HasOne( p => p.Activity).WithMany( t => t.TimeActivityMappings).HasForeignKey( f => f.TransactionType)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeActivityMapping>().HasIndex(p => new { p.CarrierId, p.CarrierTime, p.CarrierActivity, p.PolicyYearStart, p.PolicyYearEnd })
                .IsUnique().HasFilter(null);

            //CommissionError
            modelBuilder.Entity<CommissionError>().HasOne( c => c.Carrier).WithMany( carrier => carrier.CommissionErrors).
                HasForeignKey( commissionError => commissionError.CarrierId )
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<CommissionError>().HasOne( p => p.Product).WithMany( product => product.CommissionErrors).
                HasForeignKey( commissionError => commissionError.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<CommissionError>().HasOne( a => a.Activity).WithMany( activity => activity.CommissionErrors).
                HasForeignKey( commissionError => commissionError.TransType)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<CommissionError>().HasOne(p => p.PremiumMode).WithMany(premiumMode => premiumMode.CommissionErrors).
                HasForeignKey(commissionError => commissionError.CommPremiumMode)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            //CommissionFinal
            modelBuilder.Entity<CommissionFinal>().HasOne( c => c.Carrier).WithMany( carrier => carrier.CommissionFinals).
                HasForeignKey( commissionFinal => commissionFinal.CarrierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<CommissionFinal>().HasOne(c => c.Product).WithMany(carrier => carrier.CommissionFinals).
                HasForeignKey(commissionFinal => commissionFinal.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<CommissionFinal>().HasOne(a => a.Activity).WithMany(activity => activity.CommissionFinals).
                HasForeignKey(commissionFinal => commissionFinal.TransType)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<CommissionFinal>().HasOne(p => p.PremiumMode).WithMany(premiumMode => premiumMode.CommissionFinals).
                HasForeignKey(commissionFinal => commissionFinal.CommPremiumMode)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Case
            modelBuilder.Entity<Case>().HasOne(c => c.Carrier).WithMany(carrier => carrier.Cases).
                HasForeignKey(pldCase => pldCase.CarrierId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<Case>().HasOne( c => c.Product).WithMany( product => product.Cases).
                HasForeignKey( pldCase => pldCase.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<Case>().HasOne(pt => pt.ProductType).WithMany(productType => productType.Cases).
                HasForeignKey(pldCase => pldCase.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<Case>().HasOne( cs => cs.CaseStatus).WithMany( caseStatus => caseStatus.Cases).
                HasForeignKey( pldCase => pldCase.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<Case>().HasOne(ct => ct.CaseType).WithMany(caseType => caseType.Cases).
                HasForeignKey(pldCase => pldCase.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            //Payment
            modelBuilder.Entity<Payment>().HasOne(p => p.Carrier).WithMany(carrier => carrier.Payments).
                HasForeignKey(payment => payment.CarrierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}