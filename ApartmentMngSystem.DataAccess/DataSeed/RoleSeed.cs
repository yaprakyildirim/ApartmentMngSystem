using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApartmentMngSystem.DataAccess.DataSeed
{
    public class RoleSeed : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                ConcurrencyStamp = "341743f0-asd2–42de-afbf-49kmkkmk72cf6"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "34213123xxx0-asd2–42de-afas29k3X72cf6",
                ConcurrencyStamp = "341743f0-asd2–42de-afbf-39kmkkmk72cf6"
            }
            );
        }
    }
}
