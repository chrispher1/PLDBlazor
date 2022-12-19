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
        }
    }
}