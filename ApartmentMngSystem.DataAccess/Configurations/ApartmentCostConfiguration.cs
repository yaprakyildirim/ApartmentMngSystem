using ApartmentMngSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentMngSystem.DataAccess.Configurations
{
    public class ApartmentCostConfiguration : IEntityTypeConfiguration<ApartmentCost>
    {
        public void Configure(EntityTypeBuilder<ApartmentCost> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CostType).IsRequired().HasConversion<string>();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.IsPaid).IsRequired();
            builder.HasOne(x => x.Apartment).WithMany(x => x.ApartmentCosts).HasForeignKey(x => x.ApartmentId);
        }
    }
}
