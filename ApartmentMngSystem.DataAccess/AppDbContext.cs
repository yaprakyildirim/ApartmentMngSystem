using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess.DataSeed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMngSystem.DataAccess
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Apartment>? Apartments { get; set; }
        public DbSet<ApartmentCost>? ApartmentCosts { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApartmentSeed());
            modelBuilder.ApplyConfiguration(new ApartmentCostSeed());
            modelBuilder.ApplyConfiguration(new MessageSeed());
            modelBuilder.ApplyConfiguration(new RoleSeed());
            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleSeed());
        }
    }
}
