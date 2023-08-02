using ApartmentMngSystem.Business.Configurations;
using ApartmentMngSystem.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApartmentMngSystem.DataAccess
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Apartment>? Apartments { get; set; }

        public DbSet<ApartmentCost>? ApartmentCosts { get; set; }

        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>()
            .HasOne(u => u.Apartment)
            .WithOne(a => a.User)
            .HasForeignKey<Apartment>(a => a.UserId);

        }
    }
}
