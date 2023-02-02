using Microsoft.EntityFrameworkCore;
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
        }
    }
}